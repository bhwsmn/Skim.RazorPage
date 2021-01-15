using System.Threading.Tasks;
using Skim.Entities;

namespace Skim.Services
{
    public interface ISkimService
    {
        Task<ShortLink> GetShortLinkAsync(string slug);
        Task<ShortLink> CreateShortLinkAsync(string fullLink);
    }
}