// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using AutoMapper;
    using Config;
    using Core.Util;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using UserModule.Service;

    /// <summary>
    ///     Represents a controller for user login.
    /// </summary>
    [Route("api")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {        
        private readonly JwtConfig _jwtConfig;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="jwtOptions">The JWT options.</param>
        /// <param name="mapper">The mapper service.</param>
        public LoginController(IUserService userService, IOptions<JwtConfig> jwtOptions, IMapper mapper)
        {
            _userService = Check.NotNull(userService, nameof(userService));
            _jwtConfig = Check.NotNull(jwtOptions, nameof(jwtOptions)).Value;
            _mapper = Check.NotNull(mapper, nameof(mapper));
        }

        /// <summary>
        ///     Authenticates user.
        /// </summary>
        /// <param name="loginDto">A login and password for the user.</param>
        /// <returns>The result of authentication.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<LoginResultDto> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userService.LoginAsync(loginDto.Login, loginDto.Password);
            if (user == null)
            {
                return new LoginResultDto {ErrorMessage = "Login or password is incorrect"};
            }

            var claims = new[] {new Claim(JwtRegisteredClaimNames.Typ, Constants.JwtClaim)};
            var key = new SymmetricSecurityKey(_jwtConfig.KeyBytes);
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtConfig.Issuer,
                                             _jwtConfig.Audience,
                                             claims,
                                             null,
                                             DateTime.Now.AddMinutes(30),
                                             signingCredentials);

            var loginResultDto = new LoginResultDto
            {
                User = _mapper.Map<UserDto>(user),
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ErrorMessage = string.Empty
            };

            return loginResultDto;
        }
    }
}