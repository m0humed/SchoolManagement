using Schoolmanagement.Domain.Entities;

namespace SchoolManagement.Service.IServices
{
    public interface IClassService : IService<Class, Guid>
    {
        public Task<bool> ExistsByStageAndClassNumberAsync(byte Stage, byte ClassNumber, Guid Id);
    }
}
