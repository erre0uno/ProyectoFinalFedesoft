namespace Mundial.Controllers
{
    #region Using
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Mundial.BAL.Services.Interfaces;
    using Mundial.DAL.DTO;
    using System.Threading.Tasks;
    #endregion

    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        #region Dependencias
        public IConfiguration _configuration;
        private readonly IConfiguration _config;
        private readonly IToken _tokenRepository;
        private readonly ILogin _loginRepository;
        private string generatedToken = null;
        #endregion

        //constructor
        public LoginController(IConfiguration config, IToken tokenRepository, ILogin LoginRepository)
        {
            _config = config;
            _tokenRepository = tokenRepository;
            _loginRepository = LoginRepository;
        }

        #region Metodo Post>Login
        /// <summary>
        /// metodo recibe un usuario y valida acceso
        /// </summary>
        /// <param name="_userData"></param>
        /// <returns> json, con key token </returns>
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDTO _userData)
        {

            if (string.IsNullOrEmpty(_userData.Nombre) || string.IsNullOrEmpty(_userData.Clave))
            {
                //return validacion
                return BadRequest("Datos usuario y contraseña requeridos !");
            }

            //IActionResult response = Unauthorized();

            var validUser = await ValidarUsuario(_userData);

            if (validUser != null)
            {
                //generatedToken = _tokenService.BuildToken2(_config["SecretKey"].ToString() , validUser);
                generatedToken = await _tokenRepository.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), validUser);
                if (generatedToken != null)
                {
                    //retorna el token en key token en formato json
                    return Ok(new {
                        token=generatedToken,
                    });
                }
                else
                {
                    return BadRequest("error al generar token ");
                }
            }
            else
            {
                return BadRequest("Datos  de inicio de sesion no validos !");
            }

        }
        #endregion

        #region ValidarUsuario
        /// <summary>
        /// valida usuario y contraseña en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns> usuario </returns>
        private async Task<UsuarioDTO> ValidarUsuario(UsuarioDTO usuario)
        {
            return await _loginRepository.GetUsuario(usuario);
        }
        #endregion
    }
}
