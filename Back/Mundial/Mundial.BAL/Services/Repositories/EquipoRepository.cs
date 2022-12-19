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

    public class EquipoRepository: IGenericShow<EquipoDTO>
    {
        //context
        private readonly MundialContext _context;
        
        public EquipoRepository(MundialContext context)
        {
            _context = context;
        }

        #region GetAll
        public async Task<IEnumerable<EquipoDTO>> GetAll()
        {
            try
            {
                var _equipo = await _context.Equipo.Select(g => new EquipoDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    Participaciones = g.Participaciones,
                    Grupo = g.Grupo
                }).ToListAsync();
                return _equipo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

        #region GetById
        public async Task<EquipoDTO> GetById(int id)
        {
            try
            {
                var _equipo = await _context.Equipo.Select(g => new EquipoDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    Participaciones = g.Participaciones,
                    Grupo = g.Grupo
                }).FirstOrDefaultAsync(g => g.Id == id);
                return _equipo;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

    }
}
