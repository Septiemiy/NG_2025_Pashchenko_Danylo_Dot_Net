namespace Task_1.Models
{
    public class LoginDataBaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public LoginDataBaseModel(int id, string username, string password, bool isAdmin)
        {
            Id = id;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
