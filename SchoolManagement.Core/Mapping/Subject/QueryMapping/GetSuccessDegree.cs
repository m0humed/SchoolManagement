using SchoolManagement.Core.Features.Subject.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Mapping.Subject
{
    using Schoolmanagement.Domain.Entities;

    public partial class SubjectProfile
    {
        private void MapSucessDegree()
        {
            CreateMap<Subject, SubjectSuccessDegreesResponse>();
        }
    }
}
