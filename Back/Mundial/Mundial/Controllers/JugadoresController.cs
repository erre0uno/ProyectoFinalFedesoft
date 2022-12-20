namespace Mundial.Controllers
{
    #region Using
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Mundial.BAL.Services.Interfaces;
    using Mundial.DAL.DTO;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        //context
        public readonly IGenericShow<JugadorDTO> _jugador;
        public JugadoresController(IGenericShow<JugadorDTO> ijugador)
        {
            _jugador = ijugador;
        }

        #region Get
        // GET: api/<UsuarioController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<JugadorDTO>> Get()
        {
            return await _jugador.GetAll();
        }
        #endregion

        #region GetId
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<JugadorDTO> Get(int id)
        {
            return await _jugador.GetById(id);
        }
        #endregion
    }
}


