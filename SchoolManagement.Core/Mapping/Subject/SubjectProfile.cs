using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Mapping.Subject
{
    public partial class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            MapSucessDegree();
        }
    }
}
