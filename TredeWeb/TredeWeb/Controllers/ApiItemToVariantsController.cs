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
    public class ApiItemToVariantsController : Controller
    {
        private TradeDbContext _context;

        public ApiItemToVariantsController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var ıtemtovariants = _context.ItemToVariants.Select(i => new {
                i.ItemId,
                i.VariantId
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "ItemId", "VariantId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(ıtemtovariants, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new ItemToVariants();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.ItemToVariants.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.ItemId, result.Entity.VariantId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string key, string values) {
            var keys = JsonConvert.DeserializeObject<IDictionary>(key);
            var keyItemId = Convert.ToInt32(keys["ItemId"]);
            var keyVariantId = Convert.ToInt32(keys["VariantId"]);
            var model = await _context.ItemToVariants.FirstOrDefaultAsync(item =>
                            item.ItemId == keyItemId && 
                            item.VariantId == keyVariantId);
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
            var keyVariantId = Convert.ToInt32(keys["VariantId"]);
            var model = await _context.ItemToVariants.FirstOrDefaultAsync(item =>
                            item.ItemId == keyItemId && 
                            item.VariantId == keyVariantId);

            _context.ItemToVariants.Remove(model);
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
        public async Task<IActionResult> VariantsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Variants
                         orderby i.VariantName
                         select new {
                             Value = i.Id,
                             Text = i.VariantName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(ItemToVariants model, IDictionary values) {
            string ITEM_ID = nameof(ItemToVariants.ItemId);
            string VARİANT_ID = nameof(ItemToVariants.VariantId);

            if(values.Contains(ITEM_ID)) {
                model.ItemId = Convert.ToInt32(values[ITEM_ID]);
            }

            if(values.Contains(VARİANT_ID)) {
                model.VariantId = Convert.ToInt32(values[VARİANT_ID]);
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