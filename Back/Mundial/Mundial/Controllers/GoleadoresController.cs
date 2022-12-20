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
    #endregion 

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GoleadoresController : ControllerBase
    {
        // context
        public readonly IGeneric<GoleadorDTO> _repositorio;

        public GoleadoresController(IGeneric<GoleadorDTO> repositorio)
        {
            _repositorio = repositorio;
        }

        #region GetAll
        // GET: api/<UsuariosController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<GoleadorDTO>> Get()
        {
            return await _repositorio.GetAll();
        }
        #endregion GetAll

        #region GetById
        // GET api/<GoleadoresController>/5
        [HttpGet("{id}")]
        public async Task<GoleadorDTO> Get(int id)
        {
            return await _repositorio.GetById(id); ;
        }
        #endregion GetById

        #region CreateGoleador
        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(GoleadorDTO goleadorDto)
        {
            var data = await _repositorio.CreateAsync(goleadorDto);

            if (data != null)
            {
                return HttpStatusCode.Created;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
        #endregion CreateGoleador

        #region UpdateGoleador
        // PUT api/<GoleadoresController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(GoleadorDTO goleadorDto)
        {
            return await _repositorio.UpdateAsync(goleadorDto);
        }
        #endregion UpdateGoleador

        #region DeleteGoleador
        // DELETE api/<GoleadoresController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            return await _repositorio.DeleteAsync(id);
        }
        #endregion DeleteGoleador
    }
}
