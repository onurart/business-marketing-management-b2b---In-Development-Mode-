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
    public class ApiUsersController : Controller
    {
        private TradeDbContext _context;

        public ApiUsersController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var users = _context.Users.Select(i => new {
                i.Id,
                i.UserName,
                i.ChangePasswordOnFirstLogon,
                i.StoredPassword,
                i.UserCurrencyType,
                i.Department,
                i.Position,
                i.Location,
                i.BirthDay,
                i.Email,
                i.FirstName,
                i.MiddleName,
                i.LastName,
                i.Title,
                i.AccountRef,
                i.OwnerRef,
                i.AddressRef,
                i.PhoneNumber,
                i.TaxNr,
                i.TaxOffice,
                i.Tckno,
                i.MobileNumber,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(users, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Users();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Users.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Users.FirstOrDefaultAsync(item => item.Id == key);

            _context.Users.Remove(model);
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
        public async Task<IActionResult> AddressesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Addresses
                         orderby i.DistrictName
                         select new {
                             Value = i.Id,
                             Text = i.DistrictName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> DepartmentsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Departments
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
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

        [HttpGet]
        public async Task<IActionResult> PositionsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Positions
                         orderby i.Title
                         select new {
                             Value = i.Id,
                             Text = i.Title
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CurrenciesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Currencies
                         orderby i.CurrType
                         select new {
                             Value = i.Id,
                             Text = i.CurrType
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Users model, IDictionary values) {
            string ID = nameof(Users.Id);
            string USER_NAME = nameof(Users.UserName);
            string CHANGE_PASSWORD_ON_F??RST_LOGON = nameof(Users.ChangePasswordOnFirstLogon);
            string STORED_PASSWORD = nameof(Users.StoredPassword);
            string USER_CURRENCY_TYPE = nameof(Users.UserCurrencyType);
            string DEPARTMENT = nameof(Users.Department);
            string POS??T??ON = nameof(Users.Position);
            string LOCAT??ON = nameof(Users.Location);
            string B??RTH_DAY = nameof(Users.BirthDay);
            string EMA??L = nameof(Users.Email);
            string F??RST_NAME = nameof(Users.FirstName);
            string M??DDLE_NAME = nameof(Users.MiddleName);
            string LAST_NAME = nameof(Users.LastName);
            string T??TLE = nameof(Users.Title);
            string ACCOUNT_REF = nameof(Users.AccountRef);
            string OWNER_REF = nameof(Users.OwnerRef);
            string ADDRESS_REF = nameof(Users.AddressRef);
            string PHONE_NUMBER = nameof(Users.PhoneNumber);
            string TAX_NR = nameof(Users.TaxNr);
            string TAX_OFF??CE = nameof(Users.TaxOffice);
            string TCKNO = nameof(Users.Tckno);
            string MOB??LE_NUMBER = nameof(Users.MobileNumber);
            string IS_ACT??VE = nameof(Users.IsActive);
            string CREATED_DATE = nameof(Users.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(USER_NAME)) {
                model.UserName = Convert.ToString(values[USER_NAME]);
            }

            if(values.Contains(CHANGE_PASSWORD_ON_F??RST_LOGON)) {
                model.ChangePasswordOnFirstLogon = values[CHANGE_PASSWORD_ON_F??RST_LOGON] != null ? Convert.ToBoolean(values[CHANGE_PASSWORD_ON_F??RST_LOGON]) : (bool?)null;
            }

            if(values.Contains(STORED_PASSWORD)) {
                model.StoredPassword = Convert.ToString(values[STORED_PASSWORD]);
            }

            if(values.Contains(USER_CURRENCY_TYPE)) {
                model.UserCurrencyType = values[USER_CURRENCY_TYPE] != null ? Convert.ToInt32(values[USER_CURRENCY_TYPE]) : (int?)null;
            }

            if(values.Contains(DEPARTMENT)) {
                model.Department = values[DEPARTMENT] != null ? Convert.ToInt32(values[DEPARTMENT]) : (int?)null;
            }

            if(values.Contains(POS??T??ON)) {
                model.Position = values[POS??T??ON] != null ? Convert.ToInt32(values[POS??T??ON]) : (int?)null;
            }

            if(values.Contains(LOCAT??ON)) {
                model.Location = values[LOCAT??ON] != null ? Convert.ToInt32(values[LOCAT??ON]) : (int?)null;
            }

            if(values.Contains(B??RTH_DAY)) {
                model.BirthDay = values[B??RTH_DAY] != null ? Convert.ToDateTime(values[B??RTH_DAY]) : (DateTime?)null;
            }

            if(values.Contains(EMA??L)) {
                model.Email = Convert.ToString(values[EMA??L]);
            }

            if(values.Contains(F??RST_NAME)) {
                model.FirstName = Convert.ToString(values[F??RST_NAME]);
            }

            if(values.Contains(M??DDLE_NAME)) {
                model.MiddleName = Convert.ToString(values[M??DDLE_NAME]);
            }

            if(values.Contains(LAST_NAME)) {
                model.LastName = Convert.ToString(values[LAST_NAME]);
            }

            if(values.Contains(T??TLE)) {
                model.Title = Convert.ToString(values[T??TLE]);
            }

            if(values.Contains(ACCOUNT_REF)) {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if(values.Contains(OWNER_REF)) {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if(values.Contains(ADDRESS_REF)) {
                model.AddressRef = values[ADDRESS_REF] != null ? Convert.ToInt32(values[ADDRESS_REF]) : (int?)null;
            }

            if(values.Contains(PHONE_NUMBER)) {
                model.PhoneNumber = Convert.ToString(values[PHONE_NUMBER]);
            }

            if(values.Contains(TAX_NR)) {
                model.TaxNr = Convert.ToString(values[TAX_NR]);
            }

            if(values.Contains(TAX_OFF??CE)) {
                model.TaxOffice = Convert.ToString(values[TAX_OFF??CE]);
            }

            if(values.Contains(TCKNO)) {
                model.Tckno = Convert.ToString(values[TCKNO]);
            }

            if(values.Contains(MOB??LE_NUMBER)) {
                model.MobileNumber = Convert.ToString(values[MOB??LE_NUMBER]);
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