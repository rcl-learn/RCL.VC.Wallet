#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RCL.VC.Wallet.Core;

namespace RCL.VC.Wallet.WebApplication.Areas.Holder.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IHolderService _holderService;

        [BindProperty]
        public Data.Holder Holder { get; set; } = new Data.Holder();
        public string ErrorMessage { get; set; } = string.Empty;

        public CreateModel(IHolderService holderService)
        {
            _holderService = holderService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ErrorMessage = "Data input was not valid";

                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var modelError in modelState.Errors)
                        {
                            ErrorMessage = $"{ErrorMessage},{modelError.ErrorMessage}";
                        }
                    }
                }
                else
                {
                    Holder.username = User.Identity.Name;
                    Holder.status = "Approval Pending";

                    var newHolder = await _holderService.CreateHolderAsync(Holder);

                    if (string.IsNullOrEmpty(newHolder?.name))
                    {
                        ErrorMessage = "Could not create Holder Profile";
                    }
                    else
                    {
                        return RedirectToPage("./Details");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }
    }
}
