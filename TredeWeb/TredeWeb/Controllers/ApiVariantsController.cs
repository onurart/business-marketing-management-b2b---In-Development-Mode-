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
            string PARENT_VAR??ANT = nameof(Variants.ParentVariant);
            string VAR??ANT_NAME = nameof(Variants.VariantName);
            string VAR??ANT_PR??CE = nameof(Variants.VariantPrice);
            string VAR??ANT_VALUE = nameof(Variants.VariantValue);
            string IS_ACT??VE = nameof(Variants.IsActive);
            string CREATED_DATE = nameof(Variants.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(PARENT_VAR??ANT)) {
                model.ParentVariant = values[PARENT_VAR??ANT] != null ? Convert.ToInt32(values[PARENT_VAR??ANT]) : (int?)null;
            }

            if(values.Contains(VAR??ANT_NAME)) {
                model.VariantName = Convert.ToString(values[VAR??ANT_NAME]);
            }

            if(values.Contains(VAR??ANT_PR??CE)) {
                model.VariantPrice = values[VAR??ANT_PR??CE] != null ? Convert.ToInt32(values[VAR??ANT_PR??CE]) : (int?)null;
            }

            if(values.Contains(VAR??ANT_VALUE)) {
                model.VariantValue = Convert.ToString(values[VAR??ANT_VALUE]);
            }

            if(values.Contains(IS_ACT??VE)) {
                model.IsActive = values[IS_ACT??VE] != null ? Convert.ToBoolean(values[IS_ACT??VE]) : (bool?)null;
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