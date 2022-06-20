using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAPIUserServices
    {
        Task<List<APIUser>> Get();

        Task<APIUser> GetAPIUserById(int id);

        Task<APIUser> Create(APIUser apiUser);

        Task<APIUser> Edit(APIUser apiUser);

        Task<bool> ChangeState(int id);
    }
}
