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
    public class ApiFnCreditCardLinesController : Controller
    {
        private TradeDbContext _context;

        public ApiFnCreditCardLinesController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var fncreditcardlines = _context.FnCreditCardLines.Select(i => new
            {
                i.Id,
                i.FinanceLineRef,
                i.FicheRef,
                i.LineDate,
                i.LineNr,
                i.Sign,
                i.Total,
                i.Currency,
                i.Description,
                i.AccountRef,
                i.CardNo,
                i.PosNo,
                i.IsActive,
                i.CreatedDate,
                i.Cost,
                i.CostRef
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fncreditcardlines, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new FnCreditCardLines();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnCreditCardLines.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.FnCreditCardLines.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnCreditCardLines.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnCreditCardLines.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> AccountsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Accounts
                         orderby i.Title
                         select new
                         {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CostsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Costs
                         orderby i.Description
                         select new
                         {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CurrenciesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Currencies
                         orderby i.CurrType
                         select new
                         {
                             Value = i.Id,
                             Text = i.CurrType
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnCreditCardFichesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.FnCreditCardFiches
                         orderby i.Number
                         select new
                         {
                             Value = i.Id,
                             Text = i.Number
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnFicheLinesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.FnFicheLines
                         orderby i.Collect
                         select new
                         {
                             Value = i.Id,
                             Text = i.Collect
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(FnCreditCardLines model, IDictionary values)
        {
            string ID = nameof(FnCreditCardLines.Id);
            string FİNANCE_LİNE_REF = nameof(FnCreditCardLines.FinanceLineRef);
            string FİCHE_REF = nameof(FnCreditCardLines.FicheRef);
            string LİNE_DATE = nameof(FnCreditCardLines.LineDate);
            string LİNE_NR = nameof(FnCreditCardLines.LineNr);
            string SİGN = nameof(FnCreditCardLines.Sign);
            string TOTAL = nameof(FnCreditCardLines.Total);
            string CURRENCY = nameof(FnCreditCardLines.Currency);
            string DESCRİPTİON = nameof(FnCreditCardLines.Description);
            string ACCOUNT_REF = nameof(FnCreditCardLines.AccountRef);
            string CARD_NO = nameof(FnCreditCardLines.CardNo);
            string POS_NO = nameof(FnCreditCardLines.PosNo);
            string IS_ACTİVE = nameof(FnCreditCardLines.IsActive);
            string CREATED_DATE = nameof(FnCreditCardLines.CreatedDate);
            string COST = nameof(FnCreditCardLines.Cost);
            string COST_REF = nameof(FnCreditCardLines.CostRef);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(FİNANCE_LİNE_REF))
            {
                model.FinanceLineRef = values[FİNANCE_LİNE_REF] != null ? Convert.ToInt32(values[FİNANCE_LİNE_REF]) : (int?)null;
            }

            if (values.Contains(FİCHE_REF))
            {
                model.FicheRef = values[FİCHE_REF] != null ? Convert.ToInt32(values[FİCHE_REF]) : (int?)null;
            }

            if (values.Contains(LİNE_DATE))
            {
                model.LineDate = values[LİNE_DATE] != null ? Convert.ToDateTime(values[LİNE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(LİNE_NR))
            {
                model.LineNr = values[LİNE_NR] != null ? Convert.ToInt32(values[LİNE_NR]) : (int?)null;
            }

            if (values.Contains(SİGN))
            {
                model.Sign = values[SİGN] != null ? Convert.ToInt32(values[SİGN]) : (int?)null;
            }

            if (values.Contains(TOTAL))
            {
                model.Total = values[TOTAL] != null ? Convert.ToDecimal(values[TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if (values.Contains(CURRENCY))
            {
                model.Currency = values[CURRENCY] != null ? Convert.ToInt32(values[CURRENCY]) : (int?)null;
            }

            if (values.Contains(DESCRİPTİON))
            {
                model.Description = Convert.ToString(values[DESCRİPTİON]);
            }

            if (values.Contains(ACCOUNT_REF))
            {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if (values.Contains(CARD_NO))
            {
                model.CardNo = Convert.ToString(values[CARD_NO]);
            }

            if (values.Contains(POS_NO))
            {
                model.PosNo = Convert.ToString(values[POS_NO]);
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if (values.Contains(COST))
            {
                model.Cost = values[COST] != null ? Convert.ToDecimal(values[COST], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if (values.Contains(COST_REF))
            {
                model.CostRef = values[COST_REF] != null ? Convert.ToInt32(values[COST_REF]) : (int?)null;
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