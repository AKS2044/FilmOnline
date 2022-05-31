using FilmOnline.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FilmOnline.WebApi.Attributes
{
    /// <summary>
    /// Own authorize attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class OwnAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserModel)context.HttpContext.Items["User"];
            if (user is null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

            if (user.Role != "Admin")
            {
                // not logged in
                context.Result = new JsonResult(new { message = "You are not admin" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}