using System.Collections.Generic;
using System.ServiceModel;
using WcfService.Dto;

namespace WcfService.Interfaces
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface IUserService
    {
        [OperationContract]
        List<UserDto> Get();

        [OperationContract]
        UserDto GetUserById(int Id);

        [OperationContract]
        bool InsertUser(UserDto User);

        [OperationContract]
        void UpdateUser(UserDto User);

        [OperationContract]
        void DeleteUser(int Id);
    }
}
