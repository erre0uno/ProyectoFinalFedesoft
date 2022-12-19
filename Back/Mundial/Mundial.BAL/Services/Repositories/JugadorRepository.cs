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

    public class JugadorRepository : IGenericShow<JugadorDTO>
    {
        //context
        private readonly MundialContext _context;

        public JugadorRepository(MundialContext context)
        {
            _context = context;
        }

        #region GetAll
        public async Task<IEnumerable<JugadorDTO>> GetAll()
        {
            try
            {
                var _jugador = await _context.Jugador.Select(g => new JugadorDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    Apellidos = g.Apellidos,
                    FechaNacimiento = g.FechaNacimiento,
                    Estatura = g.Estatura,
                    PosicionId = g.PosicionId,
                    NombrePosicion = g.Posicion.Nombre,
                    EquipoId = g.EquipoId,
                    NombreEquipo = g.Equipo.Nombre
                }).ToListAsync();
                return _jugador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

        #region GetById
        public async Task<JugadorDTO> GetById(int id)
        {
            try
            {
                var _jugador = await _context.Jugador.Select(g => new JugadorDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    Apellidos = g.Apellidos,
                    FechaNacimiento = g.FechaNacimiento,
                    Estatura = g.Estatura,
                    PosicionId = g.PosicionId,
                    NombrePosicion = g.Posicion.Nombre,
                    EquipoId = g.EquipoId,
                    NombreEquipo = g.Equipo.Nombre
                }).FirstOrDefaultAsync(g => g.Id == id);
                return _jugador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion 

    }
}
