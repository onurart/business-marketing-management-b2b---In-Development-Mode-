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
    public class ApiSectionsController : Controller
    {
        private TradeDbContext _context;

        public ApiSectionsController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var sections = _context.Sections.Select(i => new {
                i.Id,
                i.Code,
                i.Description,
                i.SectionName,
                i.ParentSection,
                i.WorkPlace,
                i.IsActive,
                i.CreadtedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(sections, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Sections();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Sections.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Sections.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Sections.FirstOrDefaultAsync(item => item.Id == key);

            _context.Sections.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> SectionsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Sections
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> WorkPlacesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.WorkPlaces
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Sections model, IDictionary values) {
            string ID = nameof(Sections.Id);
            string CODE = nameof(Sections.Code);
            string DESCRİPTİON = nameof(Sections.Description);
            string SECTİON_NAME = nameof(Sections.SectionName);
            string PARENT_SECTİON = nameof(Sections.ParentSection);
            string WORK_PLACE = nameof(Sections.WorkPlace);
            string IS_ACTİVE = nameof(Sections.IsActive);
            string CREADTED_DATE = nameof(Sections.CreadtedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(CODE)) {
                model.Code = Convert.ToString(values[CODE]);
            }

            if(values.Contains(DESCRİPTİON)) {
                model.Description = Convert.ToString(values[DESCRİPTİON]);
            }

            if(values.Contains(SECTİON_NAME)) {
                model.SectionName = Convert.ToString(values[SECTİON_NAME]);
            }

            if(values.Contains(PARENT_SECTİON)) {
                model.ParentSection = values[PARENT_SECTİON] != null ? Convert.ToInt32(values[PARENT_SECTİON]) : (int?)null;
            }

            if(values.Contains(WORK_PLACE)) {
                model.WorkPlace = values[WORK_PLACE] != null ? Convert.ToInt32(values[WORK_PLACE]) : (int?)null;
            }

            if(values.Contains(IS_ACTİVE)) {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if(values.Contains(CREADTED_DATE)) {
                model.CreadtedDate = values[CREADTED_DATE] != null ? Convert.ToDateTime(values[CREADTED_DATE]) : (DateTime?)null;
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