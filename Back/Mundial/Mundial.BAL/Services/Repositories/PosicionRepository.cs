
namespace Mundial.BAL.Services.Repositories
{
    #region Using
    using Microsoft.EntityFrameworkCore;
    using Mundial.BAL.Services.Interfaces;
    using Mundial.DAL.DTO;
    using Mundial.DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    public class PosicionRepository : IGenericShow<PosicionDTO>
    {
        //context
        private readonly MundialContext _context;

        public PosicionRepository(MundialContext context)
        {
            _context = context;
        }

        #region GetAll
        public async Task<IEnumerable<PosicionDTO>> GetAll()
        {
            try
            {
                var _posicion = await _context.Posicion.Select(g => new PosicionDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,

                }).ToListAsync();
                return _posicion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetAll

        #region GetByID
        public async Task<PosicionDTO> GetById(int id)
        {
            try
            {
                var _posicion = await _context.Posicion.Select(g => new PosicionDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,

                }).FirstOrDefaultAsync(g => g.Id == id);
                return _posicion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetById
    }
}