using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTA.Database.Models;
using IOTA.Database.Implements;
using IOTA.Models;
using IOTA.Pages.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IOTA.Pages
{
    public class SignLogModel : PageModel
    {
        private readonly EFCoreLoginRepository _loginRepository;

        public SignLogModel(EFCoreLoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [BindProperty(Name = "email", SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty]
        public Login login { get; set; }

        [BindProperty]
        public SignIn signIn { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            signIn = new SignIn()
            {
                Email = (this.Email != null) ? this.Email : null
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string actiontype)
        {
            if (actiontype.Equals("sign-in"))
            {
                Login result = await _loginRepository.GetLogin(signIn);
                if (result != null)
                {
                    return Redirect("/SignLog");
                }
                else
                {
                    return RedirectToPage();
                }
            }
            else
            {
                Login result = await _loginRepository.Add(this.login);
                string Email = result.Email;
                return RedirectToPage("Index", new { email = Email });
            }
        }
    }
}