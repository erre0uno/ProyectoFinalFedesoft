namespace Mundial.BAL.Services.Repositories
{
    #region Using
    using Microsoft.IdentityModel.Tokens;
    using Mundial.BAL.Services.Interfaces;
    using Mundial.DAL.DTO;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    #endregion

    public class TokenRepository : IToken
    {

        #region BuildToken
        /// <summary>
        /// metodo genera un token. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="issuer"></param>
        /// <param name="usuario"></param>
        /// <returns> token, es retornado en Json con la key 'token' </returns>
        public async Task<string> BuildToken(string key, string issuer, UsuarioDTO usuario)
        {   
            // parte 2 datos que tenemos token
            var claims = new[] {
            new Claim(ClaimTypes.Name, usuario.Nombre),
            new Claim(ClaimTypes.Role, usuario.Tipo),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString() )
            };
            //parte 1 tipo clave
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); 
            // parte 3 credenciales-encriptacion
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            
            // construccion del token
            var tokenDescriptor = new JwtSecurityToken(
                issuer, 
                issuer, 
                claims,
                expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        #endregion

        #region BuildToken2
        //public string BuildToken2(string pkey,  UsuarioDTO usuario) { 

        //var secretKey = pkey;
        //var key = Encoding.ASCII.GetBytes(secretKey);

        //var claims = new ClaimsIdentity();
        //claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Nombre));

        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = claims,
        //            Expires = DateTime.UtcNow.AddMinutes(30),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
        //            SecurityAlgorithms.HmacSha256Signature)
        //        };

        //var tokenHandler = new JwtSecurityTokenHandler();
        //var createdToken = tokenHandler.CreateToken(tokenDescriptor);

        //string bearer_token = tokenHandler.WriteToken(createdToken);
        //        return bearer_token;

        //}
        #endregion

        #region ValidateToken
        /// <summary>
        /// metodo valida la construccion correcta del token
        /// </summary>
        /// <param name="key"></param>
        /// <param name="issuer"></param>
        /// <param name="audience"></param>
        /// <param name="token"></param>
        /// <returns> bool </returns>
        public async  Task<bool> ValidateToken(string key, string issuer, string audience, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

    }

}
