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
    public class ApiFnCsFichesController : Controller
    {
        private TradeDbContext _context;

        public ApiFnCsFichesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var fncsfiches = _context.FnCsFiches.Select(i => new {
                i.Id,
                i.ApproveDate,
                i.CsFicheType,
                i.Description,
                i.FinanceRef,
                i.IsApproved,
                i.Number,
                i.Owner,
                i.FicheDate,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(fncsfiches, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new FnCsFiches();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.FnCsFiches.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.FnCsFiches.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.FnCsFiches.FirstOrDefaultAsync(item => item.Id == key);

            _context.FnCsFiches.Remove(model);
            await _context.SaveChangesAsync();
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
        public async Task<IActionResult> UsersLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Users
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(FnCsFiches model, IDictionary values) {
            string ID = nameof(FnCsFiches.Id);
            string APPROVE_DATE = nameof(FnCsFiches.ApproveDate);
            string CS_F??CHE_TYPE = nameof(FnCsFiches.CsFicheType);
            string DESCR??PT??ON = nameof(FnCsFiches.Description);
            string F??NANCE_REF = nameof(FnCsFiches.FinanceRef);
            string IS_APPROVED = nameof(FnCsFiches.IsApproved);
            string NUMBER = nameof(FnCsFiches.Number);
            string OWNER = nameof(FnCsFiches.Owner);
            string F??CHE_DATE = nameof(FnCsFiches.FicheDate);
            string IS_ACT??VE = nameof(FnCsFiches.IsActive);
            string CREATED_DATE = nameof(FnCsFiches.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(APPROVE_DATE)) {
                model.ApproveDate = values[APPROVE_DATE] != null ? Convert.ToDateTime(values[APPROVE_DATE]) : (DateTime?)null;
            }

            if(values.Contains(CS_F??CHE_TYPE)) {
                model.CsFicheType = values[CS_F??CHE_TYPE] != null ? Convert.ToInt32(values[CS_F??CHE_TYPE]) : (int?)null;
            }

            if(values.Contains(DESCR??PT??ON)) {
                model.Description = Convert.ToString(values[DESCR??PT??ON]);
            }

            if(values.Contains(F??NANCE_REF)) {
                model.FinanceRef = values[F??NANCE_REF] != null ? Convert.ToInt32(values[F??NANCE_REF]) : (int?)null;
            }

            if(values.Contains(IS_APPROVED)) {
                model.IsApproved = values[IS_APPROVED] != null ? Convert.ToBoolean(values[IS_APPROVED]) : (bool?)null;
            }

            if(values.Contains(NUMBER)) {
                model.Number = Convert.ToString(values[NUMBER]);
            }

            if(values.Contains(OWNER)) {
                model.Owner = values[OWNER] != null ? Convert.ToInt32(values[OWNER]) : (int?)null;
            }

            if(values.Contains(F??CHE_DATE)) {
                model.FicheDate = values[F??CHE_DATE] != null ? Convert.ToDateTime(values[F??CHE_DATE]) : (DateTime?)null;
            }

            if(values.Contains(IS_ACT??VE)) {
                model.IsActive = values[IS_ACT??VE] != null ? Convert.ToBoolean(values[IS_ACT??VE]) : (bool?)null;
            }

            if(values.Contains(CREATED_DATE)) {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
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