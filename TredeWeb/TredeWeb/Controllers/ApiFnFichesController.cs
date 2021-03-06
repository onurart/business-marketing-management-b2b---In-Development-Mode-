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
    public class ApiFnFichesController : Controller
    {
        private TradeDbContext _context;

        public ApiFnFichesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var fnfiches = _context.FnFiches.Select(i => new {
                i.Id,
                i.Description,
                i.FicheNo,
                i.ModifiedDate,
                i.ModifiedUser,
                i.Owner,
                i.LineTotal,
                i.BankFicheRef,
                i.CashFicheRef,
                i.BillFicheRef,
                i.CheckFicheRef,
                i.CreditCardFicheRef,
                i.BarterFicheRef,
                i.IsActive,
                i.CreatedDate,
                i.OrderRef
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fnfiches, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new FnFiches();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnFiches.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.FnFiches.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnFiches.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnFiches.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> FnBankFichesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnBankFiches
                         orderby i.Number
                         select new {
                             Value = i.Id,
                             Text = i.Number
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnBarterFichesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnBarterFiches
                         orderby i.Number
                         select new {
                             Value = i.Id,
                             Text = i.Number
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnCashFichesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnCashFiches
                         orderby i.Number
                         select new {
                             Value = i.Id,
                             Text = i.Number
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnCreditCardFichesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnCreditCardFiches
                         orderby i.Number
                         select new {
                             Value = i.Id,
                             Text = i.Number
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
        public async Task<IActionResult> UsersLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Users
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(FnFiches model, IDictionary values) {
            string ID = nameof(FnFiches.Id);
            string DESCR??PT??ON = nameof(FnFiches.Description);
            string F??CHE_NO = nameof(FnFiches.FicheNo);
            string MOD??F??ED_DATE = nameof(FnFiches.ModifiedDate);
            string MOD??F??ED_USER = nameof(FnFiches.ModifiedUser);
            string OWNER = nameof(FnFiches.Owner);
            string L??NE_TOTAL = nameof(FnFiches.LineTotal);
            string BANK_F??CHE_REF = nameof(FnFiches.BankFicheRef);
            string CASH_F??CHE_REF = nameof(FnFiches.CashFicheRef);
            string B??LL_F??CHE_REF = nameof(FnFiches.BillFicheRef);
            string CHECK_F??CHE_REF = nameof(FnFiches.CheckFicheRef);
            string CRED??T_CARD_F??CHE_REF = nameof(FnFiches.CreditCardFicheRef);
            string BARTER_F??CHE_REF = nameof(FnFiches.BarterFicheRef);
            string IS_ACT??VE = nameof(FnFiches.IsActive);
            string CREATED_DATE = nameof(FnFiches.CreatedDate);
            string ORDER_REF = nameof(FnFiches.OrderRef);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(DESCR??PT??ON)) {
                model.Description = Convert.ToString(values[DESCR??PT??ON]);
            }

            if(values.Contains(F??CHE_NO)) {
                model.FicheNo = Convert.ToString(values[F??CHE_NO]);
            }

            if(values.Contains(MOD??F??ED_DATE)) {
                model.ModifiedDate = values[MOD??F??ED_DATE] != null ? Convert.ToDateTime(values[MOD??F??ED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(MOD??F??ED_USER)) {
                model.ModifiedUser = values[MOD??F??ED_USER] != null ? Convert.ToInt32(values[MOD??F??ED_USER]) : (int?)null;
            }

            if(values.Contains(OWNER)) {
                model.Owner = values[OWNER] != null ? Convert.ToInt32(values[OWNER]) : (int?)null;
            }

            if(values.Contains(L??NE_TOTAL)) {
                model.LineTotal = values[L??NE_TOTAL] != null ? Convert.ToDecimal(values[L??NE_TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(BANK_F??CHE_REF)) {
                model.BankFicheRef = values[BANK_F??CHE_REF] != null ? Convert.ToInt32(values[BANK_F??CHE_REF]) : (int?)null;
            }

            if(values.Contains(CASH_F??CHE_REF)) {
                model.CashFicheRef = values[CASH_F??CHE_REF] != null ? Convert.ToInt32(values[CASH_F??CHE_REF]) : (int?)null;
            }

            if(values.Contains(B??LL_F??CHE_REF)) {
                model.BillFicheRef = values[B??LL_F??CHE_REF] != null ? Convert.ToInt32(values[B??LL_F??CHE_REF]) : (int?)null;
            }

            if(values.Contains(CHECK_F??CHE_REF)) {
                model.CheckFicheRef = values[CHECK_F??CHE_REF] != null ? Convert.ToInt32(values[CHECK_F??CHE_REF]) : (int?)null;
            }

            if(values.Contains(CRED??T_CARD_F??CHE_REF)) {
                model.CreditCardFicheRef = values[CRED??T_CARD_F??CHE_REF] != null ? Convert.ToInt32(values[CRED??T_CARD_F??CHE_REF]) : (int?)null;
            }

            if(values.Contains(BARTER_F??CHE_REF)) {
                model.BarterFicheRef = values[BARTER_F??CHE_REF] != null ? Convert.ToInt32(values[BARTER_F??CHE_REF]) : (int?)null;
            }

            if(values.Contains(IS_ACT??VE)) {
                model.IsActive = values[IS_ACT??VE] != null ? Convert.ToBoolean(values[IS_ACT??VE]) : (bool?)null;
            }

            if(values.Contains(CREATED_DATE)) {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(ORDER_REF)) {
                model.OrderRef = values[ORDER_REF] != null ? Convert.ToInt32(values[ORDER_REF]) : (int?)null;
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