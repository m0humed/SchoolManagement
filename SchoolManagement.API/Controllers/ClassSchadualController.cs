using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Base;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSchadualController : AppController
    {
        #region Fields
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public ClassSchadualController(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        //[HttpPost("")]

    }
}
