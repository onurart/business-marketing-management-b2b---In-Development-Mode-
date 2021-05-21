using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApiVariantsController : Controller
    {
        private TradeDbContext _context;

        public ApiVariantsController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var variants = _context.Variants.Select(i => new {
                i.Id,
                i.ParentVariant,
                i.VariantName,
                i.VariantPrice,
                i.VariantValue,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(variants, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Variants();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Variants.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Variants.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.Variants.FirstOrDefaultAsync(item => item.Id == key);

            _context.Variants.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Variants model, IDictionary values) {
            string ID = nameof(Variants.Id);
            string PARENT_VARİANT = nameof(Variants.ParentVariant);
            string VARİANT_NAME = nameof(Variants.VariantName);
            string VARİANT_PRİCE = nameof(Variants.VariantPrice);
            string VARİANT_VALUE = nameof(Variants.VariantValue);
            string IS_ACTİVE = nameof(Variants.IsActive);
            string CREATED_DATE = nameof(Variants.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(PARENT_VARİANT)) {
                model.ParentVariant = values[PARENT_VARİANT] != null ? Convert.ToInt32(values[PARENT_VARİANT]) : (int?)null;
            }

            if(values.Contains(VARİANT_NAME)) {
                model.VariantName = Convert.ToString(values[VARİANT_NAME]);
            }

            if(values.Contains(VARİANT_PRİCE)) {
                model.VariantPrice = values[VARİANT_PRİCE] != null ? Convert.ToInt32(values[VARİANT_PRİCE]) : (int?)null;
            }

            if(values.Contains(VARİANT_VALUE)) {
                model.VariantValue = Convert.ToString(values[VARİANT_VALUE]);
            }

            if(values.Contains(IS_ACTİVE)) {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if(values.Contains(CREATED_DATE)) {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}