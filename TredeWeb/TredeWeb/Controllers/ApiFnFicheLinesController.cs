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
    public class ApiFnFicheLinesController : Controller
    {
        private TradeDbContext _context;

        public ApiFnFicheLinesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var fnfichelines = _context.FnFicheLines.Select(i => new {
                i.Id,
                i.Collect,
                i.ModifiedDate,
                i.ModifiedUser,
                i.Currency,
                i.LineNr,
                i.FinanceRef,
                i.Amount,
                i.Tax,
                i.VatBase,
                i.Total,
                i.BankRef,
                i.BarterRef,
                i.CsRef,
                i.CashRef,
                i.CreditCardRef,
                i.Sign,
                i.ModulEnr,
                i.AccountRef,
                i.Cost,
                i.CardRef,
                i.IsActive,
                i.CreatedDate,
                i.CostRef,
                i.OrderRef
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fnfichelines, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new FnFicheLines();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnFicheLines.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.FnFicheLines.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnFicheLines.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnFicheLines.Remove(model);
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
        public async Task<IActionResult> FnBankLinesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnBankLines
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnBarterLinesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnBarterLines
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CashCardsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.CashCards
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnCashLinesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnCashLines
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CostsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Costs
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
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
        public async Task<IActionResult> FnFichesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnFiches
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> OrderLinesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.OrderLines
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(FnFicheLines model, IDictionary values) {
            string ID = nameof(FnFicheLines.Id);
            string COLLECT = nameof(FnFicheLines.Collect);
            string MODİFİED_DATE = nameof(FnFicheLines.ModifiedDate);
            string MODİFİED_USER = nameof(FnFicheLines.ModifiedUser);
            string CURRENCY = nameof(FnFicheLines.Currency);
            string LİNE_NR = nameof(FnFicheLines.LineNr);
            string FİNANCE_REF = nameof(FnFicheLines.FinanceRef);
            string AMOUNT = nameof(FnFicheLines.Amount);
            string TAX = nameof(FnFicheLines.Tax);
            string VAT_BASE = nameof(FnFicheLines.VatBase);
            string TOTAL = nameof(FnFicheLines.Total);
            string BANK_REF = nameof(FnFicheLines.BankRef);
            string BARTER_REF = nameof(FnFicheLines.BarterRef);
            string CS_REF = nameof(FnFicheLines.CsRef);
            string CASH_REF = nameof(FnFicheLines.CashRef);
            string CREDİT_CARD_REF = nameof(FnFicheLines.CreditCardRef);
            string SİGN = nameof(FnFicheLines.Sign);
            string MODUL_ENR = nameof(FnFicheLines.ModulEnr);
            string ACCOUNT_REF = nameof(FnFicheLines.AccountRef);
            string COST = nameof(FnFicheLines.Cost);
            string CARD_REF = nameof(FnFicheLines.CardRef);
            string IS_ACTİVE = nameof(FnFicheLines.IsActive);
            string CREATED_DATE = nameof(FnFicheLines.CreatedDate);
            string COST_REF = nameof(FnFicheLines.CostRef);
            string ORDER_REF = nameof(FnFicheLines.OrderRef);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(COLLECT)) {
                model.Collect = values[COLLECT] != null ? Convert.ToInt32(values[COLLECT]) : (int?)null;
            }

            if(values.Contains(MODİFİED_DATE)) {
                model.ModifiedDate = values[MODİFİED_DATE] != null ? Convert.ToDateTime(values[MODİFİED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(MODİFİED_USER)) {
                model.ModifiedUser = values[MODİFİED_USER] != null ? Convert.ToInt32(values[MODİFİED_USER]) : (int?)null;
            }

            if(values.Contains(CURRENCY)) {
                model.Currency = values[CURRENCY] != null ? Convert.ToInt32(values[CURRENCY]) : (int?)null;
            }

            if(values.Contains(LİNE_NR)) {
                model.LineNr = values[LİNE_NR] != null ? Convert.ToInt32(values[LİNE_NR]) : (int?)null;
            }

            if(values.Contains(FİNANCE_REF)) {
                model.FinanceRef = values[FİNANCE_REF] != null ? Convert.ToInt32(values[FİNANCE_REF]) : (int?)null;
            }

            if(values.Contains(AMOUNT)) {
                model.Amount = values[AMOUNT] != null ? Convert.ToDecimal(values[AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(TAX)) {
                model.Tax = values[TAX] != null ? Convert.ToDecimal(values[TAX], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(VAT_BASE)) {
                model.VatBase = values[VAT_BASE] != null ? Convert.ToDecimal(values[VAT_BASE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(TOTAL)) {
                model.Total = values[TOTAL] != null ? Convert.ToDecimal(values[TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(BANK_REF)) {
                model.BankRef = values[BANK_REF] != null ? Convert.ToInt32(values[BANK_REF]) : (int?)null;
            }

            if(values.Contains(BARTER_REF)) {
                model.BarterRef = values[BARTER_REF] != null ? Convert.ToInt32(values[BARTER_REF]) : (int?)null;
            }

            if(values.Contains(CS_REF)) {
                model.CsRef = values[CS_REF] != null ? Convert.ToInt32(values[CS_REF]) : (int?)null;
            }

            if(values.Contains(CASH_REF)) {
                model.CashRef = values[CASH_REF] != null ? Convert.ToInt32(values[CASH_REF]) : (int?)null;
            }

            if(values.Contains(CREDİT_CARD_REF)) {
                model.CreditCardRef = values[CREDİT_CARD_REF] != null ? Convert.ToInt32(values[CREDİT_CARD_REF]) : (int?)null;
            }

            if(values.Contains(SİGN)) {
                model.Sign = values[SİGN] != null ? Convert.ToInt32(values[SİGN]) : (int?)null;
            }

            if(values.Contains(MODUL_ENR)) {
                model.ModulEnr = values[MODUL_ENR] != null ? Convert.ToInt32(values[MODUL_ENR]) : (int?)null;
            }

            if(values.Contains(ACCOUNT_REF)) {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if(values.Contains(COST)) {
                model.Cost = values[COST] != null ? Convert.ToDecimal(values[COST], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(CARD_REF)) {
                model.CardRef = values[CARD_REF] != null ? Convert.ToInt32(values[CARD_REF]) : (int?)null;
            }

            if(values.Contains(IS_ACTİVE)) {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if(values.Contains(CREATED_DATE)) {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(COST_REF)) {
                model.CostRef = values[COST_REF] != null ? Convert.ToInt32(values[COST_REF]) : (int?)null;
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