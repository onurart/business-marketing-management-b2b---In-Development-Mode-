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
    public class ApiCampaignsController : Controller
    {
        private TradeDbContext _context;

        public ApiCampaignsController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var campaigns = _context.Campaigns.Select(i => new
            {
                i.Id,
                i.PictureRef,
                i.GetCampainAdvantage,
                i.Name,
                i.Description,
                i.OwnerRef,
                i.Type,
                i.Discount,
                i.IsActive,
                i.IsAccountCampaign,
                i.IsLimitedCampaign,
                i.CampaignLimit,
                i.CampaignTotal,
                i.CampaignAmount,
                i.BeginDate,
                i.EndDate,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(campaigns, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Campaigns();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Campaigns.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Campaigns.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Campaigns.FirstOrDefaultAsync(item => item.Id == key);

            _context.Campaigns.Remove(model);
            await _context.SaveChangesAsync();
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

        [HttpGet]
        public async Task<IActionResult> PicturesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Pictures
                         orderby i.DirectoryPath
                         select new
                         {
                             Value = i.Id,
                             Text = i.DirectoryPath
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Campaigns model, IDictionary values)
        {
            string ID = nameof(Campaigns.Id);
            string P??CTURE_REF = nameof(Campaigns.PictureRef);
            string GET_CAMPA??N_ADVANTAGE = nameof(Campaigns.GetCampainAdvantage);
            string NAME = nameof(Campaigns.Name);
            string DESCR??PT??ON = nameof(Campaigns.Description);
            string OWNER_REF = nameof(Campaigns.OwnerRef);
            string TYPE = nameof(Campaigns.Type);
            string D??SCOUNT = nameof(Campaigns.Discount);
            string IS_ACT??VE = nameof(Campaigns.IsActive);
            string IS_ACCOUNT_CAMPA??GN = nameof(Campaigns.IsAccountCampaign);
            string IS_L??M??TED_CAMPA??GN = nameof(Campaigns.IsLimitedCampaign);
            string CAMPA??GN_L??M??T = nameof(Campaigns.CampaignLimit);
            string CAMPA??GN_TOTAL = nameof(Campaigns.CampaignTotal);
            string CAMPA??GN_AMOUNT = nameof(Campaigns.CampaignAmount);
            string BEG??N_DATE = nameof(Campaigns.BeginDate);
            string END_DATE = nameof(Campaigns.EndDate);
            string CREATED_DATE = nameof(Campaigns.CreatedDate);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(P??CTURE_REF))
            {
                model.PictureRef = values[P??CTURE_REF] != null ? Convert.ToInt32(values[P??CTURE_REF]) : (int?)null;
            }

            if (values.Contains(GET_CAMPA??N_ADVANTAGE))
            {
                model.GetCampainAdvantage = Convert.ToString(values[GET_CAMPA??N_ADVANTAGE]);
            }

            if (values.Contains(NAME))
            {
                model.Name = Convert.ToString(values[NAME]);
            }

            if (values.Contains(DESCR??PT??ON))
            {
                model.Description = Convert.ToString(values[DESCR??PT??ON]);
            }

            if (values.Contains(OWNER_REF))
            {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if (values.Contains(TYPE))
            {
                model.Type = values[TYPE] != null ? Convert.ToInt32(values[TYPE]) : (int?)null;
            }

            if (values.Contains(D??SCOUNT))
            {
                model.Discount = values[D??SCOUNT] != null ? Convert.ToInt32(values[D??SCOUNT]) : (int?)null;
            }

            if (values.Contains(IS_ACT??VE))
            {
                model.IsActive = values[IS_ACT??VE] != null ? Convert.ToBoolean(values[IS_ACT??VE]) : (bool?)null;
            }

            if (values.Contains(IS_ACCOUNT_CAMPA??GN))
            {
                model.IsAccountCampaign = values[IS_ACCOUNT_CAMPA??GN] != null ? Convert.ToBoolean(values[IS_ACCOUNT_CAMPA??GN]) : (bool?)null;
            }

            if (values.Contains(IS_L??M??TED_CAMPA??GN))
            {
                model.IsLimitedCampaign = values[IS_L??M??TED_CAMPA??GN] != null ? Convert.ToBoolean(values[IS_L??M??TED_CAMPA??GN]) : (bool?)null;
            }

            if (values.Contains(CAMPA??GN_L??M??T))
            {
                model.CampaignLimit = values[CAMPA??GN_L??M??T] != null ? Convert.ToDouble(values[CAMPA??GN_L??M??T], CultureInfo.InvariantCulture) : (double?)null;
            }

            if (values.Contains(CAMPA??GN_TOTAL))
            {
                model.CampaignTotal = values[CAMPA??GN_TOTAL] != null ? Convert.ToDouble(values[CAMPA??GN_TOTAL], CultureInfo.InvariantCulture) : (double?)null;
            }

            if (values.Contains(CAMPA??GN_AMOUNT))
            {
                model.CampaignAmount = values[CAMPA??GN_AMOUNT] != null ? Convert.ToInt32(values[CAMPA??GN_AMOUNT]) : (int?)null;
            }

            if (values.Contains(BEG??N_DATE))
            {
                model.BeginDate = values[BEG??N_DATE] != null ? Convert.ToDateTime(values[BEG??N_DATE]) : (DateTime?)null;
            }

            if (values.Contains(END_DATE))
            {
                model.EndDate = values[END_DATE] != null ? Convert.ToDateTime(values[END_DATE]) : (DateTime?)null;
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