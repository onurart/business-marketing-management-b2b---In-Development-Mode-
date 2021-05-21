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
    public class ApiItemsController : Controller
    {
        private TradeDbContext _context;

        public ApiItemsController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var ıtems = _context.Items.Select(i => new {
                i.Id,
                i.Code,
                i.Name,
                i.StockAmount,
                i.Description,
                i.IsCampaignItem,
                i.IsCategoryItem,
                i.IsDiscounted,
                i.IsMainItem,
                i.IsWebItem,
                i.IsDealer,
                i.IsQuickDelivery,
                i.IsNewSeason,
                i.IsStockTracking,
                i.Mark,
                i.ModifiedDate,
                i.ModifiedUser,
                i.Owner,
                i.Specode,
                i.Type,
                i.IsActive,
                i.CreatedDate
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(ıtems, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Items();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Items.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Items.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Items.FirstOrDefaultAsync(item => item.Id == key);

            _context.Items.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> MarksLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Marks
                         orderby i.Code
                         select new {
                             Value = i.Id,
                             Text = i.Code
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Items model, IDictionary values) {
            string ID = nameof(Items.Id);
            string CODE = nameof(Items.Code);
            string NAME = nameof(Items.Name);
            string STOCK_AMOUNT = nameof(Items.StockAmount);
            string DESCRİPTİON = nameof(Items.Description);
            string IS_CAMPAİGN_ITEM = nameof(Items.IsCampaignItem);
            string IS_CATEGORY_ITEM = nameof(Items.IsCategoryItem);
            string IS_DİSCOUNTED = nameof(Items.IsDiscounted);
            string IS_MAİN_ITEM = nameof(Items.IsMainItem);
            string IS_WEB_ITEM = nameof(Items.IsWebItem);
            string IS_DEALER = nameof(Items.IsDealer);
            string IS_QUİCK_DELİVERY = nameof(Items.IsQuickDelivery);
            string IS_NEW_SEASON = nameof(Items.IsNewSeason);
            string IS_STOCK_TRACKİNG = nameof(Items.IsStockTracking);
            string MARK = nameof(Items.Mark);
            string MODİFİED_DATE = nameof(Items.ModifiedDate);
            string MODİFİED_USER = nameof(Items.ModifiedUser);
            string OWNER = nameof(Items.Owner);
            string SPECODE = nameof(Items.Specode);
            string TYPE = nameof(Items.Type);
            string IS_ACTİVE = nameof(Items.IsActive);
            string CREATED_DATE = nameof(Items.CreatedDate);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(CODE)) {
                model.Code = Convert.ToString(values[CODE]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(STOCK_AMOUNT)) {
                model.StockAmount = values[STOCK_AMOUNT] != null ? Convert.ToDecimal(values[STOCK_AMOUNT], CultureInfo.InvariantCulture) : (decimal?)null;
            }

            if(values.Contains(DESCRİPTİON)) {
                model.Description = Convert.ToString(values[DESCRİPTİON]);
            }

            if(values.Contains(IS_CAMPAİGN_ITEM)) {
                model.IsCampaignItem = values[IS_CAMPAİGN_ITEM] != null ? Convert.ToBoolean(values[IS_CAMPAİGN_ITEM]) : (bool?)null;
            }

            if(values.Contains(IS_CATEGORY_ITEM)) {
                model.IsCategoryItem = values[IS_CATEGORY_ITEM] != null ? Convert.ToBoolean(values[IS_CATEGORY_ITEM]) : (bool?)null;
            }

            if(values.Contains(IS_DİSCOUNTED)) {
                model.IsDiscounted = values[IS_DİSCOUNTED] != null ? Convert.ToBoolean(values[IS_DİSCOUNTED]) : (bool?)null;
            }

            if(values.Contains(IS_MAİN_ITEM)) {
                model.IsMainItem = values[IS_MAİN_ITEM] != null ? Convert.ToBoolean(values[IS_MAİN_ITEM]) : (bool?)null;
            }

            if(values.Contains(IS_WEB_ITEM)) {
                model.IsWebItem = values[IS_WEB_ITEM] != null ? Convert.ToBoolean(values[IS_WEB_ITEM]) : (bool?)null;
            }

            if(values.Contains(IS_DEALER)) {
                model.IsDealer = values[IS_DEALER] != null ? Convert.ToBoolean(values[IS_DEALER]) : (bool?)null;
            }

            if(values.Contains(IS_QUİCK_DELİVERY)) {
                model.IsQuickDelivery = values[IS_QUİCK_DELİVERY] != null ? Convert.ToBoolean(values[IS_QUİCK_DELİVERY]) : (bool?)null;
            }

            if(values.Contains(IS_NEW_SEASON)) {
                model.IsNewSeason = values[IS_NEW_SEASON] != null ? Convert.ToBoolean(values[IS_NEW_SEASON]) : (bool?)null;
            }

            if(values.Contains(IS_STOCK_TRACKİNG)) {
                model.IsStockTracking = values[IS_STOCK_TRACKİNG] != null ? Convert.ToBoolean(values[IS_STOCK_TRACKİNG]) : (bool?)null;
            }

            if(values.Contains(MARK)) {
                model.Mark = values[MARK] != null ? Convert.ToInt32(values[MARK]) : (int?)null;
            }

            if(values.Contains(MODİFİED_DATE)) {
                model.ModifiedDate = values[MODİFİED_DATE] != null ? Convert.ToDateTime(values[MODİFİED_DATE]) : (DateTime?)null;
            }

            if(values.Contains(MODİFİED_USER)) {
                model.ModifiedUser = values[MODİFİED_USER] != null ? Convert.ToInt32(values[MODİFİED_USER]) : (int?)null;
            }

            if(values.Contains(OWNER)) {
                model.Owner = values[OWNER] != null ? Convert.ToInt32(values[OWNER]) : (int?)null;
            }

            if(values.Contains(SPECODE)) {
                model.Specode = Convert.ToString(values[SPECODE]);
            }

            if(values.Contains(TYPE)) {
                model.Type = values[TYPE] != null ? Convert.ToInt32(values[TYPE]) : (int?)null;
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