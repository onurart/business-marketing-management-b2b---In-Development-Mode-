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
    public class ApiInventoriesController : Controller
    {
        private TradeDbContext _context;

        public ApiInventoriesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var ınventories = _context.Inventories.Select(i => new {
                i.Id,
                i.FicheDate,
                i.FicheTotal,
                i.Number,
                i.OwnerRef,
                i.Section,
                i.Specode,
                i.WareHouse,
                i.WorkPlace,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(ınventories, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Inventories();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Inventories.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Inventories.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Inventories.FirstOrDefaultAsync(item => item.Id == key);

            _context.Inventories.Remove(model);
            await _context.SaveChangesAsync();
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
        public async Task<IActionResult> WareHousesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.WareHouses
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

        private void PopulateModel(Inventories model, IDictionary values) {
            string ID = nameof(Inventories.Id);
            string FİCHE_DATE = nameof(Inventories.FicheDate);
            string FİCHE_TOTAL = nameof(Inventories.FicheTotal);
            string NUMBER = nameof(Inventories.Number);
            string OWNER_REF = nameof(Inventories.OwnerRef);
            string SECTİON = nameof(Inventories.Section);
            string SPECODE = nameof(Inventories.Specode);
            string WARE_HOUSE = nameof(Inventories.WareHouse);
            string WORK_PLACE = nameof(Inventories.WorkPlace);
            string IS_ACTİVE = nameof(Inventories.IsActive);
            string CREATED_DATE = nameof(Inventories.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(FİCHE_DATE)) {
                model.FicheDate = values[FİCHE_DATE] != null ? Convert.ToDateTime(values[FİCHE_DATE]) : (DateTime?)null;
            }

            if(values.Contains(FİCHE_TOTAL)) {
                model.FicheTotal = values[FİCHE_TOTAL] != null ? Convert.ToDouble(values[FİCHE_TOTAL], CultureInfo.InvariantCulture) : (double?)null;
            }

            if(values.Contains(NUMBER)) {
                model.Number = Convert.ToString(values[NUMBER]);
            }

            if(values.Contains(OWNER_REF)) {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if(values.Contains(SECTİON)) {
                model.Section = values[SECTİON] != null ? Convert.ToInt32(values[SECTİON]) : (int?)null;
            }

            if(values.Contains(SPECODE)) {
                model.Specode = Convert.ToString(values[SPECODE]);
            }

            if(values.Contains(WARE_HOUSE)) {
                model.WareHouse = values[WARE_HOUSE] != null ? Convert.ToInt32(values[WARE_HOUSE]) : (int?)null;
            }

            if(values.Contains(WORK_PLACE)) {
                model.WorkPlace = values[WORK_PLACE] != null ? Convert.ToInt32(values[WORK_PLACE]) : (int?)null;
            }

            if(values.Contains(IS_ACTİVE)) {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
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