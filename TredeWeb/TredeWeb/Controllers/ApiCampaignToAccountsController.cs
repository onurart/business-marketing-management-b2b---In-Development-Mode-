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
    public class ApiCampaignToAccountsController : Controller
    {
        private TradeDbContext _context;

        public ApiCampaignToAccountsController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var campaigntoaccounts = _context.CampaignToAccounts.Select(i => new {
                i.AccountId,
                i.CampaignId
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "AccountId", "CampaignId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(campaigntoaccounts, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new CampaignToAccounts();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.CampaignToAccounts.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.AccountId, result.Entity.CampaignId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string key, string values) {
            var keys = JsonConvert.DeserializeObject<IDictionary>(key);
            var keyAccountId = Convert.ToInt32(keys["AccountId"]);
            var keyCampaignId = Convert.ToInt32(keys["CampaignId"]);
            var model = await _context.CampaignToAccounts.FirstOrDefaultAsync(item =>
                            item.AccountId == keyAccountId && 
                            item.CampaignId == keyCampaignId);
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
            var keyAccountId = Convert.ToInt32(keys["AccountId"]);
            var keyCampaignId = Convert.ToInt32(keys["CampaignId"]);
            var model = await _context.CampaignToAccounts.FirstOrDefaultAsync(item =>
                            item.AccountId == keyAccountId && 
                            item.CampaignId == keyCampaignId);

            _context.CampaignToAccounts.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> AccountsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Accounts
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CampaignsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Campaigns
                         orderby i.GetCampainAdvantage
                         select new {
                             Value = i.Id,
                             Text = i.GetCampainAdvantage
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(CampaignToAccounts model, IDictionary values) {
            string ACCOUNT_ID = nameof(CampaignToAccounts.AccountId);
            string CAMPAİGN_ID = nameof(CampaignToAccounts.CampaignId);

            if(values.Contains(ACCOUNT_ID)) {
                model.AccountId = Convert.ToInt32(values[ACCOUNT_ID]);
            }

            if(values.Contains(CAMPAİGN_ID)) {
                model.CampaignId = Convert.ToInt32(values[CAMPAİGN_ID]);
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