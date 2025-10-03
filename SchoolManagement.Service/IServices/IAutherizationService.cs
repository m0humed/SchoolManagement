using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Service.IServices
{
    public interface IAutherizationService : IService<IdentityRole, string>
    {
    }
}
