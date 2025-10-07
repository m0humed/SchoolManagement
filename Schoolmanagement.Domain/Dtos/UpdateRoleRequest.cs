namespace Schoolmanagement.Domain.Dtos
{
    public class UpdateRoleRequest
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; } = string.Empty;

    }
}
