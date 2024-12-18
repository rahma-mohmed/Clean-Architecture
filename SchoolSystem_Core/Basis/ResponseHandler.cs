using Microsoft.Extensions.Localization;
using SchoolSystem_Core.SharedResources;

namespace SchoolSystem_Core.Basis
{
	public class ResponseHandler
	{
		#region Feilds
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructor
		public ResponseHandler(IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
		}
		#endregion

		#region Handle Function
		public Response<T> Deleted<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = Message == null ? _stringLocalizer[SharedResourcesKeys.BadRequest] : Message
			};
		}
		public Response<T> Success<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.OK,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKeys.Success],
				Meta = Meta
			};
		}
		public Response<T> Unauthorized<T>()
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.Unauthorized,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKeys.Unauthorized]
			};
		}
		public Response<T> BadRequest<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.BadRequest,
				Succeeded = false,
				Message = Message == null ? _stringLocalizer[SharedResourcesKeys.BadRequest] : Message
			};
		}

		public Response<T> UnProcessableEntity<T>(string Message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
				Succeeded = false,
				Message = Message == null ? _stringLocalizer[SharedResourcesKeys.Unprocessable] : Message
			};
		}

		public Response<T> NotFound<T>(string message = null)
		{
			return new Response<T>()
			{
				StatusCode = System.Net.HttpStatusCode.NotFound,
				Succeeded = false,
				Message = message == null ? _stringLocalizer[SharedResourcesKeys.NotFound] : message
			};
		}

		public Response<T> Created<T>(T entity, object Meta = null)
		{
			return new Response<T>()
			{
				Data = entity,
				StatusCode = System.Net.HttpStatusCode.Created,
				Succeeded = true,
				Message = _stringLocalizer[SharedResourcesKeys.Created],
				Meta = Meta
			};
		}
		#endregion
	}
}
