using Greenhouse.web.Models;

namespace Greenhouse.web.Services.Interfaces
{
    public interface IAPIUserServices
    {
        //Task<IEnumerable<APIUser>> GetAllAPIUser();

        //Task<APIUser> Create(APIUser apiUser);

        Task<APIUser> Get(int id);

        //Task<APIUser> Edit(APIUser apiUser);

        //Task <bool> ChangeState(int id);
    }
}
