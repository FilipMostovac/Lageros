using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Lageros.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Lageros.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<LagerosUser> _signInManager;
        private readonly UserManager<LagerosUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<LagerosUser> userManager,
            SignInManager<LagerosUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Ime je obavezno!")]
            [DataType(DataType.Text)]
            [Display(Name = "Ime")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Prezime je obavezno!")]
            [DataType(DataType.Text)]
            [Display(Name = "Prezime")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email adresa je obavezna!")]
            [EmailAddress(ErrorMessage = "Mail adresa nije dobrog oblika!")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Lozinka je obavezna!")]
            [StringLength(100, ErrorMessage = "Lozinka {0} mora sadržavati najmanje {2} a najviše {1} simbola!", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lozinka")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Potvrda lozinke")]
            [Compare("Password", ErrorMessage = "Lozinka i potvrda lozinke se ne podudaraju!")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/");
            }
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new LagerosUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

                    ModelState.AddModelError("", "Lozinka mora sadržavati najmanje jedan znak koji nije alfanumerički.");
                    ModelState.AddModelError("", "Lozinka mora sadržavati najmanje jednu znamenku ('0'-'9').");
                    ModelState.AddModelError("", "Lozinka mora sadržavati barem jedno veliko slovo ('A'-'Z').");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
