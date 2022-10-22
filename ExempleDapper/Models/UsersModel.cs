namespace ExempleDapper.Models
{
    public class UsersModel
    {
        public int UserId { get; set; } = 0;
        public string UserName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public int StatusId { get; set; } = 0;
        public UserRolesModel? Role { get; set; }
        public StatusModel? Status { get; set; }

    }   
}
