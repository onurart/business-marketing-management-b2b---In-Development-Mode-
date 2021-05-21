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
    public class ApiCurrenciesController : Controller
    {
        private TradeDbContext _context;

        public ApiCurrenciesController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var currencies = _context.Currencies.Select(i => new
            {
                i.Id,
                i.CurrType,
                i.CurrValue,
                i.CurrDate,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(currencies, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Currencies();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Currencies.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Currencies.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.Currencies.FirstOrDefaultAsync(item => item.Id == key);

            _context.Currencies.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Currencies model, IDictionary values)
        {
            string ID = nameof(Currencies.Id);
            string CURR_TYPE = nameof(Currencies.CurrType);
            string CURR_VALUE = nameof(Currencies.CurrValue);
            string CURR_DATE = nameof(Currencies.CurrDate);
            string IS_ACTİVE = nameof(Currencies.IsActive);
            string CREATED_DATE = nameof(Currencies.CreatedDate);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(CURR_TYPE))
            {
                model.CurrType = values[CURR_TYPE] != null ? Convert.ToInt32(values[CURR_TYPE]) : (int?)null;
            }

            if (values.Contains(CURR_VALUE))
            {
                model.CurrValue = values[CURR_VALUE] != null ? Convert.ToDouble(values[CURR_VALUE], CultureInfo.InvariantCulture) : (double?)null;
            }

            if (values.Contains(CURR_DATE))
            {
                model.CurrDate = values[CURR_DATE] != null ? Convert.ToDateTime(values[CURR_DATE]) : (DateTime?)null;
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}