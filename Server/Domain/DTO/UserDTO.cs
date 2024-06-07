using Server.Domain.Model;
using System.Collections.Generic;

namespace Server.Domain.DTO
{
    internal class UserDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public UserType UserType { get;  set; }
        public string Phone { get;  set; }

        // Default constructor made private to enforce the use of the builder
        private UserDTO() { }

        // Constructor to initialize the DTO from a User entity
        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            UserType = user.UserType;
            Phone = user.Phone;
        }

        public UserDTO(int id, string name, string email, string password, UserType userType, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"UserDTO with id {Id} and name {Name} has email {Email} and is of type {UserType} and has phone number {Phone}.";
        }

        // Converts a list of User entities to a list of UserDTOs
        public static List<UserDTO> FromUserList(List<User> users)
        {
            var userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(new UserDTO(user));
            }
            return userDTOs;
        }

        // Builder class
        public class Builder
        {
            private readonly UserDTO _userDTO;

            public Builder()
            {
                _userDTO = new UserDTO();
            }

            public Builder SetId(int id)
            {
                _userDTO.Id = id;
                return this;
            }

            public Builder SetName(string name)
            {
                _userDTO.Name = name;
                return this;
            }

            public Builder SetEmail(string email)
            {
                _userDTO.Email = email;
                return this;
            }

            public Builder SetPassword(string password)
            {
                _userDTO.Password = password;
                return this;
            }

            public Builder SetUserType(UserType userType)
            {
                _userDTO.UserType = userType;
                return this;
            }

            public Builder SetPhone(string phone)
            {
                _userDTO.Phone = phone;
                return this;
            }

            public UserDTO Build()
            {
                return _userDTO;
            }
        }
    }
}
