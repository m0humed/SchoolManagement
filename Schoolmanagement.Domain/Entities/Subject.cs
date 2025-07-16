using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolmanagement.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Titel { get; set; } = null!;

        public short fullMarks { get; set; }

        public short passMarks { get; set; }
        
        public Subject()
        {
            Id = Guid.NewGuid();
        }
    }
}
