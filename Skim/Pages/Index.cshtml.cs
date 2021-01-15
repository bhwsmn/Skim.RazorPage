using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Skim.Helpers;
using Skim.Services;

namespace Skim.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISkimService _skimService;
        
        [BindProperty] 
        public Uri FullLink { get; set; }

        public IndexModel(ISkimService skimService)
        {
            _skimService = skimService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var hostDomain = HttpContext.Request.Host;
            var slug = RouteData.Values["slug"];

            if (slug == null)
            {
                return Page();
            }

            var shortLink = await _skimService.GetShortLinkAsync(slug.ToString());

            if (shortLink == null)
            {
                return Redirect($"http://{hostDomain}");
            }

            return Redirect(shortLink.FullLink);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var hostDomain = HttpContext.Request.Host;
            
            if (!ModelState.IsValid || 
                !Validator.IsValidUrl(FullLink.ToString()) ||
                FullLink.Host == hostDomain.Host)
            {
                return Page();
            }

            var createdShortLink = await _skimService.CreateShortLinkAsync(FullLink.ToString());

            if (createdShortLink != null)
            {
                FullLink = new Uri($"https://{hostDomain}/{createdShortLink.Slug}");
            }
            
            ModelState.Clear();
            return Page();
        }
    }
}