using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;// sonra silll
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;// sill
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Extensions;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()

        {
            UserForLoginDto userForLoginDto = new UserForLoginDto();
            if (HttpContext.Session.GetObject<UserForLoginDto>("userForLoginDto") != null)
            {
                var model = HttpContext.Session.GetObject<UserForLoginDto>("userForLoginDto");
                if (model.Remember)
                {
                    userForLoginDto = model;
                }
            }
            return View(userForLoginDto);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {

            if (_userService.GetByUserName(userForLoginDto.UserName) == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                User user = _userService.GetByUserName(userForLoginDto.UserName);

                if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                {
                    HttpContext.Session.SetObject("userForLoginDto", userForLoginDto);

                    var claims = new List<Claim>{new Claim(ClaimTypes.Name,userForLoginDto.UserName)};
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction ("Index", "Stock");
                   
                    
                }
                else
                {
                    return RedirectToAction("Login", "Auth");
                }
            }
            
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
 
            return RedirectToAction("Login", "Auth");
        }
    }
}

