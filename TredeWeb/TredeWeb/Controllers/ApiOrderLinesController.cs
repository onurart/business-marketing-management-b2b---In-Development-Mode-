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
    public class ApiOrderLinesController : Controller
    {
        private TradeDbContext _context;

        public ApiOrderLinesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var orderlines = _context.OrderLines.Select(i => new {
                i.Id,
                i.OrderRef,
                i.LineId,
                i.ItemRef,
                i.Amount,
                i.Vat,
                i.Price,
                i.LineTotal,
                i.CreatedDate,
                i.IsActive,
                i.UnitRef,
                i.Description,
                i.UnitLineRef,
                i.CurrencyRef,
                i.FinanceLineRef
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(orderlines, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new OrderLines();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.OrderLines.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.OrderLines.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.OrderLines.FirstOrDefaultAsync(item => item.Id == key);

            _context.OrderLines.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CurrenciesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Currencies
                         orderby i.CurrType
                         select new {
                             Value = i.Id,
                             Text = i.CurrType
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnFicheLinesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnFicheLines
                         orderby i.Collect
                         select new {
                             Value = i.Id,
                             Text = i.Collect
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> ItemsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Items
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> OrdersLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Orders
                         orderby i.SrcName
                         select new {
                             Value = i.Id,
                             Text = i.SrcName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> UnitLinesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.UnitLines
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
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

        private void PopulateModel(OrderLines model, IDictionary values) {
            string ID = nameof(OrderLines.Id);
            string ORDER_REF = nameof(OrderLines.OrderRef);
            string L??NE_ID = nameof(OrderLines.LineId);
            string ITEM_REF = nameof(OrderLines.ItemRef);
            string AMOUNT = nameof(OrderLines.Amount);
            string VAT = nameof(OrderLines.Vat);
            string PR??CE = nameof(OrderLines.Price);
            string L??NE_TOTAL = nameof(OrderLines.LineTotal);
            string CREATED_DATE = nameof(OrderLines.CreatedDate);
            string IS_ACT??VE = nameof(OrderLines.IsActive);
            string UN??T_REF = nameof(OrderLines.UnitRef);
            string DESCR??PT??ON = nameof(OrderLines.Description);
            string UN??T_L??NE_REF = nameof(OrderLines.UnitLineRef);
            string CURRENCY_REF = nameof(OrderLines.CurrencyRef);
            string F??NANCE_L??NE_REF = nameof(OrderLines.FinanceLineRef);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(ORDER_REF)) {
                model.OrderRef = values[ORDER_REF] != null ? Convert.ToInt32(values[ORDER_REF]) : (int?)null;
            }

            if(values.Contains(L??NE_ID)) {
                model.LineId = values[L??NE_ID] != null ? Convert.ToInt32(values[L??NE_ID]) : (int?)null;
            }

            if(values.Contains(ITEM_REF)) {
                model.ItemRef = values[ITEM_REF] != null ? Convert.ToInt32(values[ITEM_REF]) : (int?)null;
            }

            if(values.Contains(AMOUNT)) {
                model.Amount = values[AMOUNT] != null ? Convert.ToDecimal(values[AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(VAT)) {
                model.Vat = values[VAT] != null ? Convert.ToInt32(values[VAT]) : (int?)null;
            }

            if(values.Contains(PR??CE)) {
                model.Price = values[PR??CE] != null ? Convert.ToDecimal(values[PR??CE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(L??NE_TOTAL)) {
                model.LineTotal = values[L??NE_TOTAL] != null ? Convert.ToDecimal(values[L??NE_TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(CREATED_DATE)) {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(IS_ACT??VE)) {
                model.IsActive = values[IS_ACT??VE] != null ? Convert.ToBoolean(values[IS_ACT??VE]) : (bool?)null;
            }

            if(values.Contains(UN??T_REF)) {
                model.UnitRef = values[UN??T_REF] != null ? Convert.ToInt32(values[UN??T_REF]) : (int?)null;
            }

            if(values.Contains(DESCR??PT??ON)) {
                model.Description = Convert.ToString(values[DESCR??PT??ON]);
            }

            if(values.Contains(UN??T_L??NE_REF)) {
                model.UnitLineRef = values[UN??T_L??NE_REF] != null ? Convert.ToInt32(values[UN??T_L??NE_REF]) : (int?)null;
            }

            if(values.Contains(CURRENCY_REF)) {
                model.CurrencyRef = values[CURRENCY_REF] != null ? Convert.ToInt32(values[CURRENCY_REF]) : (int?)null;
            }

            if(values.Contains(F??NANCE_L??NE_REF)) {
                model.FinanceLineRef = values[F??NANCE_L??NE_REF] != null ? Convert.ToInt32(values[F??NANCE_L??NE_REF]) : (int?)null;
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