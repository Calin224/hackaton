using System;
using System.Security.Authentication;
using System.Security.Claims;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;


public static class ClaimsPrincipleExtensions
{
    public static async Task<AppUser> GetUserByEmail(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
        var userToReturn = await userManager.Users.FirstOrDefaultAsync(x => x.Email == user.GetEmail());
        return userToReturn ?? throw new AuthenticationException("User not found!");
    }
    public static string GetEmail(this ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email);
        return email ?? throw new AuthenticationException("Email claim not found!");
    }
}

