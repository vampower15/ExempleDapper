namespace ExempleDapper.Models
{
    public class UserRolesModel
    {
        public int Id { get; set; } = 0;
        public int UserId { get; set; } = 0;
        public int RoleId { get; set; } = 0;
        public string RoleName { get; set; } = string.Empty;
    }

    public enum RoleStatus
    {
        Admin = 1,
        Member = 2,
    }
}
