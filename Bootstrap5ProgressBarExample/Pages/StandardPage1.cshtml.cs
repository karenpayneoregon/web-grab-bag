using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bootstrap5ProgressBarExample.Pages;


using Microsoft.AspNetCore.Mvc.RazorPages;

public class StandardPage1Model : PageModel
{
    public int Progress { get; private set; }

    public void OnGet()
    {
        const string cookieName = "ProgressStart";

        if (!Request.Cookies.TryGetValue(cookieName, out var startValue) ||
            !DateTimeOffset.TryParse(startValue, out var startTime))
        {
            startTime = DateTimeOffset.UtcNow;

            Response.Cookies.Append(cookieName, startTime.ToString("O"),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax
                });
        }

        var elapsed = DateTimeOffset.UtcNow - startTime;

        Progress = Math.Clamp((int)(elapsed.TotalSeconds / 10) * 10, 0, 100);

        if (Progress < 100)
        {
            Response.Headers["Refresh"] = "10";
        }
        else
        {
            Response.Cookies.Delete(cookieName);
        }
    }
}
