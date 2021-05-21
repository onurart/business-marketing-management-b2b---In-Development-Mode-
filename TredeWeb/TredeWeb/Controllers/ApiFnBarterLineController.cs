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
    public class ApiFnBarterLineController : Controller
    {
        private TradeDbContext _context;

        public ApiFnBarterLineController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var fnbarterlines = _context.FnBarterLines.Select(i => new
            {
                i.Id,
                i.FinanceLineRef,
                i.FicheRef,
                i.AccountRef,
                i.Currency,
                i.Description,
                i.LineDate,
                i.LineNr,
                i.Sign,
                i.Amount,
                i.Type,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fnbarterlines, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new FnBarterLines();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnBarterLines.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.FnBarterLines.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnBarterLines.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnBarterLines.Remove(model);
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
        public async Task<IActionResult> FnBarterFichesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.FnBarterFiches
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

        private void PopulateModel(FnBarterLines model, IDictionary values)
        {
            string ID = nameof(FnBarterLines.Id);
            string FİNANCE_LİNE_REF = nameof(FnBarterLines.FinanceLineRef);
            string FİCHE_REF = nameof(FnBarterLines.FicheRef);
            string ACCOUNT_REF = nameof(FnBarterLines.AccountRef);
            string CURRENCY = nameof(FnBarterLines.Currency);
            string DESCRİPTİON = nameof(FnBarterLines.Description);
            string LİNE_DATE = nameof(FnBarterLines.LineDate);
            string LİNE_NR = nameof(FnBarterLines.LineNr);
            string SİGN = nameof(FnBarterLines.Sign);
            string AMOUNT = nameof(FnBarterLines.Amount);
            string TYPE = nameof(FnBarterLines.Type);
            string IS_ACTİVE = nameof(FnBarterLines.IsActive);
            string CREATED_DATE = nameof(FnBarterLines.CreatedDate);

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

            if (values.Contains(ACCOUNT_REF))
            {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if (values.Contains(CURRENCY))
            {
                model.Currency = values[CURRENCY] != null ? Convert.ToInt32(values[CURRENCY]) : (int?)null;
            }

            if (values.Contains(DESCRİPTİON))
            {
                model.Description = Convert.ToString(values[DESCRİPTİON]);
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
                model.Sign = values[SİGN] != null ? Convert.ToInt16(values[SİGN]) : (short?)null;
            }

            if (values.Contains(AMOUNT))
            {
                model.Amount = values[AMOUNT] != null ? Convert.ToDecimal(values[AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if (values.Contains(TYPE))
            {
                model.Type = values[TYPE] != null ? Convert.ToInt32(values[TYPE]) : (int?)null;
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