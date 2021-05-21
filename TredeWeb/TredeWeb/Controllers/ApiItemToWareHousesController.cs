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
    public class ApiItemToWareHousesController : Controller
    {
        private TradeDbContext _context;

        public ApiItemToWareHousesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var ıtemtowarehouses = _context.ItemToWareHouses.Select(i => new {
                i.ItemId,
                i.WarehouseId
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ItemId", "WarehouseId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(ıtemtowarehouses, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new ItemToWareHouses();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.ItemToWareHouses.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.ItemId, result.Entity.WarehouseId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string key, string values) {
            var keys = JsonConvert.DeserializeObject<IDictionary>(key);
            var keyItemId = Convert.ToInt32(keys["ItemId"]);
            var keyWarehouseId = Convert.ToInt32(keys["WarehouseId"]);
            var model = await _context.ItemToWareHouses.FirstOrDefaultAsync(item =>
                            item.ItemId == keyItemId && 
                            item.WarehouseId == keyWarehouseId);
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
        public async Task Delete(string key) {
            var keys = JsonConvert.DeserializeObject<IDictionary>(key);
            var keyItemId = Convert.ToInt32(keys["ItemId"]);
            var keyWarehouseId = Convert.ToInt32(keys["WarehouseId"]);
            var model = await _context.ItemToWareHouses.FirstOrDefaultAsync(item =>
                            item.ItemId == keyItemId && 
                            item.WarehouseId == keyWarehouseId);

            _context.ItemToWareHouses.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> ItemsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Items
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

        private void PopulateModel(ItemToWareHouses model, IDictionary values) {
            string ITEM_ID = nameof(ItemToWareHouses.ItemId);
            string WAREHOUSE_ID = nameof(ItemToWareHouses.WarehouseId);

            if(values.Contains(ITEM_ID)) {
                model.ItemId = Convert.ToInt32(values[ITEM_ID]);
            }

            if(values.Contains(WAREHOUSE_ID)) {
                model.WarehouseId = Convert.ToInt32(values[WAREHOUSE_ID]);
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