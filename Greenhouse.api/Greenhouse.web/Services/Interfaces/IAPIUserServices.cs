using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAPIUserServices
    {
        //Task<IEnumerable<APIUser>> GetAllAPIUser();

        Task<APIUser> Create(APIUser apiUser);

        Task<List<APIUser>> Get();

        //Task<APIUser> Edit(APIUser apiUser);

        //Task <bool> ChangeState(int id);
    }
}
