using Api.DTO;
using Api.Models;
using Azure;

namespace Api.Services.UserS
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<User>>> ListUser();
        Task<ResponseModel<User>> ListUserbyId(int  userId);
        Task<ResponseModel<User>> CreateUser(UserDto userDto);
        Task<ResponseModel<User>> DeleteUserById(int idUser);
    }
}