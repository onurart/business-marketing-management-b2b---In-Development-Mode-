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
    public class ApiAccountsController : Controller
    {
        private TradeDbContext _context;

        public ApiAccountsController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var accounts = _context.Accounts.Select(i => new
            {
                i.Id,
                i.Title,
                i.AddressRef,
                i.AppleId,
                i.AverageMaturityDate,
                i.UserRef,
                i.Code,
                i.CreatedDate,
                i.Description,
                i.ExtSendEmail,
                i.ExtSendFaxNr,
                i.FacebookUrl,
                i.FinBrws,
                i.ImpBrws,
                i.IsActive,
                i.MailAddress,
                i.MobileNumber,
                i.Name,
                i.OwnerRef,
                i.ParentAccount,
                i.PhoneNumber,
                i.PurchaseBrws,
                i.SaleBrws,
                i.SkypeId,
                i.Specode,
                i.TaxNr,
                i.TaxOffice,
                i.Tckno,
                i.TwitterUrl,
                i.WebSite
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(accounts, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Accounts();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Accounts.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Accounts.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Accounts.FirstOrDefaultAsync(item => item.Id == key);

            _context.Accounts.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> AddressesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Addresses
                         orderby i.DistrictName
                         select new
                         {
                             Value = i.Id,
                             Text = i.DistrictName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
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

        private void PopulateModel(Accounts model, IDictionary values)
        {
            string ID = nameof(Accounts.Id);
            string T??TLE = nameof(Accounts.Title);
            string ADDRESS_REF = nameof(Accounts.AddressRef);
            string APPLE_ID = nameof(Accounts.AppleId);
            string AVERAGE_MATUR??TY_DATE = nameof(Accounts.AverageMaturityDate);
            string USER_REF = nameof(Accounts.UserRef);
            string CODE = nameof(Accounts.Code);
            string CREATED_DATE = nameof(Accounts.CreatedDate);
            string DESCR??PT??ON = nameof(Accounts.Description);
            string EXT_SEND_EMA??L = nameof(Accounts.ExtSendEmail);
            string EXT_SEND_FAX_NR = nameof(Accounts.ExtSendFaxNr);
            string FACEBOOK_URL = nameof(Accounts.FacebookUrl);
            string F??N_BRWS = nameof(Accounts.FinBrws);
            string IMP_BRWS = nameof(Accounts.ImpBrws);
            string IS_ACT??VE = nameof(Accounts.IsActive);
            string MA??L_ADDRESS = nameof(Accounts.MailAddress);
            string MOB??LE_NUMBER = nameof(Accounts.MobileNumber);
            string NAME = nameof(Accounts.Name);
            string OWNER_REF = nameof(Accounts.OwnerRef);
            string PARENT_ACCOUNT = nameof(Accounts.ParentAccount);
            string PHONE_NUMBER = nameof(Accounts.PhoneNumber);
            string PURCHASE_BRWS = nameof(Accounts.PurchaseBrws);
            string SALE_BRWS = nameof(Accounts.SaleBrws);
            string SKYPE_ID = nameof(Accounts.SkypeId);
            string SPECODE = nameof(Accounts.Specode);
            string TAX_NR = nameof(Accounts.TaxNr);
            string TAX_OFF??CE = nameof(Accounts.TaxOffice);
            string TCKNO = nameof(Accounts.Tckno);
            string TW??TTER_URL = nameof(Accounts.TwitterUrl);
            string WEB_S??TE = nameof(Accounts.WebSite);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(T??TLE))
            {
                model.Title = Convert.ToString(values[T??TLE]);
            }

            if (values.Contains(ADDRESS_REF))
            {
                model.AddressRef = values[ADDRESS_REF] != null ? Convert.ToInt32(values[ADDRESS_REF]) : (int?)null;
            }

            if (values.Contains(APPLE_ID))
            {
                model.AppleId = Convert.ToString(values[APPLE_ID]);
            }

            if (values.Contains(AVERAGE_MATUR??TY_DATE))
            {
                model.AverageMaturityDate = values[AVERAGE_MATUR??TY_DATE] != null ? Convert.ToInt32(values[AVERAGE_MATUR??TY_DATE]) : (int?)null;
            }

            if (values.Contains(USER_REF))
            {
                model.UserRef = values[USER_REF] != null ? Convert.ToInt32(values[USER_REF]) : (int?)null;
            }

            if (values.Contains(CODE))
            {
                model.Code = Convert.ToString(values[CODE]);
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if (values.Contains(DESCR??PT??ON))
            {
                model.Description = Convert.ToString(values[DESCR??PT??ON]);
            }

            if (values.Contains(EXT_SEND_EMA??L))
            {
                model.ExtSendEmail = Convert.ToString(values[EXT_SEND_EMA??L]);
            }

            if (values.Contains(EXT_SEND_FAX_NR))
            {
                model.ExtSendFaxNr = Convert.ToString(values[EXT_SEND_FAX_NR]);
            }

            if (values.Contains(FACEBOOK_URL))
            {
                model.FacebookUrl = Convert.ToString(values[FACEBOOK_URL]);
            }

            if (values.Contains(F??N_BRWS))
            {
                model.FinBrws = values[F??N_BRWS] != null ? Convert.ToBoolean(values[F??N_BRWS]) : (bool?)null;
            }

            if (values.Contains(IMP_BRWS))
            {
                model.ImpBrws = values[IMP_BRWS] != null ? Convert.ToBoolean(values[IMP_BRWS]) : (bool?)null;
            }

            if (values.Contains(IS_ACT??VE))
            {
                model.IsActive = values[IS_ACT??VE] != null ? Convert.ToBoolean(values[IS_ACT??VE]) : (bool?)null;
            }

            if (values.Contains(MA??L_ADDRESS))
            {
                model.MailAddress = Convert.ToString(values[MA??L_ADDRESS]);
            }

            if (values.Contains(MOB??LE_NUMBER))
            {
                model.MobileNumber = Convert.ToString(values[MOB??LE_NUMBER]);
            }

            if (values.Contains(NAME))
            {
                model.Name = Convert.ToString(values[NAME]);
            }

            if (values.Contains(OWNER_REF))
            {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if (values.Contains(PARENT_ACCOUNT))
            {
                model.ParentAccount = values[PARENT_ACCOUNT] != null ? Convert.ToInt32(values[PARENT_ACCOUNT]) : (int?)null;
            }

            if (values.Contains(PHONE_NUMBER))
            {
                model.PhoneNumber = Convert.ToString(values[PHONE_NUMBER]);
            }

            if (values.Contains(PURCHASE_BRWS))
            {
                model.PurchaseBrws = values[PURCHASE_BRWS] != null ? Convert.ToBoolean(values[PURCHASE_BRWS]) : (bool?)null;
            }

            if (values.Contains(SALE_BRWS))
            {
                model.SaleBrws = values[SALE_BRWS] != null ? Convert.ToBoolean(values[SALE_BRWS]) : (bool?)null;
            }

            if (values.Contains(SKYPE_ID))
            {
                model.SkypeId = Convert.ToString(values[SKYPE_ID]);
            }

            if (values.Contains(SPECODE))
            {
                model.Specode = Convert.ToString(values[SPECODE]);
            }

            if (values.Contains(TAX_NR))
            {
                model.TaxNr = Convert.ToString(values[TAX_NR]);
            }

            if (values.Contains(TAX_OFF??CE))
            {
                model.TaxOffice = Convert.ToString(values[TAX_OFF??CE]);
            }

            if (values.Contains(TCKNO))
            {
                model.Tckno = Convert.ToString(values[TCKNO]);
            }

            if (values.Contains(TW??TTER_URL))
            {
                model.TwitterUrl = Convert.ToString(values[TW??TTER_URL]);
            }

            if (values.Contains(WEB_S??TE))
            {
                model.WebSite = Convert.ToString(values[WEB_S??TE]);
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