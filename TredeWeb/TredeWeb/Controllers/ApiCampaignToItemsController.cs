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
    public class ApiCampaignToItemsController : Controller
    {
        private TradeDbContext _context;

        public ApiCampaignToItemsController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var campaigntoıtems = _context.CampaignToItems.Select(i => new
            {
                i.CampaignId,
                i.ItemId
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "CampaignId", "ItemId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(campaigntoıtems, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new CampaignToItems();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.CampaignToItems.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.CampaignId, result.Entity.ItemId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string key, string values)
        {
            var keys = JsonConvert.DeserializeObject<IDictionary>(key);
            var keyCampaignId = Convert.ToInt32(keys["CampaignId"]);
            var keyItemId = Convert.ToInt32(keys["ItemId"]);
            var model = await _context.CampaignToItems.FirstOrDefaultAsync(item =>
                            item.CampaignId == keyCampaignId &&
                            item.ItemId == keyItemId);
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
        public async Task Delete(string key)
        {
            var keys = JsonConvert.DeserializeObject<IDictionary>(key);
            var keyCampaignId = Convert.ToInt32(keys["CampaignId"]);
            var keyItemId = Convert.ToInt32(keys["ItemId"]);
            var model = await _context.CampaignToItems.FirstOrDefaultAsync(item =>
                            item.CampaignId == keyCampaignId &&
                            item.ItemId == keyItemId);

            _context.CampaignToItems.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CampaignsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Campaigns
                         orderby i.GetCampainAdvantage
                         select new
                         {
                             Value = i.Id,
                             Text = i.GetCampainAdvantage
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> ItemsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Items
                         orderby i.Code
                         select new
                         {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(CampaignToItems model, IDictionary values)
        {
            string CAMPAİGN_ID = nameof(CampaignToItems.CampaignId);
            string ITEM_ID = nameof(CampaignToItems.ItemId);

            if (values.Contains(CAMPAİGN_ID))
            {
                model.CampaignId = Convert.ToInt32(values[CAMPAİGN_ID]);
            }

            if (values.Contains(ITEM_ID))
            {
                model.ItemId = Convert.ToInt32(values[ITEM_ID]);
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