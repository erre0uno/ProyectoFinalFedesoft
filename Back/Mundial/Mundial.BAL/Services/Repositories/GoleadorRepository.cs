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
    using System.Net;
    using System.Threading.Tasks;
    #endregion

    public class GoleadorRepository : IGeneric<GoleadorDTO>
    {
        //context
        private readonly MundialContext _context;
        public GoleadorRepository(MundialContext context)
        {
            _context = context;
        }

        #region CreateGoleador
        public async Task<GoleadorDTO> CreateAsync(GoleadorDTO c)
        {
            var goleador = new Goleador()
            {
                Id = c.Id,
                Goles = c.Goles,
                JugadorId = c.JugadorId
            };
            try
            {
                _context.Add(goleador);
                await _context.SaveChangesAsync();
                return c;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

        #region DeleteGoleador
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            try
            {
                var goleador = await _context.Goleador.FindAsync(id);

                if (goleador != null)
                {
                    _context.Entry(goleador).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.OK;
                }
                else
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<GoleadorDTO>> GetAll()
        {
            try
            {
                var _goleador = await _context.Goleador.Select(g => new GoleadorDTO()
                {
                    Id = g.Id,
                    Goles = g.Goles,
                    JugadorId = g.JugadorId,
                    NombreJugador = g.Jugador.Nombre
                }).ToListAsync();
                return _goleador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

        #region GetByID
        public async Task<GoleadorDTO> GetById(int id)
        {
            try
            {
                var _goleador = await _context.Goleador.Select(g => new GoleadorDTO()
                {

                    Id = g.Id,
                    Goles = g.Goles,
                    JugadorId = g.JugadorId,
                    NombreJugador = g.Jugador.Nombre

                }).FirstOrDefaultAsync(g => g.Id == id);
                return _goleador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

        #region UpdateGoleador
        public async Task<HttpStatusCode> UpdateAsync(GoleadorDTO c)
        {
            try
            {
                var goleador = await _context.Goleador.FirstOrDefaultAsync(u => u.Id == c.Id);

                goleador.Id = c.Id;
                goleador.Goles = c.Goles;
                //goleador.JugadorId = c.JugadorId; no se actualiza campo unique en DB

                _context.Entry(goleador).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion UpdateGoleador
    }
}

