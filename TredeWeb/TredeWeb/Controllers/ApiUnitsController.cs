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
    public class ApiUnitsController : Controller
    {
        private TradeDbContext _context;

        public ApiUnitsController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var units = _context.Units.Select(i => new {
                i.Id,
                i.Description,
                i.IsGeneral,
                i.IsDefault,
                i.SetName,
                i.ParentUnitSet,
                i.Specode,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(units, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Units();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Units.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Units.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Units.FirstOrDefaultAsync(item => item.Id == key);

            _context.Units.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> UnitsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Units
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Units model, IDictionary values) {
            string ID = nameof(Units.Id);
            string DESCRİPTİON = nameof(Units.Description);
            string IS_GENERAL = nameof(Units.IsGeneral);
            string IS_DEFAULT = nameof(Units.IsDefault);
            string SET_NAME = nameof(Units.SetName);
            string PARENT_UNİT_SET = nameof(Units.ParentUnitSet);
            string SPECODE = nameof(Units.Specode);
            string IS_ACTİVE = nameof(Units.IsActive);
            string CREATED_DATE = nameof(Units.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(DESCRİPTİON)) {
                model.Description = Convert.ToString(values[DESCRİPTİON]);
            }

            if(values.Contains(IS_GENERAL)) {
                model.IsGeneral = values[IS_GENERAL] != null ? Convert.ToBoolean(values[IS_GENERAL]) : (bool?)null;
            }

            if(values.Contains(IS_DEFAULT)) {
                model.IsDefault = values[IS_DEFAULT] != null ? Convert.ToBoolean(values[IS_DEFAULT]) : (bool?)null;
            }

            if(values.Contains(SET_NAME)) {
                model.SetName = Convert.ToString(values[SET_NAME]);
            }

            if(values.Contains(PARENT_UNİT_SET)) {
                model.ParentUnitSet = values[PARENT_UNİT_SET] != null ? Convert.ToInt32(values[PARENT_UNİT_SET]) : (int?)null;
            }

            if(values.Contains(SPECODE)) {
                model.Specode = values[SPECODE] != null ? Convert.ToInt32(values[SPECODE]) : (int?)null;
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