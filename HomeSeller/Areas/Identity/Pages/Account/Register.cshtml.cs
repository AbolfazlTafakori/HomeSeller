﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using HomeSeller.Models;
using HomeSeller.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeSeller.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly IUserStore<UserModel> _userStore;


        public RegisterModel(
            UserManager<UserModel> userManager,
            IUserStore<UserModel> userStore,
            SignInManager<UserModel> signInManager)

        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;

        }


        [BindProperty]
        public RegisterViewModel Input { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            Input = new() 
            {
                ReturnUrl = returnUrl
            };
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                user.Email = Input.Email;
                user.FullName = Input.FullName;
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
        private UserModel CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UserModel>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UserModel)}'. " +
                    $"Ensure that '{nameof(UserModel)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
