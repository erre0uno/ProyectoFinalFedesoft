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
    public class EquiposController : ControllerBase
    {
        // context
        public readonly IGenericShow<EquipoDTO> _repositorio;

        public EquiposController(IGenericShow<EquipoDTO> repositorio)
        {
            _repositorio = repositorio;
        }


        #region Get
        // GET: api/<EquiposController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<EquipoDTO>> Get()
        {
            return await _repositorio.GetAll();
        }
        #endregion

        #region GetById
        // GET api/<EquiposController>/5
        [HttpGet("{id}")]
        public async Task<EquipoDTO> Get(int id)
        {
            return await _repositorio.GetById(id);
        }
        #endregion

        #region Post
        // POST api/<EquiposController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        #endregion

        #region Put
        // PUT api/<EquiposController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        #endregion

        #region Delete
        // DELETE api/<EquiposController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

    }
}
