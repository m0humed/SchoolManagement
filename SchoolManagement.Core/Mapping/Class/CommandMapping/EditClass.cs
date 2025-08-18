using SchoolManagement.Core.Features.Class.Commands;

namespace SchoolManagement.Core.Mapping.Class
{
    using Schoolmanagement.Domain.Entities;

    public partial class ClassProfile
    {
        public void mappingEditClass()
        {
            CreateMap<EditClassCommand, Class>();
        }

    }
}
