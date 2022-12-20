namespace Mundial.Controllers
{
    #region Using
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Mundial.BAL.Services.Interfaces;
    using Mundial.DAL.DTO;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    #endregion Using

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // context
        public readonly IGeneric<UsuarioDTO> _iusuario;

        public UsuariosController(IGeneric<UsuarioDTO> iusuario)
        {
            _iusuario = iusuario;
        }

        #region Get
        // GET: api/<UsuarioController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<UsuarioDTO>> Get()
        {
            return await _iusuario.GetAll();
        }
        #endregion

        #region GetId
        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<UsuarioDTO> Get(int id)
        {
            return await _iusuario.GetById(id);
        }
        #endregion

        #region Post
        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(UsuarioDTO usuarioDto)
        {
            var data = await _iusuario.CreateAsync(usuarioDto);

            if (data != null)
            {
                return HttpStatusCode.Created;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
        #endregion

        #region Put
        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(UsuarioDTO usuarioDto)
        {
            return await _iusuario.UpdateAsync(usuarioDto);
        }
        #endregion

        #region Delete
        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            return await _iusuario.DeleteAsync(id);
        }
        #endregion
    }
}

