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
    public class ApiPriceListsController : Controller
    {
        private TradeDbContext _context;

        public ApiPriceListsController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var pricelists = _context.PriceLists.Select(i => new {
                i.Id,
                i.Discount,
                i.DiscountType,
                i.DiscountValue,
                i.IsDefault,
                i.IsDiscount,
                i.OwnerRef,
                i.Price,
                i.Specode,
                i.Tax,
                i.CurrencyRef,
                i.IsActive,
                i.CreatedDate,
                i.ItemRef
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(pricelists, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new PriceLists();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.PriceLists.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.PriceLists.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.PriceLists.FirstOrDefaultAsync(item => item.Id == key);

            _context.PriceLists.Remove(model);
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

        private void PopulateModel(PriceLists model, IDictionary values) {
            string ID = nameof(PriceLists.Id);
            string DİSCOUNT = nameof(PriceLists.Discount);
            string DİSCOUNT_TYPE = nameof(PriceLists.DiscountType);
            string DİSCOUNT_VALUE = nameof(PriceLists.DiscountValue);
            string IS_DEFAULT = nameof(PriceLists.IsDefault);
            string IS_DİSCOUNT = nameof(PriceLists.IsDiscount);
            string OWNER_REF = nameof(PriceLists.OwnerRef);
            string PRİCE = nameof(PriceLists.Price);
            string SPECODE = nameof(PriceLists.Specode);
            string TAX = nameof(PriceLists.Tax);
            string CURRENCY_REF = nameof(PriceLists.CurrencyRef);
            string IS_ACTİVE = nameof(PriceLists.IsActive);
            string CREATED_DATE = nameof(PriceLists.CreatedDate);
            string ITEM_REF = nameof(PriceLists.ItemRef);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(DİSCOUNT)) {
                model.Discount = values[DİSCOUNT] != null ? Convert.ToDecimal(values[DİSCOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(DİSCOUNT_TYPE)) {
                model.DiscountType = values[DİSCOUNT_TYPE] != null ? Convert.ToInt32(values[DİSCOUNT_TYPE]) : (int?)null;
            }

            if(values.Contains(DİSCOUNT_VALUE)) {
                model.DiscountValue = values[DİSCOUNT_VALUE] != null ? Convert.ToDecimal(values[DİSCOUNT_VALUE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(IS_DEFAULT)) {
                model.IsDefault = values[IS_DEFAULT] != null ? Convert.ToBoolean(values[IS_DEFAULT]) : (bool?)null;
            }

            if(values.Contains(IS_DİSCOUNT)) {
                model.IsDiscount = values[IS_DİSCOUNT] != null ? Convert.ToBoolean(values[IS_DİSCOUNT]) : (bool?)null;
            }

            if(values.Contains(OWNER_REF)) {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if(values.Contains(PRİCE)) {
                model.Price = values[PRİCE] != null ? Convert.ToDecimal(values[PRİCE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(SPECODE)) {
                model.Specode = Convert.ToString(values[SPECODE]);
            }

            if(values.Contains(TAX)) {
                model.Tax = values[TAX] != null ? Convert.ToDecimal(values[TAX], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(CURRENCY_REF)) {
                model.CurrencyRef = values[CURRENCY_REF] != null ? Convert.ToInt32(values[CURRENCY_REF]) : (int?)null;
            }

            if(values.Contains(IS_ACTİVE)) {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if(values.Contains(CREATED_DATE)) {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(ITEM_REF)) {
                model.ItemRef = values[ITEM_REF] != null ? Convert.ToInt32(values[ITEM_REF]) : (int?)null;
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