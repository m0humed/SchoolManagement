using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schoolmanagement.Domain.Entities;
using SchoolManagement.Core.Features.Subject.Commands;
using SchoolManagement.Core.Features.Subject.Queries;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region CTOR
        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Actions
        [HttpPost]
        [Route("AddSubject")]
        public async Task<IActionResult> Addsubject([FromBody] Subject subject )
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));

            try
            {
                await _mediator.Send(new AddSubjectCommand(subject));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok($"Subject {subject.Titel} Add succefully");
        }

        [HttpGet]
        [Route("GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            try
            {
                var subjets = await _mediator.Send(new GetAllSubjectsQuery());
                return Ok(subjets);
            }
            catch (Exception ex) 
            { 
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetSubjectById")]
        public async Task<IActionResult> GetSubjectById(string id)
        {
            var IsGuid = Guid.TryParse(id, out var GuidResult);
            if (IsGuid)
            {
            
                    var subject = await _mediator.Send(new GetSubjectByIdQuery(GuidResult));
                if (subject == null)
                    return BadRequest("No Subject with this ID");
                
                return Ok(subject);
            }
            return Ok("this Id don't follow Subject Id format");
        }

        [HttpDelete]
        [Route("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(string SubjectId)
        {
            var IsGuid = Guid.TryParse(SubjectId, out var GuidResult);
            if (IsGuid)
            {
                try
                {
                    await _mediator.Send(new DeleteSubjectCommand(GuidResult));
                    return Ok($"Subject with ID {SubjectId} Deleted succefully");
                }
                catch(Exception ex)
                {
                    return BadRequest($"No Subject with this Id{ex.Message}");
                }

            }
            return Ok("this Id don't follow Subject Id format");
        }

        [HttpGet]
        [Route("GetSuccessDegree")]
        public async Task<IActionResult> getSuccessDegree(string SubjectId) 
        {
            var IsGuid = Guid.TryParse(SubjectId, out var GuidResult);
            if (IsGuid)
            {
                try
                {
                    var seccess = await _mediator.Send(new GetSuccessDegreeQuery(GuidResult));
                    return Ok(seccess);
                }
                catch (Exception ex)
                {
                    return BadRequest($"No Subject with this Id{ex.Message}");
                }

            }
            return Ok("this Id don't follow Subject Id format");

        }

        #endregion

    }
}
