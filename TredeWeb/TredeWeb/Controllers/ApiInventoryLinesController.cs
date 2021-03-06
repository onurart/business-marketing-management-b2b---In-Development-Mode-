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
    public class ApiInventoryLinesController : Controller
    {
        private TradeDbContext _context;

        public ApiInventoryLinesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var ─▒nventorylines = _context.InventoryLines.Select(i => new {
                i.Id,
                i.StockFicheRef,
                i.IsChange,
                i.LineGuid,
                i.OwnerRef,
                i.AccountRef,
                i.Amount,
                i.DiscountType,
                i.DiscountValue,
                i.IsCancelled,
                i.IsDiscounted,
                i.ItemRef,
                i.ModifiedDate,
                i.ModifiedUser,
                i.MoveType,
                i.Price,
                i.SalesmanRef,
                i.Tax,
                i.LineNr,
                i.CostTax1,
                i.CostTax2,
                i.CostTax3,
                i.CurrencyRef,
                i.MinimumStockLevel,
                i.IsActive,
                i.CreatedDate,
                i.UnitRef,
                i.UnitLineRef
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(─▒nventorylines, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new InventoryLines();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.InventoryLines.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.InventoryLines.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.InventoryLines.FirstOrDefaultAsync(item => item.Id == key);

            _context.InventoryLines.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> AccountsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Accounts
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
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
        public async Task<IActionResult> UsersLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Users
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> InventoriesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Inventories
                         orderby i.Number
                         select new {
                             Value = i.Id,
                             Text = i.Number
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

        private void PopulateModel(InventoryLines model, IDictionary values) {
            string ID = nameof(InventoryLines.Id);
            string STOCK_F─░CHE_REF = nameof(InventoryLines.StockFicheRef);
            string IS_CHANGE = nameof(InventoryLines.IsChange);
            string L─░NE_GU─░D = nameof(InventoryLines.LineGuid);
            string OWNER_REF = nameof(InventoryLines.OwnerRef);
            string ACCOUNT_REF = nameof(InventoryLines.AccountRef);
            string AMOUNT = nameof(InventoryLines.Amount);
            string D─░SCOUNT_TYPE = nameof(InventoryLines.DiscountType);
            string D─░SCOUNT_VALUE = nameof(InventoryLines.DiscountValue);
            string IS_CANCELLED = nameof(InventoryLines.IsCancelled);
            string IS_D─░SCOUNTED = nameof(InventoryLines.IsDiscounted);
            string ITEM_REF = nameof(InventoryLines.ItemRef);
            string MOD─░F─░ED_DATE = nameof(InventoryLines.ModifiedDate);
            string MOD─░F─░ED_USER = nameof(InventoryLines.ModifiedUser);
            string MOVE_TYPE = nameof(InventoryLines.MoveType);
            string PR─░CE = nameof(InventoryLines.Price);
            string SALESMAN_REF = nameof(InventoryLines.SalesmanRef);
            string TAX = nameof(InventoryLines.Tax);
            string L─░NE_NR = nameof(InventoryLines.LineNr);
            string COST_TAX1 = nameof(InventoryLines.CostTax1);
            string COST_TAX2 = nameof(InventoryLines.CostTax2);
            string COST_TAX3 = nameof(InventoryLines.CostTax3);
            string CURRENCY_REF = nameof(InventoryLines.CurrencyRef);
            string M─░N─░MUM_STOCK_LEVEL = nameof(InventoryLines.MinimumStockLevel);
            string IS_ACT─░VE = nameof(InventoryLines.IsActive);
            string CREATED_DATE = nameof(InventoryLines.CreatedDate);
            string UN─░T_REF = nameof(InventoryLines.UnitRef);
            string UN─░T_L─░NE_REF = nameof(InventoryLines.UnitLineRef);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(STOCK_F─░CHE_REF)) {
                model.StockFicheRef = values[STOCK_F─░CHE_REF] != null ? Convert.ToInt32(values[STOCK_F─░CHE_REF]) : (int?)null;
            }

            if(values.Contains(IS_CHANGE)) {
                model.IsChange = values[IS_CHANGE] != null ? Convert.ToBoolean(values[IS_CHANGE]) : (bool?)null;
            }

            if(values.Contains(L─░NE_GU─░D)) {
                model.LineGuid = Convert.ToString(values[L─░NE_GU─░D]);
            }

            if(values.Contains(OWNER_REF)) {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if(values.Contains(ACCOUNT_REF)) {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if(values.Contains(AMOUNT)) {
                model.Amount = values[AMOUNT] != null ? Convert.ToDecimal(values[AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(D─░SCOUNT_TYPE)) {
                model.DiscountType = values[D─░SCOUNT_TYPE] != null ? Convert.ToInt32(values[D─░SCOUNT_TYPE]) : (int?)null;
            }

            if(values.Contains(D─░SCOUNT_VALUE)) {
                model.DiscountValue = values[D─░SCOUNT_VALUE] != null ? Convert.ToDecimal(values[D─░SCOUNT_VALUE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(IS_CANCELLED)) {
                model.IsCancelled = values[IS_CANCELLED] != null ? Convert.ToBoolean(values[IS_CANCELLED]) : (bool?)null;
            }

            if(values.Contains(IS_D─░SCOUNTED)) {
                model.IsDiscounted = values[IS_D─░SCOUNTED] != null ? Convert.ToBoolean(values[IS_D─░SCOUNTED]) : (bool?)null;
            }

            if(values.Contains(ITEM_REF)) {
                model.ItemRef = values[ITEM_REF] != null ? Convert.ToInt32(values[ITEM_REF]) : (int?)null;
            }

            if(values.Contains(MOD─░F─░ED_DATE)) {
                model.ModifiedDate = values[MOD─░F─░ED_DATE] != null ? Convert.ToDateTime(values[MOD─░F─░ED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(MOD─░F─░ED_USER)) {
                model.ModifiedUser = values[MOD─░F─░ED_USER] != null ? Convert.ToInt32(values[MOD─░F─░ED_USER]) : (int?)null;
            }

            if(values.Contains(MOVE_TYPE)) {
                model.MoveType = values[MOVE_TYPE] != null ? Convert.ToInt32(values[MOVE_TYPE]) : (int?)null;
            }

            if(values.Contains(PR─░CE)) {
                model.Price = values[PR─░CE] != null ? Convert.ToDecimal(values[PR─░CE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(SALESMAN_REF)) {
                model.SalesmanRef = values[SALESMAN_REF] != null ? Convert.ToInt32(values[SALESMAN_REF]) : (int?)null;
            }

            if(values.Contains(TAX)) {
                model.Tax = values[TAX] != null ? Convert.ToInt32(values[TAX]) : (int?)null;
            }

            if(values.Contains(L─░NE_NR)) {
                model.LineNr = values[L─░NE_NR] != null ? Convert.ToInt32(values[L─░NE_NR]) : (int?)null;
            }

            if(values.Contains(COST_TAX1)) {
                model.CostTax1 = values[COST_TAX1] != null ? Convert.ToInt32(values[COST_TAX1]) : (int?)null;
            }

            if(values.Contains(COST_TAX2)) {
                model.CostTax2 = values[COST_TAX2] != null ? Convert.ToInt32(values[COST_TAX2]) : (int?)null;
            }

            if(values.Contains(COST_TAX3)) {
                model.CostTax3 = values[COST_TAX3] != null ? Convert.ToInt32(values[COST_TAX3]) : (int?)null;
            }

            if(values.Contains(CURRENCY_REF)) {
                model.CurrencyRef = values[CURRENCY_REF] != null ? Convert.ToInt32(values[CURRENCY_REF]) : (int?)null;
            }

            if(values.Contains(M─░N─░MUM_STOCK_LEVEL)) {
                model.MinimumStockLevel = values[M─░N─░MUM_STOCK_LEVEL] != null ? Convert.ToDecimal(values[M─░N─░MUM_STOCK_LEVEL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(IS_ACT─░VE)) {
                model.IsActive = values[IS_ACT─░VE] != null ? Convert.ToBoolean(values[IS_ACT─░VE]) : (bool?)null;
            }

            if(values.Contains(CREATED_DATE)) {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(UN─░T_REF)) {
                model.UnitRef = values[UN─░T_REF] != null ? Convert.ToInt32(values[UN─░T_REF]) : (int?)null;
            }

            if(values.Contains(UN─░T_L─░NE_REF)) {
                model.UnitLineRef = values[UN─░T_L─░NE_REF] != null ? Convert.ToInt32(values[UN─░T_L─░NE_REF]) : (int?)null;
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