using Microsoft.EntityFrameworkCore;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.IRepositories;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class ClassSchadualRepository : GenaricRepository<ClassSchadual, Guid>, IClassSchadualRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion
        public ClassSchadualRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByClassIdAsync(Guid classId)
        {
            var schaduals = _context.classSchaduals.Include(c => c.Class).Include(s => s.Teacher).Where(cs => cs.ClassId == classId);
            var orderSchadual = await schaduals.OrderBy(x => x.DayOfWeek).ThenBy(x => x.StartTime).ToListAsync();
            return orderSchadual;
        }

        public async Task<IEnumerable<ClassSchadual>> GetSchadualByTeacherIdAsync(string teacherId)
        {
            var schadual = _context.classSchaduals.Where(cs => cs.TeacherId.Equals(teacherId));
            var orderSchadual = await schadual.OrderBy(x => x.DayOfWeek).ThenBy(x => x.StartTime).ToListAsync();
            return orderSchadual;
        }
    }
}
