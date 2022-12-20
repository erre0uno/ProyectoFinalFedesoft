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
    public class ResultadosController : ControllerBase
    {
        // context
        public readonly IGeneric<ResultadoDTO> _repositorio;

        public ResultadosController(IGeneric<ResultadoDTO> repositorio)
        {
            _repositorio = repositorio;
        }

        #region GetAll
        // GET: api/<ResultadoController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ResultadoDTO>> Get()
        {
            return await _repositorio.GetAll();
        }
        #endregion 

        #region GetById
        // GET api/<ResultadoController>/5
        [HttpGet("{id}")]
        public async Task<ResultadoDTO> Get(int id)
        {
            return await _repositorio.GetById(id); ;
        }
        #endregion 

        #region CreateResultado
        // POST api/<ResultadoController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(ResultadoDTO resultadoDTO)
        {
            var data = await _repositorio.CreateAsync(resultadoDTO);

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

        #region UpdateResultado
        // PUT api/<ResultadoController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(ResultadoDTO resultadoDTO)
        {
            return await _repositorio.UpdateAsync(resultadoDTO);
        }
        #endregion 

        #region DeleteResultado
        // DELETE api/<ResultadoController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            return await _repositorio.DeleteAsync(id);
        }
        #endregion 
    }
}
