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
    public class ApiCouponCodesController : Controller
    {
        private TradeDbContext _context;

        public ApiCouponCodesController(TradeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var couponcodes = _context.CouponCodes.Select(i => new
            {
                i.Id,
                i.Code,
                i.CouponType,
                i.CouponValue,
                i.DueDate,
                i.OwnerRef,
                i.CreatedDate,
                i.IsActive
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(couponcodes, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new CouponCodes();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.CouponCodes.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.CouponCodes.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.CouponCodes.FirstOrDefaultAsync(item => item.Id == key);

            _context.CouponCodes.Remove(model);
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

        private void PopulateModel(CouponCodes model, IDictionary values)
        {
            string ID = nameof(CouponCodes.Id);
            string CODE = nameof(CouponCodes.Code);
            string COUPON_TYPE = nameof(CouponCodes.CouponType);
            string COUPON_VALUE = nameof(CouponCodes.CouponValue);
            string DUE_DATE = nameof(CouponCodes.DueDate);
            string OWNER_REF = nameof(CouponCodes.OwnerRef);
            string CREATED_DATE = nameof(CouponCodes.CreatedDate);
            string IS_ACTİVE = nameof(CouponCodes.IsActive);

            if (values.Contains(ID))
            {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if (values.Contains(CODE))
            {
                model.Code = Convert.ToString(values[CODE]);
            }

            if (values.Contains(COUPON_TYPE))
            {
                model.CouponType = values[COUPON_TYPE] != null ? Convert.ToBoolean(values[COUPON_TYPE]) : (bool?)null;
            }

            if (values.Contains(COUPON_VALUE))
            {
                model.CouponValue = values[COUPON_VALUE] != null ? Convert.ToDecimal(values[COUPON_VALUE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if (values.Contains(DUE_DATE))
            {
                model.DueDate = values[DUE_DATE] != null ? Convert.ToDateTime(values[DUE_DATE]) : (DateTime?)null;
            }

            if (values.Contains(OWNER_REF))
            {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if (values.Contains(CREATED_DATE))
            {
                model.CreatedDate = values[CREATED_DATE] != null ? Convert.ToDateTime(values[CREATED_DATE]) : (DateTime?)null;
            }

            if (values.Contains(IS_ACTİVE))
            {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
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