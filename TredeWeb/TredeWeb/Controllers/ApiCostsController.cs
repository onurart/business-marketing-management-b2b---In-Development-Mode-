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
    public class ApiCostsController : Controller
    {
        private TradeDbContext _context;

        public ApiCostsController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var costs = _context.Costs.Select(i => new
            {
                i.Id,
                i.Type,
                i.Description,
                i.Number,
                i.OwnerRef,
                i.CostTotal,
                i.CostDate,
                i.BankRef,
                i.CsRef,
                i.CashRef,
                i.AccountRef,
                i.IsApproved,
                i.ApproveDate,
                i.IsActive,
                i.CreatedDate,
                i.CreditCardRef
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(costs, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Costs();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Costs.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Costs.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Costs.FirstOrDefaultAsync(item => item.Id == key);

            _context.Costs.Remove(model);
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
        public async Task<IActionResult> FnBankLinesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.FnBankLines
                         orderby i.Description
                         select new
                         {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnCreditCardLinesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.FnCreditCardLines
                         orderby i.Description
                         select new
                         {
                             Value = i.Id,
                             Text = i.Description
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnCsLinesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.FnCsLines
                         orderby i.Title
                         select new
                         {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> UsersLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Users
                         orderby i.Title
                         select new
                         {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Costs model, IDictionary values)
        {
            string ID = nameof(Costs.Id);
            string TYPE = nameof(Costs.Type);
            string DESCRİPTİON = nameof(Costs.Description);
            string NUMBER = nameof(Costs.Number);
            string OWNER_REF = nameof(Costs.OwnerRef);
            string COST_TOTAL = nameof(Costs.CostTotal);
            string COST_DATE = nameof(Costs.CostDate);
            string BANK_REF = nameof(Costs.BankRef);
            string CS_REF = nameof(Costs.CsRef);
            string CASH_REF = nameof(Costs.CashRef);
            string ACCOUNT_REF = nameof(Costs.AccountRef);
            string IS_APPROVED = nameof(Costs.IsApproved);
            string APPROVE_DATE = nameof(Costs.ApproveDate);
            string IS_ACTİVE = nameof(Costs.IsActive);
            string CREATED_DATE = nameof(Costs.CreatedDate);
            string CREDİT_CARD_REF = nameof(Costs.CreditCardRef);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(TYPE))
            {
                model.Type = values[TYPE] != null ? Convert.ToInt32(values[TYPE]) : (int?)null;
            }

            if (values.Contains(DESCRİPTİON))
            {
                model.Description = Convert.ToString(values[DESCRİPTİON]);
            }

            if (values.Contains(NUMBER))
            {
                model.Number = Convert.ToString(values[NUMBER]);
            }

            if (values.Contains(OWNER_REF))
            {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if (values.Contains(COST_TOTAL))
            {
                model.CostTotal = values[COST_TOTAL] != null ? Convert.ToDouble(values[COST_TOTAL], CultureInfo.InvariantCulture) : (double?)null;
            }

            if (values.Contains(COST_DATE))
            {
                model.CostDate = values[COST_DATE] != null ? Convert.ToDateTime(values[COST_DATE]) : (DateTime?)null;
            }

            if (values.Contains(BANK_REF))
            {
                model.BankRef = values[BANK_REF] != null ? Convert.ToInt32(values[BANK_REF]) : (int?)null;
            }

            if (values.Contains(CS_REF))
            {
                model.CsRef = values[CS_REF] != null ? Convert.ToInt32(values[CS_REF]) : (int?)null;
            }

            if (values.Contains(CASH_REF))
            {
                model.CashRef = values[CASH_REF] != null ? Convert.ToInt32(values[CASH_REF]) : (int?)null;
            }

            if (values.Contains(ACCOUNT_REF))
            {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if (values.Contains(IS_APPROVED))
            {
                model.IsApproved = values[IS_APPROVED] != null ? Convert.ToBoolean(values[IS_APPROVED]) : (bool?)null;
            }

            if (values.Contains(APPROVE_DATE))
            {
                model.ApproveDate = values[APPROVE_DATE] != null ? Convert.ToDateTime(values[APPROVE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if (values.Contains(CREDİT_CARD_REF))
            {
                model.CreditCardRef = values[CREDİT_CARD_REF] != null ? Convert.ToInt32(values[CREDİT_CARD_REF]) : (int?)null;
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