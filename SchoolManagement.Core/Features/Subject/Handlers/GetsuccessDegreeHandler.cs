using AutoMapper;
using MediatR;
using SchoolManagement.Core.Features.Subject.Queries;
using SchoolManagement.Core.Features.Subject.Results;
using SchoolManagement.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Features.Subject.Handlers
{
    public class GetsuccessDegreeHandler : IRequestHandler<GetSuccessDegreeQuery, SubjectSuccessDegreesResponse>
    {
        #region Fields
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;
        #endregion

        #region CTOR
        public GetsuccessDegreeHandler(ISubjectService subjectService , IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        #endregion

        #region Methods
        public async Task<SubjectSuccessDegreesResponse> Handle(GetSuccessDegreeQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            { 
                throw new ArgumentNullException(nameof(request));
            }
            if (request.subjectId == Guid.Empty)
            {
                throw new Exception("Empty ID");
            }
            var subject = await _subjectService.GetByIdAsync(request.subjectId);
            if (subject == null)
            { 
                throw new Exception($"Subject id {request.subjectId} Not valid");
            }
            var mapped = _mapper.Map<SubjectSuccessDegreesResponse>(subject);
        
            return mapped;
            
        }
        #endregion


    }
}
