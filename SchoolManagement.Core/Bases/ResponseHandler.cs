using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Resources;

namespace SchoolManagement.Core.Bases
{
    public class ResponseHandler
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion
        #region constructors

        public ResponseHandler(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        #endregion

        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.Delete]
            };
        }
        public Response<T> Updated<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.Updated]
            };
        }


        public Response<T> Success<T>(T entity, object? Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.Success],
                Meta = Meta
            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.UnAuthorized]
            };
        }
        public Response<T> BadRequest<T>(string? Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public Response<T> NotFound<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? _localizer[SharedResourcesKeys.notFound] : message
            };
        }

        public Response<T> Created<T>(T entity, object? Meta = null!)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.Created],
                Meta = Meta
            };
        }

        public Response<T> ServerError<T>(string? message = null, object? Meta = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Succeeded = false,
                Message = message == null ? _localizer[SharedResourcesKeys.error] : message,
                Meta = Meta
            };
        }
        public Response<T> NullRequest<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NoContent,
                Succeeded = false,
                Message = message == null ? _localizer[SharedResourcesKeys.nullValue] : message
            };
        }
    }


}
