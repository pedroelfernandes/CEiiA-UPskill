using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IRolesServices
    {
        Task<List<Role>> Get();
    }
}
