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
    public class TarjetasRojasController : ControllerBase
    {

        // context
        public readonly IGeneric<TarjetaRojaDTO> _tarjeta;
        
        public TarjetasRojasController(IGeneric<TarjetaRojaDTO> itarjeta)
        {
            _tarjeta = itarjeta;
        }

        // GET: api/<TarjetasRojasController>
        #region GetAll
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<TarjetaRojaDTO>> Get()
        {
            return await _tarjeta.GetAll();
        }
        #endregion GetAll

        // GET api/<TarjetasRojasController>/5
        #region GetById
        [HttpGet("{id}")]
        public async Task<TarjetaRojaDTO> Get(int id)
        {
            return await _tarjeta.GetById(id); ;
        }
        #endregion GetById

        // POST api/<TarjetasRojasController>
        #region CreateUsuario
        [HttpPost]
        public async Task<HttpStatusCode> Post(TarjetaRojaDTO tarjetaRojaDTO)
        {
            var data = await _tarjeta.CreateAsync(tarjetaRojaDTO);

            if (data != null)
            {
                return HttpStatusCode.Created;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
        #endregion CreateUsuario

        // PUT api/<TarjetasRojasController>/5
        #region UpdateUsuario
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(TarjetaRojaDTO tarjetaRojaDTO)
        {
            return await _tarjeta.UpdateAsync(tarjetaRojaDTO);
        }
        #endregion UpdateUsuario

        // DELETE api/<TarjetasRojasController>/5
        #region DeleteUsuario
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            return await _tarjeta.DeleteAsync(id);
        }
        #endregion DeleteUsuario
    }
}
