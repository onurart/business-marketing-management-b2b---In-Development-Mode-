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
    public class ApiUserToRolesController : Controller
    {
        private TradeDbContext _context;

        public ApiUserToRolesController(TradeDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var usertoroles = _context.UserToRoles.Select(i => new {
                i.RoleId,
                i.UserId
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "RoleId", "UserId" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(usertoroles, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new UserToRoles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.UserToRoles.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.RoleId, result.Entity.UserId });
        }

        [HttpPut]
        public async Task<IActionResult> Put(string key, string values) {
            var keys = JsonConvert.DeserializeObject<IDictionary>(key);
            var keyRoleId = Convert.ToInt32(keys["RoleId"]);
            var keyUserId = Convert.ToInt32(keys["UserId"]);
            var model = await _context.UserToRoles.FirstOrDefaultAsync(item =>
                            item.RoleId == keyRoleId && 
                            item.UserId == keyUserId);
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
            var keyRoleId = Convert.ToInt32(keys["RoleId"]);
            var keyUserId = Convert.ToInt32(keys["UserId"]);
            var model = await _context.UserToRoles.FirstOrDefaultAsync(item =>
                            item.RoleId == keyRoleId && 
                            item.UserId == keyUserId);

            _context.UserToRoles.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> RolesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Roles
                         orderby i.RoleName
                         select new {
                             Value = i.Id,
                             Text = i.RoleName
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

        private void PopulateModel(UserToRoles model, IDictionary values) {
            string ROLE_ID = nameof(UserToRoles.RoleId);
            string USER_ID = nameof(UserToRoles.UserId);

            if(values.Contains(ROLE_ID)) {
                model.RoleId = Convert.ToInt32(values[ROLE_ID]);
            }

            if(values.Contains(USER_ID)) {
                model.UserId = Convert.ToInt32(values[USER_ID]);
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