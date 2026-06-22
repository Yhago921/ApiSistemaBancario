using Api.Data;
using Api.DTO;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Azure.Core.Pipeline;
namespace Api.Services.UserS
{
    public class UserService : IUserInterface
    {
        private readonly AppDBContext context;
        public UserService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<ResponseModel<User>> DeleteUserById(int idUser)
        {
            ResponseModel<User> response = new();
            try
            {
                var user = await this.context.Users.FirstOrDefaultAsync(user => user.Id == idUser);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                this.context.Users.Remove(user);
                await this.context.SaveChangesAsync();

                response.Data = user;
                response.Message = "User deleted";
                response.Status = true;

                return response;
            }catch(Exception error)
            {
                response.Message = error.Message;
                response.Status = true;
                return response;
            }
        }
        public async Task<ResponseModel<User>> CreateUser(UserDto userDto)
        {
            ResponseModel<User> response = new();
            try
            {

            var users = await this.context.Users.ToListAsync();

            if(users.FirstOrDefault(user => user.Email == userDto.Email) != null)
                {
                  throw new Exception("Email already is used");
                 
                } 
            if(users.FirstOrDefault(user => user.Phone == userDto.Phone) != null)
                {
                  throw new Exception("This Phone already is used");
                  
                } 

            var user = new User()
            {
              Name = userDto.Name,
              Email = userDto.Email,
              Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
              Phone = userDto.Phone,
              Role = userDto.Role,
            };
            
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            response.Data = user;
            response.Message = "Success";
            response.Status = true;

            return response;
            }catch(Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<User>>> ListUser()
        {
            ResponseModel<List<User>> response = new();
            try
            {
             response.Data = await this.context.Users.ToListAsync();
             response.Message = "Success";
             response.Status = true;
             return response;
            }
            catch (Exception error)
            {
              response.Message = error.Message;
              response.Status = false;
              return response;
            }
        }

        public async Task<ResponseModel<User>> ListUserbyId(int userId)
        {
            ResponseModel<User> response = new();
            try
            {

                if (userId <=0)
                {
                    response.Message = "Id Inválido!";
                    return response;
                }
             var findUser = await this.context.Users.FirstOrDefaultAsync(user => user.Id == userId);
             if(findUser == null)
                {
                    response.Message = "Nenhum Utilizador encontrado com este Id";
                    return response;
                }

            response.Data = findUser;
            response.Message = "Success";
            response.Status = true;
            return response;

            }catch(Exception error)
            {
                response.Message = error.Message;
                response.Status = false;
                return response;
            }
        }
    }
}