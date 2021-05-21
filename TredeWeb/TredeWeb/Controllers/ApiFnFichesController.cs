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
            string DESCRİPTİON = nameof(FnFiches.Description);
            string FİCHE_NO = nameof(FnFiches.FicheNo);
            string MODİFİED_DATE = nameof(FnFiches.ModifiedDate);
            string MODİFİED_USER = nameof(FnFiches.ModifiedUser);
            string OWNER = nameof(FnFiches.Owner);
            string LİNE_TOTAL = nameof(FnFiches.LineTotal);
            string BANK_FİCHE_REF = nameof(FnFiches.BankFicheRef);
            string CASH_FİCHE_REF = nameof(FnFiches.CashFicheRef);
            string BİLL_FİCHE_REF = nameof(FnFiches.BillFicheRef);
            string CHECK_FİCHE_REF = nameof(FnFiches.CheckFicheRef);
            string CREDİT_CARD_FİCHE_REF = nameof(FnFiches.CreditCardFicheRef);
            string BARTER_FİCHE_REF = nameof(FnFiches.BarterFicheRef);
            string IS_ACTİVE = nameof(FnFiches.IsActive);
            string CREATED_DATE = nameof(FnFiches.CreatedDate);
            string ORDER_REF = nameof(FnFiches.OrderRef);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(DESCRİPTİON)) {
                model.Description = Convert.ToString(values[DESCRİPTİON]);
            }

            if(values.Contains(FİCHE_NO)) {
                model.FicheNo = Convert.ToString(values[FİCHE_NO]);
            }

            if(values.Contains(MODİFİED_DATE)) {
                model.ModifiedDate = values[MODİFİED_DATE] != null ? Convert.ToDateTime(values[MODİFİED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(MODİFİED_USER)) {
                model.ModifiedUser = values[MODİFİED_USER] != null ? Convert.ToInt32(values[MODİFİED_USER]) : (int?)null;
            }

            if(values.Contains(OWNER)) {
                model.Owner = values[OWNER] != null ? Convert.ToInt32(values[OWNER]) : (int?)null;
            }

            if(values.Contains(LİNE_TOTAL)) {
                model.LineTotal = values[LİNE_TOTAL] != null ? Convert.ToDecimal(values[LİNE_TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(BANK_FİCHE_REF)) {
                model.BankFicheRef = values[BANK_FİCHE_REF] != null ? Convert.ToInt32(values[BANK_FİCHE_REF]) : (int?)null;
            }

            if(values.Contains(CASH_FİCHE_REF)) {
                model.CashFicheRef = values[CASH_FİCHE_REF] != null ? Convert.ToInt32(values[CASH_FİCHE_REF]) : (int?)null;
            }

            if(values.Contains(BİLL_FİCHE_REF)) {
                model.BillFicheRef = values[BİLL_FİCHE_REF] != null ? Convert.ToInt32(values[BİLL_FİCHE_REF]) : (int?)null;
            }

            if(values.Contains(CHECK_FİCHE_REF)) {
                model.CheckFicheRef = values[CHECK_FİCHE_REF] != null ? Convert.ToInt32(values[CHECK_FİCHE_REF]) : (int?)null;
            }

            if(values.Contains(CREDİT_CARD_FİCHE_REF)) {
                model.CreditCardFicheRef = values[CREDİT_CARD_FİCHE_REF] != null ? Convert.ToInt32(values[CREDİT_CARD_FİCHE_REF]) : (int?)null;
            }

            if(values.Contains(BARTER_FİCHE_REF)) {
                model.BarterFicheRef = values[BARTER_FİCHE_REF] != null ? Convert.ToInt32(values[BARTER_FİCHE_REF]) : (int?)null;
            }

            if(values.Contains(IS_ACTİVE)) {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
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