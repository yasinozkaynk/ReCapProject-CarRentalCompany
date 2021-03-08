using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//wep apideki appsettings.com dosyasındaki bilgileri okumaya yarar
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;//access tokenin süresi ne zaman süresi biteceği
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;//==appsettings tir
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();// getsection appsettings içerisindeki her bir class tır 
                                                                                         //appsettings içerisindeki TokenOptionsu Proprtyleriyle(Get<TokenOptions>) eşleştir

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)//User bilgilerini ve claim bilgilerini alarak token oluşturur
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//tokenin ne zaman expiration olacağnı söyler
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//güvenlik anahtarı
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);// SigningCredentialsHelper verdiğmiz algoritmayı kullanır
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//Bütün bilgileri kullanaraak o kişiye ait yetkilendirmeler 
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
         SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");//başında $ işareti olursa içinde yan yana yazılır 
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        } //.Net te var olan nesneye yeni methodlar ekleye bilrsiniz buna Extensions denir

    }
}
 
