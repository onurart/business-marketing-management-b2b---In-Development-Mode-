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
    public class ApiOrdersController : Controller
    {
        private TradeDbContext _context;

        public ApiOrdersController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var orders = _context.Orders.Select(i => new {
                i.Id,
                i.SrcName,
                i.OrderSessionId,
                i.IsProcess,
                i.ApproveDate,
                i.BasketRef,
                i.AccountRef,
                i.Code,
                i.Coupon,
                i.FinanceRef,
                i.DeliveryAddress,
                i.DeliveryCompany,
                i.Discount,
                i.DiscountType,
                i.OrderDiscount,
                i.FicheTotal,
                i.InvoiceAddress,
                i.IsApproved,
                i.IsCharged,
                i.IsDiscount,
                i.IsGiftPackage,
                i.IsWholeSale,
                i.Name,
                i.OrderDate,
                i.OrderNote,
                i.OrderStatus,
                i.OrderStyle,
                i.OrderTotal,
                i.OwnerRef,
                i.PaymentType,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(orders, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Orders();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Orders.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Orders.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Orders.FirstOrDefaultAsync(item => item.Id == key);

            _context.Orders.Remove(model);
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
        public async Task<IActionResult> CouponCodesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.CouponCodes
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> FnFichesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.FnFiches
                         orderby i.Description
                         select new {
                             Value = i.Id,
                             Text = i.Description
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
        public async Task<IActionResult> PaymentTypesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.PaymentTypes
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Orders model, IDictionary values) {
            string ID = nameof(Orders.Id);
            string SRC_NAME = nameof(Orders.SrcName);
            string ORDER_SESS??ON_ID = nameof(Orders.OrderSessionId);
            string IS_PROCESS = nameof(Orders.IsProcess);
            string APPROVE_DATE = nameof(Orders.ApproveDate);
            string BASKET_REF = nameof(Orders.BasketRef);
            string ACCOUNT_REF = nameof(Orders.AccountRef);
            string CODE = nameof(Orders.Code);
            string COUPON = nameof(Orders.Coupon);
            string F??NANCE_REF = nameof(Orders.FinanceRef);
            string DEL??VERY_ADDRESS = nameof(Orders.DeliveryAddress);
            string DEL??VERY_COMPANY = nameof(Orders.DeliveryCompany);
            string D??SCOUNT = nameof(Orders.Discount);
            string D??SCOUNT_TYPE = nameof(Orders.DiscountType);
            string ORDER_D??SCOUNT = nameof(Orders.OrderDiscount);
            string F??CHE_TOTAL = nameof(Orders.FicheTotal);
            string INVO??CE_ADDRESS = nameof(Orders.InvoiceAddress);
            string IS_APPROVED = nameof(Orders.IsApproved);
            string IS_CHARGED = nameof(Orders.IsCharged);
            string IS_D??SCOUNT = nameof(Orders.IsDiscount);
            string IS_G??FT_PACKAGE = nameof(Orders.IsGiftPackage);
            string IS_WHOLE_SALE = nameof(Orders.IsWholeSale);
            string NAME = nameof(Orders.Name);
            string ORDER_DATE = nameof(Orders.OrderDate);
            string ORDER_NOTE = nameof(Orders.OrderNote);
            string ORDER_STATUS = nameof(Orders.OrderStatus);
            string ORDER_STYLE = nameof(Orders.OrderStyle);
            string ORDER_TOTAL = nameof(Orders.OrderTotal);
            string OWNER_REF = nameof(Orders.OwnerRef);
            string PAYMENT_TYPE = nameof(Orders.PaymentType);
            string IS_ACT??VE = nameof(Orders.IsActive);
            string CREATED_DATE = nameof(Orders.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(SRC_NAME)) {
                model.SrcName = Convert.ToString(values[SRC_NAME]);
            }

            if(values.Contains(ORDER_SESS??ON_ID)) {
                model.OrderSessionId = Convert.ToString(values[ORDER_SESS??ON_ID]);
            }

            if(values.Contains(IS_PROCESS)) {
                model.IsProcess = values[IS_PROCESS] != null ? Convert.ToBoolean(values[IS_PROCESS]) : (bool?)null;
            }

            if(values.Contains(APPROVE_DATE)) {
                model.ApproveDate = values[APPROVE_DATE] != null ? Convert.ToDateTime(values[APPROVE_DATE]) : (DateTime?)null;
            }

            if(values.Contains(BASKET_REF)) {
                model.BasketRef = values[BASKET_REF] != null ? Convert.ToInt32(values[BASKET_REF]) : (int?)null;
            }

            if(values.Contains(ACCOUNT_REF)) {
                model.AccountRef = values[ACCOUNT_REF] != null ? Convert.ToInt32(values[ACCOUNT_REF]) : (int?)null;
            }

            if(values.Contains(CODE)) {
                model.Code = Convert.ToString(values[CODE]);
            }

            if(values.Contains(COUPON)) {
                model.Coupon = values[COUPON] != null ? Convert.ToInt32(values[COUPON]) : (int?)null;
            }

            if(values.Contains(F??NANCE_REF)) {
                model.FinanceRef = values[F??NANCE_REF] != null ? Convert.ToInt32(values[F??NANCE_REF]) : (int?)null;
            }

            if(values.Contains(DEL??VERY_ADDRESS)) {
                model.DeliveryAddress = values[DEL??VERY_ADDRESS] != null ? Convert.ToInt32(values[DEL??VERY_ADDRESS]) : (int?)null;
            }

            if(values.Contains(DEL??VERY_COMPANY)) {
                model.DeliveryCompany = Convert.ToString(values[DEL??VERY_COMPANY]);
            }

            if(values.Contains(D??SCOUNT)) {
                model.Discount = values[D??SCOUNT] != null ? Convert.ToDecimal(values[D??SCOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(D??SCOUNT_TYPE)) {
                model.DiscountType = values[D??SCOUNT_TYPE] != null ? Convert.ToInt32(values[D??SCOUNT_TYPE]) : (int?)null;
            }

            if(values.Contains(ORDER_D??SCOUNT)) {
                model.OrderDiscount = values[ORDER_D??SCOUNT] != null ? Convert.ToDecimal(values[ORDER_D??SCOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(F??CHE_TOTAL)) {
                model.FicheTotal = values[F??CHE_TOTAL] != null ? Convert.ToDecimal(values[F??CHE_TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(INVO??CE_ADDRESS)) {
                model.InvoiceAddress = values[INVO??CE_ADDRESS] != null ? Convert.ToInt32(values[INVO??CE_ADDRESS]) : (int?)null;
            }

            if(values.Contains(IS_APPROVED)) {
                model.IsApproved = values[IS_APPROVED] != null ? Convert.ToBoolean(values[IS_APPROVED]) : (bool?)null;
            }

            if(values.Contains(IS_CHARGED)) {
                model.IsCharged = values[IS_CHARGED] != null ? Convert.ToBoolean(values[IS_CHARGED]) : (bool?)null;
            }

            if(values.Contains(IS_D??SCOUNT)) {
                model.IsDiscount = values[IS_D??SCOUNT] != null ? Convert.ToBoolean(values[IS_D??SCOUNT]) : (bool?)null;
            }

            if(values.Contains(IS_G??FT_PACKAGE)) {
                model.IsGiftPackage = values[IS_G??FT_PACKAGE] != null ? Convert.ToBoolean(values[IS_G??FT_PACKAGE]) : (bool?)null;
            }

            if(values.Contains(IS_WHOLE_SALE)) {
                model.IsWholeSale = values[IS_WHOLE_SALE] != null ? Convert.ToBoolean(values[IS_WHOLE_SALE]) : (bool?)null;
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(ORDER_DATE)) {
                model.OrderDate = values[ORDER_DATE] != null ? Convert.ToDateTime(values[ORDER_DATE]) : (DateTime?)null;
            }

            if(values.Contains(ORDER_NOTE)) {
                model.OrderNote = Convert.ToString(values[ORDER_NOTE]);
            }

            if(values.Contains(ORDER_STATUS)) {
                model.OrderStatus = values[ORDER_STATUS] != null ? Convert.ToInt32(values[ORDER_STATUS]) : (int?)null;
            }

            if(values.Contains(ORDER_STYLE)) {
                model.OrderStyle = values[ORDER_STYLE] != null ? Convert.ToInt32(values[ORDER_STYLE]) : (int?)null;
            }

            if(values.Contains(ORDER_TOTAL)) {
                model.OrderTotal = values[ORDER_TOTAL] != null ? Convert.ToDecimal(values[ORDER_TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(OWNER_REF)) {
                model.OwnerRef = values[OWNER_REF] != null ? Convert.ToInt32(values[OWNER_REF]) : (int?)null;
            }

            if(values.Contains(PAYMENT_TYPE)) {
                model.PaymentType = values[PAYMENT_TYPE] != null ? Convert.ToInt32(values[PAYMENT_TYPE]) : (int?)null;
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