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
    public class ApiAddressesController : Controller
    {
        private TradeDbContext _context;

        public ApiAddressesController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var addresses = _context.Addresses.Select(i => new
            {
                i.Id,
                i.CityRef,
                i.CountryRef,
                i.TownRef,
                i.AddressType,
                i.DistrictName,
                i.IsDefault,
                i.Number,
                i.OwnerRef,
                i.MainStreet,
                i.Street,
                i.PostCode,
                i.IsCustomerAddress,
                i.IsActive,
                i.CreatedDate,
                i.ModifiedDate,
                i.ModifiedUser,
                i.Location
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(addresses, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new Addresses();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Addresses.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.Addresses.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Addresses.FirstOrDefaultAsync(item => item.Id == key);

            _context.Addresses.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CitiesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Cities
                         orderby i.Name
                         select new
                         {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> CountriesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Countries
                         orderby i.BinaryCode
                         select new
                         {
                             Value = i.Id,
                             Text = i.BinaryCode
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

        [HttpGet]
        public async Task<IActionResult> TownsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Towns
                         orderby i.TownName
                         select new
                         {
                             Value = i.Id,
                             Text = i.TownName
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Addresses model, IDictionary values)
        {
            string ID = nameof(Addresses.Id);
            string CİTY_REF = nameof(Addresses.CityRef);
            string COUNTRY_REF = nameof(Addresses.CountryRef);
            string TOWN_REF = nameof(Addresses.TownRef);
            string ADDRESS_TYPE = nameof(Addresses.AddressType);
            string DİSTRİCT_NAME = nameof(Addresses.DistrictName);
            string IS_DEFAULT = nameof(Addresses.IsDefault);
            string NUMBER = nameof(Addresses.Number);
            string OWNER_REF = nameof(Addresses.OwnerRef);
            string MAİN_STREET = nameof(Addresses.MainStreet);
            string STREET = nameof(Addresses.Street);
            string POST_CODE = nameof(Addresses.PostCode);
            string IS_CUSTOMER_ADDRESS = nameof(Addresses.IsCustomerAddress);
            string IS_ACTİVE = nameof(Addresses.IsActive);
            string CREATED_DATE = nameof(Addresses.CreatedDate);
            string MODİFİED_DATE = nameof(Addresses.ModifiedDate);
            string MODİFİED_USER = nameof(Addresses.ModifiedUser);
            string LOCATİON = nameof(Addresses.Location);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(CİTY_REF))
            {
                model.CityRef = values[CİTY_REF] != null ? Convert.ToInt32(values[CİTY_REF]) : (int?)null;
            }

            if (values.Contains(COUNTRY_REF))
            {
                model.CountryRef = values[COUNTRY_REF] != null ? Convert.ToInt32(values[COUNTRY_REF]) : (int?)null;
            }

            if (values.Contains(TOWN_REF))
            {
                model.TownRef = values[TOWN_REF] != null ? Convert.ToInt32(values[TOWN_REF]) : (int?)null;
            }

            if (values.Contains(ADDRESS_TYPE))
            {
                model.AddressType = values[ADDRESS_TYPE] != null ? Convert.ToInt32(values[ADDRESS_TYPE]) : (int?)null;
            }

            if (values.Contains(DİSTRİCT_NAME))
            {
                model.DistrictName = Convert.ToString(values[DİSTRİCT_NAME]);
            }

            if (values.Contains(IS_DEFAULT))
            {
                model.IsDefault = values[IS_DEFAULT] != null ? Convert.ToBoolean(values[IS_DEFAULT]) : (bool?)null;
            }

            if (values.Contains(NUMBER))
            {
                model.Number = Convert.ToString(values[NUMBER]);
            }

            if (values.Contains(OWNER_REF))
            {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if (values.Contains(MAİN_STREET))
            {
                model.MainStreet = Convert.ToString(values[MAİN_STREET]);
            }

            if (values.Contains(STREET))
            {
                model.Street = Convert.ToString(values[STREET]);
            }

            if (values.Contains(POST_CODE))
            {
                model.PostCode = Convert.ToString(values[POST_CODE]);
            }

            if (values.Contains(IS_CUSTOMER_ADDRESS))
            {
                model.IsCustomerAddress = values[IS_CUSTOMER_ADDRESS] != null ? Convert.ToBoolean(values[IS_CUSTOMER_ADDRESS]) : (bool?)null;
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if (values.Contains(MODİFİED_DATE))
            {
                model.ModifiedDate = values[MODİFİED_DATE] != null ? Convert.ToDateTime(values[MODİFİED_DATE]) : (DateTime?)null;
            }

            if (values.Contains(MODİFİED_USER))
            {
                model.ModifiedUser = values[MODİFİED_USER] != null ? Convert.ToInt32(values[MODİFİED_USER]) : (int?)null;
            }

            if (values.Contains(LOCATİON))
            {
                model.Location = values[LOCATİON] != null ? Convert.ToInt32(values[LOCATİON]) : (int?)null;
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