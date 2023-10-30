namespace Ecom.Core.DTOs.Account
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        internal UserDto()
        { }

        public UserDto(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}