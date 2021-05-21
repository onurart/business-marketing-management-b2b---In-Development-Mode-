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
            string ORDER_SESSİON_ID = nameof(Orders.OrderSessionId);
            string IS_PROCESS = nameof(Orders.IsProcess);
            string APPROVE_DATE = nameof(Orders.ApproveDate);
            string BASKET_REF = nameof(Orders.BasketRef);
            string ACCOUNT_REF = nameof(Orders.AccountRef);
            string CODE = nameof(Orders.Code);
            string COUPON = nameof(Orders.Coupon);
            string FİNANCE_REF = nameof(Orders.FinanceRef);
            string DELİVERY_ADDRESS = nameof(Orders.DeliveryAddress);
            string DELİVERY_COMPANY = nameof(Orders.DeliveryCompany);
            string DİSCOUNT = nameof(Orders.Discount);
            string DİSCOUNT_TYPE = nameof(Orders.DiscountType);
            string ORDER_DİSCOUNT = nameof(Orders.OrderDiscount);
            string FİCHE_TOTAL = nameof(Orders.FicheTotal);
            string INVOİCE_ADDRESS = nameof(Orders.InvoiceAddress);
            string IS_APPROVED = nameof(Orders.IsApproved);
            string IS_CHARGED = nameof(Orders.IsCharged);
            string IS_DİSCOUNT = nameof(Orders.IsDiscount);
            string IS_GİFT_PACKAGE = nameof(Orders.IsGiftPackage);
            string IS_WHOLE_SALE = nameof(Orders.IsWholeSale);
            string NAME = nameof(Orders.Name);
            string ORDER_DATE = nameof(Orders.OrderDate);
            string ORDER_NOTE = nameof(Orders.OrderNote);
            string ORDER_STATUS = nameof(Orders.OrderStatus);
            string ORDER_STYLE = nameof(Orders.OrderStyle);
            string ORDER_TOTAL = nameof(Orders.OrderTotal);
            string OWNER_REF = nameof(Orders.OwnerRef);
            string PAYMENT_TYPE = nameof(Orders.PaymentType);
            string IS_ACTİVE = nameof(Orders.IsActive);
            string CREATED_DATE = nameof(Orders.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(SRC_NAME)) {
                model.SrcName = Convert.ToString(values[SRC_NAME]);
            }

            if(values.Contains(ORDER_SESSİON_ID)) {
                model.OrderSessionId = Convert.ToString(values[ORDER_SESSİON_ID]);
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

            if(values.Contains(FİNANCE_REF)) {
                model.FinanceRef = values[FİNANCE_REF] != null ? Convert.ToInt32(values[FİNANCE_REF]) : (int?)null;
            }

            if(values.Contains(DELİVERY_ADDRESS)) {
                model.DeliveryAddress = values[DELİVERY_ADDRESS] != null ? Convert.ToInt32(values[DELİVERY_ADDRESS]) : (int?)null;
            }

            if(values.Contains(DELİVERY_COMPANY)) {
                model.DeliveryCompany = Convert.ToString(values[DELİVERY_COMPANY]);
            }

            if(values.Contains(DİSCOUNT)) {
                model.Discount = values[DİSCOUNT] != null ? Convert.ToDecimal(values[DİSCOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(DİSCOUNT_TYPE)) {
                model.DiscountType = values[DİSCOUNT_TYPE] != null ? Convert.ToInt32(values[DİSCOUNT_TYPE]) : (int?)null;
            }

            if(values.Contains(ORDER_DİSCOUNT)) {
                model.OrderDiscount = values[ORDER_DİSCOUNT] != null ? Convert.ToDecimal(values[ORDER_DİSCOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(FİCHE_TOTAL)) {
                model.FicheTotal = values[FİCHE_TOTAL] != null ? Convert.ToDecimal(values[FİCHE_TOTAL], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(INVOİCE_ADDRESS)) {
                model.InvoiceAddress = values[INVOİCE_ADDRESS] != null ? Convert.ToInt32(values[INVOİCE_ADDRESS]) : (int?)null;
            }

            if(values.Contains(IS_APPROVED)) {
                model.IsApproved = values[IS_APPROVED] != null ? Convert.ToBoolean(values[IS_APPROVED]) : (bool?)null;
            }

            if(values.Contains(IS_CHARGED)) {
                model.IsCharged = values[IS_CHARGED] != null ? Convert.ToBoolean(values[IS_CHARGED]) : (bool?)null;
            }

            if(values.Contains(IS_DİSCOUNT)) {
                model.IsDiscount = values[IS_DİSCOUNT] != null ? Convert.ToBoolean(values[IS_DİSCOUNT]) : (bool?)null;
            }

            if(values.Contains(IS_GİFT_PACKAGE)) {
                model.IsGiftPackage = values[IS_GİFT_PACKAGE] != null ? Convert.ToBoolean(values[IS_GİFT_PACKAGE]) : (bool?)null;
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

            if(values.Contains(IS_ACTİVE)) {
                model.IsActive = values[IS_ACTİVE] != null ? Convert.ToBoolean(values[IS_ACTİVE]) : (bool?)null;
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