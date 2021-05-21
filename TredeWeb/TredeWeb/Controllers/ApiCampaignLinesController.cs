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
    public class ApiCampaignLinesController : Controller
    {
        private TradeDbContext _context;

        public ApiCampaignLinesController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var campaignlines = _context.CampaignLines.Select(i => new
            {
                i.Id,
                i.CampaignRef,
                i.ItemRef,
                i.Amount,
                i.AccountRef,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(campaignlines, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new CampaignLines();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.CampaignLines.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.CampaignLines.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.CampaignLines.FirstOrDefaultAsync(item => item.Id == key);

            _context.CampaignLines.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> AccountsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Accounts
                         orderby i.Title
                         select new
                         {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
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

        private void PopulateModel(CampaignLines model, IDictionary values)
        {
            string ID = nameof(CampaignLines.Id);
            string CAMPAİGN_REF = nameof(CampaignLines.CampaignRef);
            string ITEM_REF = nameof(CampaignLines.ItemRef);
            string AMOUNT = nameof(CampaignLines.Amount);
            string ACCOUNT_REF = nameof(CampaignLines.AccountRef);
            string IS_ACTİVE = nameof(CampaignLines.IsActive);
            string CREATED_DATE = nameof(CampaignLines.CreatedDate);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(CAMPAİGN_REF))
            {
                model.CampaignRef = values[CAMPAİGN_REF] != null ? Convert.ToInt32(values[CAMPAİGN_REF]) : (int?)null;
            }

            if (values.Contains(ITEM_REF))
            {
                model.ItemRef = values[ITEM_REF] != null ? Convert.ToInt32(values[ITEM_REF]) : (int?)null;
            }

            if (values.Contains(AMOUNT))
            {
                model.Amount = values[AMOUNT] != null ? Convert.ToDouble(values[AMOUNT], CultureInfo.InvariantCulture) : (double?)null;
            }

            if (values.Contains(ACCOUNT_REF))
            {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
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