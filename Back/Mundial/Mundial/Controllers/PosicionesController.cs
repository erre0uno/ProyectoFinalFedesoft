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
    public class PosicionesController : ControllerBase
    {
        //context
        public readonly IGenericShow<PosicionDTO> _repositorio;

        public PosicionesController(IGenericShow<PosicionDTO> repositorio)
        {
            _repositorio = repositorio;
        }

        #region GetAll
        // GET: api/<PosicionesController>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<PosicionDTO>> Get()
        {
            return await _repositorio.GetAll();
        }
        #endregion 

        #region GetById
        // GET api/<PosicionesController>/5
        [HttpGet("{id}")]
        public async Task<PosicionDTO> Get(int id)
        {
            return await _repositorio.GetById(id); ;
        }
        #endregion 
    }
}

