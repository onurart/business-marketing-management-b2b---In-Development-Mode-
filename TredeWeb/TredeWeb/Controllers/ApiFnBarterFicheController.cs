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
    public class ApiFnBarterFicheController : Controller
    {
        private TradeDbContext _context;

        public ApiFnBarterFicheController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var fnbarterfiches = _context.FnBarterFiches.Select(i => new
            {
                i.Id,
                i.FinanceRef,
                i.ApproveDate,
                i.FicheDate,
                i.IsApproved,
                i.Number,
                i.Owner,
                i.IsActive,
                i.CreateDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fnbarterfiches, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new FnBarterFiches();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnBarterFiches.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.FnBarterFiches.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnBarterFiches.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnBarterFiches.Remove(model);
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

        private void PopulateModel(FnBarterFiches model, IDictionary values)
        {
            string ID = nameof(FnBarterFiches.Id);
            string FİNANCE_REF = nameof(FnBarterFiches.FinanceRef);
            string APPROVE_DATE = nameof(FnBarterFiches.ApproveDate);
            string FİCHE_DATE = nameof(FnBarterFiches.FicheDate);
            string IS_APPROVED = nameof(FnBarterFiches.IsApproved);
            string NUMBER = nameof(FnBarterFiches.Number);
            string OWNER = nameof(FnBarterFiches.Owner);
            string IS_ACTİVE = nameof(FnBarterFiches.IsActive);
            string CREATE_DATE = nameof(FnBarterFiches.CreateDate);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(FİNANCE_REF))
            {
                model.FinanceRef = values[FİNANCE_REF] != null ? Convert.ToInt32(values[FİNANCE_REF]) : (int?)null;
            }

            if (values.Contains(APPROVE_DATE))
            {
                model.ApproveDate = values[APPROVE_DATE] != null ? Convert.ToDateTime(values[APPROVE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(FİCHE_DATE))
            {
                model.FicheDate = values[FİCHE_DATE] != null ? Convert.ToDateTime(values[FİCHE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(IS_APPROVED))
            {
                model.IsApproved = values[IS_APPROVED] != null ? Convert.ToBoolean(values[IS_APPROVED]) : (bool?)null;
            }

            if (values.Contains(NUMBER))
            {
                model.Number = Convert.ToString(values[NUMBER]);
            }

            if (values.Contains(OWNER))
            {
                model.Owner = values[OWNER] != null ? Convert.ToInt32(values[OWNER]) : (int?)null;
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if (values.Contains(CREATE_DATE))
            {
                model.CreateDate = values[CREATE_DATE] != null ? Convert.ToDateTime(values[CREATE_DATE]) : (DateTime?)null;
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