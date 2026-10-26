using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class ReturnToCallerModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }
        public void OnGet()
        {
        }

        public Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return Task.FromResult<IActionResult>(LocalRedirect(ReturnUrl));
                }

                // Fallback: go to whatever makes sense as a default
                return Task.FromResult<IActionResult>(RedirectToPage("./Index"));
            }
            catch (Exception exception)
            {
                return Task.FromException<IActionResult>(exception);
            }
        }
    }
}
