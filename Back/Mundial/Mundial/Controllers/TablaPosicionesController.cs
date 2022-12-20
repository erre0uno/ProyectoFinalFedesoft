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
    public class TablaPosicionesController : ControllerBase
    {
        // context
        public readonly IGeneric<TablaPosicionesDTO> _repositorio;

        public TablaPosicionesController(IGeneric<TablaPosicionesDTO> repositorio)
        {
            _repositorio = repositorio;
        }

        #region Get
        // GET: api/<TablaPosicionesController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<TablaPosicionesDTO>> Get()
        {
            return await _repositorio.GetAll();
        }
        #endregion

        #region GetId
        // GET api/<TablaPosicionesController>/5
        [HttpGet("{id}")]
        public async Task<TablaPosicionesDTO> Get(int id)
        {
            return await _repositorio.GetById(id); ;
        }
        #endregion

        #region Post
        // POST api/<TablaPosicionesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(TablaPosicionesDTO tablaposicionesDto)
        {
            var data = await _repositorio.CreateAsync(tablaposicionesDto);

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
        // PUT api/<TablaPosicionesController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(TablaPosicionesDTO tablaposicionesDto)
        {
            return await _repositorio.UpdateAsync(tablaposicionesDto);
        }
        #endregion

        #region Delete
        // DELETE api/<TablaPosicionesController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            return await _repositorio.DeleteAsync(id);
        }
        #endregion
    }
}

