using MediatR;
using SchoolManagement.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.Features.Class.Commands
{
    public class EditClassCommand : IRequest<Response<bool>>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public byte Stage { get; set; }
        [Required]
        public byte ClassNumber { get; set; }

    }
}
