using RetroBack.Application.Models;
using RetroBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Application.QueryProjections.Mappers
{
    public static class ApplicationUserMappers
    {
        public static IQueryable<ApplicationUserDto> ProjectToDto(this IQueryable<ApplicationUser> query) => query.Select(u => new ApplicationUserDto
        {
            DisplayName = u.DisplayName,
            Email = u.Email,
            EmailConfirmed = u.EmailConfirmed,
            FirstName = u.FirstName,
            Id = u.Id,
            LastName = u.LastName,
            Roles = u.UserRoles.Select(ur => ur.Role.Name).ToArray(),
            IsDisabledByAdmin = u.IsDisabledByAdmin
        });
    }
}
