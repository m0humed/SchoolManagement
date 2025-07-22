using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Results
{
    public class SubjectSuccessDegreesResponse
    {
        public Guid Id { get; set; }
        public string Titel { get; set; } = null!;

        public short passMarks { get; set; }

    }
}
