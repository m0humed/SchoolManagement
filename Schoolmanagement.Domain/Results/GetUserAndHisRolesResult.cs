namespace Schoolmanagement.Domain.Results
{
    public class GetUserAndHisRolesResult
    {
        public string UserName { get; set; } = null!;
        public List<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }

    public class UserRoles
    {
        public string RoleId { get; set; } = null!;
        public string RoleName { get; set; } = null!;

        public bool HasRole { get; set; }
    }
}
