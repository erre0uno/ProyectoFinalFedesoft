namespace Mundial.BAL.Services.Repositories
{
    #region using
    using Microsoft.EntityFrameworkCore;
    using Mundial.BAL.Services.Interfaces;
    using Mundial.DAL.DTO;
    using Mundial.DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    #endregion 

    public class AsistenciaRepository : IGeneric<AsistenciaDTO>
    {
        //context
        private readonly MundialContext _context;

        public AsistenciaRepository(MundialContext context)
        {
            _context = context;
        }

        #region CreateAsistencia
        public async Task<AsistenciaDTO> CreateAsync(AsistenciaDTO c)
        {
            var asistencia = new Asistencia()
            {
                Id = c.Id,
                Asistencias = c.Asistencias,
                JugadorId = c.JugadorId
            };
            try
            {
                _context.Add(asistencia);
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion CreateAsistencia

        #region DeleteAsistencia
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            try
            {
                var asistencia = await _context.Asistencia.FindAsync(id);

                if (asistencia != null)
                {
                    _context.Entry(asistencia).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.OK;
                }
                else
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion DeleteAsistencia

        #region GetAll
        public async Task<IEnumerable<AsistenciaDTO>> GetAll()
        {
            try
            {
                var _asistencia = await _context.Asistencia.Select(g => new AsistenciaDTO()
                {
                    Id = g.Id,
                    Asistencias = g.Asistencias,
                    JugadorId = g.JugadorId,
                    NombreJugador = g.Jugador.Nombre
                }).ToListAsync();
                return _asistencia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetAll

        #region GetByID
        public async Task<AsistenciaDTO> GetById(int id)
        {
            try
            {
                var asistencia = await _context.Asistencia.Select(g => new AsistenciaDTO()
                {
                    Id = g.Id,
                    Asistencias = g.Asistencias,
                    JugadorId = g.JugadorId,
                    NombreJugador = g.Jugador.Nombre
                }).FirstOrDefaultAsync(g => g.Id == id);
                return asistencia;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetById

        #region UpdateAsistencia
        public async Task<HttpStatusCode> UpdateAsync(AsistenciaDTO c)
        {
            try
            {
                var asistencia = await _context.Asistencia.FirstOrDefaultAsync(a => a.Id == c.Id);

                asistencia.Id = c.Id;
                asistencia.Asistencias = c.Asistencias;
                //asistencia.JugadorId = c.JugadorId; no se actualiza campo unique en DB

                _context.Entry(asistencia).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion UpdateAsistencia
    }
}
