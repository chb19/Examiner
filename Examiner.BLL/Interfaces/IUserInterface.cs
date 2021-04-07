using Examiner.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examiner.BLL.Interfaces
{
    public interface IUserInterface
    {
        UserDTO CurrentUser { get; }
        UserDTO Login(string email, string password);
        public UserDTO SignUp(string firstName, string lastName,
                              string email, string password);
        UserDTO GetUser(Guid? Id);
        void CreateUser(UserDTO userDTO);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
    }
}
