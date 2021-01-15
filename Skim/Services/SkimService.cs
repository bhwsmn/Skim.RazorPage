using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skim.DbContexts;
using Skim.Entities;
using Skim.Helpers;

namespace Skim.Services
{
    public class SkimService : ISkimService
    {
        private readonly SkimContext _context;

        public SkimService(SkimContext context)
        {
            _context = context;
        }
        
        public async Task<ShortLink> GetShortLinkAsync(string slug)
        {
            var shortLink = await _context.ShortLinks.FirstOrDefaultAsync(s => s.Slug == slug);

            return shortLink;
        }

        public async Task<ShortLink> CreateShortLinkAsync(string fullLink)
        {
            var shortLink = new ShortLink
            {
                FullLink = fullLink
            };

            for (var length = 2; length < 100; length++)
            {
                var slug = SlugGenerator.Generate(length);
                if (! await _context.ShortLinks.AnyAsync(s => s.Slug == slug))
                {
                    shortLink.Slug = slug;
                    break;
                }
            }
            
            await _context.ShortLinks.AddAsync(shortLink);
            await _context.SaveChangesAsync();
            
            return shortLink;
        }
    }
}