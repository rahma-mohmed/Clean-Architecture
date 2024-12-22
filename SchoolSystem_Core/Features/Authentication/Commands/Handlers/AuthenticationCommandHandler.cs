﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Authentication.Commands.Models;
using SchoolSystem_Data.Helper;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Core.Features.Authentication.Commands.Handlers
{
	public class AuthenticationCommandHandler : ResponseHandler
		, IRequestHandler<SignInCommand, Response<JwtAuthResult>>
		, IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
	{

		#region Fields
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		private readonly UserManager<SchoolSystem_Data.Entities.Identity.User> _userManager;
		private readonly SignInManager<SchoolSystem_Data.Entities.Identity.User> _signInManager;
		private readonly IAuthenticationService _authorizationService;
		#endregion

		#region Constructor
		public AuthenticationCommandHandler(IAuthenticationService authorizationService, SignInManager<SchoolSystem_Data.Entities.Identity.User> signInManager, UserManager<SchoolSystem_Data.Entities.Identity.User> userManager, IStringLocalizer<SharedResources.SharedResources> stringLocalizer) : base(stringLocalizer)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_stringLocalizer = stringLocalizer;
			_authorizationService = authorizationService;
		}
		#endregion

		#region Handle Functions
		public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			//checked if user is ExistsExpression or not => return username is not found
			var user = await _userManager.FindByNameAsync(request.UserName);
			if (user == null) { return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResources.SharedResourcesKeys.UserNameNotExist]); }
			// try to sign in => password is wrong
			var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResources.SharedResourcesKeys.PasswordNotCorrect]);
			// generate token
			var accessToken = await _authorizationService.GetJWTToken(user);

			return Success(accessToken);
		}

		public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
		{
			var res = await _authorizationService.GetRefreshToken(request.AccessToken, request.RefreshToken);
			return Success(res);
		}
		#endregion
	}
}
