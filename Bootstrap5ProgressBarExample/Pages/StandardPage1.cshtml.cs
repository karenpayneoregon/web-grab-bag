using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bootstrap5ProgressBarExample.Pages;


using Microsoft.AspNetCore.Mvc.RazorPages;

public class StandardPage1Model : PageModel
{
    public int Progress { get; private set; }
    private const string CookieName = "ProgressStart";

    public void OnGet(bool refresh = false)
    {
        if (!refresh || !Request.Cookies.TryGetValue(CookieName, out var value) ||
            !DateTimeOffset.TryParse(value, out var startTime))
        {
            startTime = DateTimeOffset.UtcNow;

            Response.Cookies.Delete(CookieName);

            Response.Cookies.Append(CookieName, startTime.ToString("O"),
                new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    IsEssential = true
                });
        }

        var elapsed = DateTimeOffset.UtcNow - startTime;

        Progress = Math.Clamp((int)(elapsed.TotalSeconds / 10) * 10, 0, 100);

        if (Progress < 100)
        {
            Response.Headers["Refresh"] = "10;url=/StandardPage1?refresh=true";
        }
        else
        {
            Response.Cookies.Delete(CookieName);
        }
    }
}
