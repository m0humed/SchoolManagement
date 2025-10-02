using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Schoolmanagement.Domain.Entities.Identity;
using Schoolmanagement.Domain.Helper;
using Schoolmanagement.Domain.Helper.Bind;
using Schoolmanagement.Domain.Results;
using SchoolManagement.Infrastructure.IRepositories;
using SchoolManagement.Service.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagement.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Doblicated
        //#region Fields
        //private readonly JwtSettings _jwtSettings;
        //private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreshToken;
        //private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        //#endregion
        //#region Constrctors
        //public AuthenticationService(JwtSettings jwtSettings, IUserRefreshTokenRepository userRefreshTokenRepository)
        //{
        //    _jwtSettings = jwtSettings;
        //    _refreshTokenRepository = userRefreshTokenRepository;
        //    _UserRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
        //}
        //#endregion

        //public async Task<JwtAuthenticationResult> CreateJWTToken(User user)
        //{
        //    var claims = GetClaims(user);
        //    var jwtToken = new JwtSecurityToken(
        //        _jwtSettings.issuer,
        //        _jwtSettings.audience,
        //        claims,
        //        expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
        //        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.secret)), SecurityAlgorithms.HmacSha256Signature));
        //    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        //    var refreshToken = GetRefreshToken(user.UserName!);
        //    var userRefreshToken = new UserRefreshToken
        //    {
        //        AddedTime = DateTime.Now,
        //        ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
        //        IsUsed = false,
        //        IsRevoked = false,
        //        JwtId = jwtToken.Id,
        //        RefreshToken = refreshToken.TokenString,
        //        Token = accessToken,
        //        UserId = user.Id
        //    };
        //    await _refreshTokenRepository.AddAsync(userRefreshToken);

        //    var response = new JwtAuthenticationResult();
        //    response.RefreshToken = refreshToken;
        //    response.AccountToken = accessToken;
        //    return response;
        //}

        //private RefreshToken GetRefreshToken(string username)
        //{
        //    var refreshToken = new RefreshToken
        //    {
        //        ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
        //        UserName = username,
        //        TokenString = GenerateRefreshToken()
        //    };
        //    _UserRefreshToken.AddOrUpdate(refreshToken.TokenString, refreshToken, (s, t) => refreshToken);
        //    return refreshToken;
        //}
        //private string GenerateRefreshToken()
        //{
        //    var randomNumber = new byte[32];
        //    var randomNumberGenerate = RandomNumberGenerator.Create();
        //    randomNumberGenerate.GetBytes(randomNumber);
        //    return Convert.ToBase64String(randomNumber);
        //}
        //public List<Claim> GetClaims(User user)
        //{
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(nameof(UserClaimModel .UserName),user.UserName),
        //        new Claim(nameof(UserClaimModel.Email),user.Email),
        //        new Claim(nameof(UserClaimModel.PhoneNumber),user.PhoneNumber),

        //    };
        //    return claims;
        //}


        // My Code Without helping 
        #endregion

        #region Fields
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        //private readonly ConcurrentDictionary<string, RefreshToken> _refershToken;
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors

        public AuthenticationService(IUserRefreshTokenRepository userRefreshTokenRepository, JwtSettings jwtSettings, UserManager<User> userManager)
        {
            //_refershToken = new ConcurrentDictionary<string, RefreshToken>();
            _userRefreshTokenRepository = userRefreshTokenRepository;
            _jwtSettings = jwtSettings;
            _userManager = userManager;
        }
        #endregion

        public async Task<JwtAuthenticationResult> CreateJWTToken(User user)
        {

            var jwtToken = await generateToken(user);
            var Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var RefreshToken = GetRefreshToken(user.UserName!);

            var userToken = await _userRefreshTokenRepository.GetTokenByUserId(user.Id);
            if (userToken != null)
            {
                if (userToken.ExpiryDate > DateTime.Now)
                {
                    userToken.Token = Token;
                    RefreshToken.ExpireAt = userToken.ExpiryDate;
                    RefreshToken.TokenString = userToken.RefreshToken!;
                    await _userRefreshTokenRepository.UpdateAsync(userToken);
                }
                else
                {
                    var userRefreshToken = await generateUserRefreshToken(user.Id, jwtToken.Id, RefreshToken.TokenString, Token);
                    await _userRefreshTokenRepository.DeleteAsync(userToken.Id);
                    await _userRefreshTokenRepository.AddAsync(userRefreshToken);
                }
            }
            else
            {
                var userRefreshToken = await generateUserRefreshToken(user.Id, jwtToken.Id, RefreshToken.TokenString, Token);
                await _userRefreshTokenRepository.AddAsync(userRefreshToken);
            }
            var jwtResult = new JwtAuthenticationResult
            {
                RefreshToken = RefreshToken,
                AccountToken = Token,
            };
            return jwtResult;
        }

        private Task<UserRefreshToken> generateUserRefreshToken(string userId, string JwtId, string RefreshToken, string TokenString)
        {
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsRevoked = false,
                IsUsed = true,
                JwtId = JwtId,
                RefreshToken = RefreshToken,
                Token = TokenString,
                UserId = userId,
            };
            return Task.FromResult(userRefreshToken);
        }

        private Task<JwtSecurityToken> generateToken(User user)
        {
            var claim = GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.issuer,
                audience: _jwtSettings.audience,
                claims: claim,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(
                                                                        Encoding.ASCII.GetBytes(_jwtSettings.secret)),
                                                                                          SecurityAlgorithms.HmacSha256Signature)
                );
            return Task.FromResult(jwtToken);
        }



        private List<Claim> GetClaims(User user)
        {

            return new List<Claim>
            {
                new Claim(nameof(User.UserName),user.UserName!),
                new Claim(nameof(User.ssn),user.ssn!),
                new Claim(nameof(User.Email),user.Email!)
            };
        }

        private RefreshToken GetRefreshToken(string Username)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = Username,
                TokenString = GetTokenString()
            };
            //_refershToken.AddOrUpdate(Username, refreshToken, (str, refresh) => refresh);
            return refreshToken;
        }

        private string GetTokenString()
        {
            var RefreshToken = new byte[32];
            var Random = RandomNumberGenerator.Create();
            Random.GetBytes(RefreshToken);
            return Convert.ToBase64String(RefreshToken);
        }

        public async Task<JwtAuthenticationResult> GetRefreshToken(string accessToken, string refreshToken)
        {
            //Read Token To get Cliams
            var jwtToken = ReadJWTToken(accessToken);
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                throw new SecurityTokenException("Algorithm Is Wrong");
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                throw new SecurityTokenException("Token Is not Expired");
            }

            //Get User

            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.Id)).Value;
            var userRefreshToken = (await _userRefreshTokenRepository.GetAllAsync())
                                             .FirstOrDefault(x => x.Token == accessToken &&
                                                                     x.RefreshToken == refreshToken &&
                                                                     x.UserId == userId);
            if (userRefreshToken == null)
            {
                throw new SecurityTokenException("Refresh Token Is Not Found");
            }

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _userRefreshTokenRepository.UpdateAsync(userRefreshToken);
                throw new SecurityTokenException("Refresh Token Is Expired");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new SecurityTokenException("User Is Not Found");
            }
            var jwtSecurityToken = await generateToken(user);
            var newToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var response = new JwtAuthenticationResult();
            response.AccountToken = newToken;
            var refreshTokenResult = new RefreshToken();
            refreshTokenResult.UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserName)).Value;
            refreshTokenResult.TokenString = refreshToken;
            refreshTokenResult.ExpireAt = userRefreshToken.ExpiryDate;
            response.RefreshToken = refreshTokenResult;
            return response;

        }
        private JwtSecurityToken ReadJWTToken(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }

        public Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSignInKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.secret)),
                ValidAudience = _jwtSettings.audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);
            try
            {
                if (validator == null)
                {
                    throw new SecurityTokenException("Invalid Token");
                }

                return Task.FromResult("NotExpired");
            }
            catch (Exception ex)
            {
                return Task.FromResult(ex.Message);
            }
        }

    }
}