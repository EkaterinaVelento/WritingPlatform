namespace Models.Users
{
    public class UserModel : IdentityModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
    }
}