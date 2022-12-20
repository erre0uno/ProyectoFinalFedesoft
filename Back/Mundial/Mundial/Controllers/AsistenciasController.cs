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
    public class AsistenciasController : ControllerBase
    {
        public readonly IGeneric<AsistenciaDTO> _iasistencia;

        public AsistenciasController(IGeneric<AsistenciaDTO> iasistencia)
        {
            _iasistencia = iasistencia;
        }

        #region Get
        // GET: api/<AsistenciaController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<AsistenciaDTO>> Get()
        {
            return await _iasistencia.GetAll();
        }
        #endregion

        #region GetId
        // GET api/<AsistenciaController>/5
        [HttpGet("{id}")]
        public async Task<AsistenciaDTO> Get(int id)
        {
            return await _iasistencia.GetById(id);
        }
        #endregion

        #region Post
        // POST api/<AsistenciaController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(AsistenciaDTO asistenciaDto)
        {
            var data = await _iasistencia.CreateAsync(asistenciaDto);

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
        // PUT api/<AsistenciaController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(AsistenciaDTO asistenciaDto)
        {
            return await _iasistencia.UpdateAsync(asistenciaDto);
        }
        #endregion

        #region Delete
        // DELETE api/<AsistenciaController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            return await _iasistencia.DeleteAsync(id);
        }
        #endregion

    }
}

/*
        #region Using
        #region Get
        #region GetId
        #region Post
        #region Put
        #region Delete
        #endregion
*/