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
    public class ApiFnCashFichesController : Controller
    {
        private TradeDbContext _context;

        public ApiFnCashFichesController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var fncashfiches = _context.FnCashFiches.Select(i => new
            {
                i.Id,
                i.FinanceRef,
                i.Owner,
                i.Type,
                i.Number,
                i.FicheDate,
                i.IsApproved,
                i.ApproveDate,
                i.ReceiptDate,
                i.ReceiptNo,
                i.Description,
                i.CardRef,
                i.IsActive,
                i.CreateDate,
                i.FicheTotal
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fncashfiches, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new FnCashFiches();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnCashFiches.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.FnCashFiches.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnCashFiches.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnCashFiches.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CashCardsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.CashCards
                         orderby i.Code
                         select new
                         {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnFichesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.FnFiches
                         orderby i.Description
                         select new
                         {
                             Value = i.Id,
                             Text = i.Description
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

        private void PopulateModel(FnCashFiches model, IDictionary values)
        {
            string ID = nameof(FnCashFiches.Id);
            string F??NANCE_REF = nameof(FnCashFiches.FinanceRef);
            string OWNER = nameof(FnCashFiches.Owner);
            string TYPE = nameof(FnCashFiches.Type);
            string NUMBER = nameof(FnCashFiches.Number);
            string F??CHE_DATE = nameof(FnCashFiches.FicheDate);
            string IS_APPROVED = nameof(FnCashFiches.IsApproved);
            string APPROVE_DATE = nameof(FnCashFiches.ApproveDate);
            string RECE??PT_DATE = nameof(FnCashFiches.ReceiptDate);
            string RECE??PT_NO = nameof(FnCashFiches.ReceiptNo);
            string DESCR??PT??ON = nameof(FnCashFiches.Description);
            string CARD_REF = nameof(FnCashFiches.CardRef);
            string IS_ACT??VE = nameof(FnCashFiches.IsActive);
            string CREATE_DATE = nameof(FnCashFiches.CreateDate);
            string F??CHE_TOTAL = nameof(FnCashFiches.FicheTotal);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(F??NANCE_REF))
            {
                model.FinanceRef = values[F??NANCE_REF] != null ? Convert.ToInt32(values[F??NANCE_REF]) : (int?)null;
            }

            if (values.Contains(OWNER))
            {
                model.Owner = values[OWNER] != null ? Convert.ToInt32(values[OWNER]) : (int?)null;
            }

            if (values.Contains(TYPE))
            {
                model.Type = values[TYPE] != null ? Convert.ToInt32(values[TYPE]) : (int?)null;
            }

            if (values.Contains(NUMBER))
            {
                model.Number = Convert.ToString(values[NUMBER]);
            }

            if (values.Contains(F??CHE_DATE))
            {
                model.FicheDate = values[F??CHE_DATE] != null ? Convert.ToDateTime(values[F??CHE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(IS_APPROVED))
            {
                model.IsApproved = values[IS_APPROVED] != null ? Convert.ToBoolean(values[IS_APPROVED]) : (bool?)null;
            }

            if (values.Contains(APPROVE_DATE))
            {
                model.ApproveDate = values[APPROVE_DATE] != null ? Convert.ToDateTime(values[APPROVE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(RECE??PT_DATE))
            {
                model.ReceiptDate = values[RECE??PT_DATE] != null ? Convert.ToDateTime(values[RECE??PT_DATE]) : (DateTime?)null;
            }

            if (values.Contains(RECE??PT_NO))
            {
                model.ReceiptNo = Convert.ToString(values[RECE??PT_NO]);
            }

            if (values.Contains(DESCR??PT??ON))
            {
                model.Description = Convert.ToString(values[DESCR??PT??ON]);
            }

            if (values.Contains(CARD_REF))
            {
                model.CardRef = values[CARD_REF] != null ? Convert.ToInt32(values[CARD_REF]) : (int?)null;
            }

            if (values.Contains(IS_ACT??VE))
            {
                model.IsActive = values[IS_ACT??VE] != null ? Convert.ToBoolean(values[IS_ACT??VE]) : (bool?)null;
            }

            if (values.Contains(CREATE_DATE))
            {
                model.CreateDate = values[CREATE_DATE] != null ? Convert.ToDateTime(values[CREATE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(F??CHE_TOTAL))
            {
                model.FicheTotal = values[F??CHE_TOTAL] != null ? Convert.ToDecimal(values[F??CHE_TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
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