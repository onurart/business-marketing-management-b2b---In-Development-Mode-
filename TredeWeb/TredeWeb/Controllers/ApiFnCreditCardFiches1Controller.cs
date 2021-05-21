using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApiFnCreditCardFiches1Controller : Controller
    {
        private TradeDbContext _context;

        public ApiFnCreditCardFiches1Controller(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var fncreditcardfiches = _context.FnCreditCardFiches.Select(i => new
            {
                i.Id,
                i.FinanceRef,
                i.ApproveDate,
                i.IsApproved,
                i.Number,
                i.Owner,
                i.FicheDate,
                i.Type,
                i.Order,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fncreditcardfiches, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new FnCreditCardFiches();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnCreditCardFiches.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.FnCreditCardFiches.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnCreditCardFiches.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnCreditCardFiches.Remove(model);
            await _context.SaveChangesAsync();
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

        private void PopulateModel(FnCreditCardFiches model, IDictionary values)
        {
            string ID = nameof(FnCreditCardFiches.Id);
            string FİNANCE_REF = nameof(FnCreditCardFiches.FinanceRef);
            string APPROVE_DATE = nameof(FnCreditCardFiches.ApproveDate);
            string IS_APPROVED = nameof(FnCreditCardFiches.IsApproved);
            string NUMBER = nameof(FnCreditCardFiches.Number);
            string OWNER = nameof(FnCreditCardFiches.Owner);
            string FİCHE_DATE = nameof(FnCreditCardFiches.FicheDate);
            string TYPE = nameof(FnCreditCardFiches.Type);
            string ORDER = nameof(FnCreditCardFiches.Order);
            string IS_ACTİVE = nameof(FnCreditCardFiches.IsActive);
            string CREATED_DATE = nameof(FnCreditCardFiches.CreatedDate);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(FİNANCE_REF))
            {
                model.FinanceRef = Convert.ToInt32(values[FİNANCE_REF]);
            }

            if (values.Contains(APPROVE_DATE))
            {
                model.ApproveDate = Convert.ToDateTime(values[APPROVE_DATE]);
            }

            if (values.Contains(IS_APPROVED))
            {
                model.IsApproved = Convert.ToBoolean(values[IS_APPROVED]);
            }

            if (values.Contains(NUMBER))
            {
                model.Number = Convert.ToString(values[NUMBER]);
            }

            if (values.Contains(OWNER))
            {
                model.Owner = Convert.ToInt32(values[OWNER]);
            }

            if (values.Contains(FİCHE_DATE))
            {
                model.FicheDate = Convert.ToDateTime(values[FİCHE_DATE]);
            }

            if (values.Contains(TYPE))
            {
                model.Type = Convert.ToInt32(values[TYPE]);
            }

            if (values.Contains(ORDER))
            {
                model.Order = values[ORDER] != null ? Convert.ToInt32(values[ORDER]) : (int?)null;
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = Convert.ToBoolean(values[IS_ACTİVE]);
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = Convert.ToDateTime(values[CREATED_DATE]);
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