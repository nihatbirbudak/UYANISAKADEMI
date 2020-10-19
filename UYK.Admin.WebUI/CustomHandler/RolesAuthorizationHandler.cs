using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UYK.WebUI.Admin.Core;

namespace UYK.WebUI.Admin.CustomHandler
{
    public class RolesAuthorizationHandler :
        AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            RolesAuthorizationRequirement requirement)
        {

            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var validRole = false;

            if (requirement.AllowedRoles == null ||
               requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var claims = context.User.Claims;
                var CustomerDTO = UYKConvert.UYKJsonDeSerializeUserDTO(claims.FirstOrDefault(z => z.Type == "CustomerDTO").Value);
                var roles = requirement.AllowedRoles;

                if (roles.Contains(CustomerDTO.RoleDTO.RoleName))
                {
                    validRole = true;
                }
            }
            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;

        }
    }
}
