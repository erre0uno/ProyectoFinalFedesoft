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
    
    public class TarjetaRojaRepository : IGeneric<TarjetaRojaDTO>
    {

        //context
        private readonly MundialContext _context;

        public TarjetaRojaRepository(MundialContext context)
        {
            _context = context;
        }

        #region CreateTarjetaRoja
        public async Task<TarjetaRojaDTO> CreateAsync(TarjetaRojaDTO c)
        {
            var tarjetaRoja = new TarjetaRoja()
            {
                Id = c.Id,
                Numero = c.Numero,
                JugadorId = c.JugadorId //  caompunique en Db
            };
            try
            {
                _context.Add(tarjetaRoja);
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion CreateTarjetaRoja

        #region DeleteTarjetaRoja
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            try
            {
                var tarjetaRoja = await _context.TarjetaRoja.FindAsync(id);

                if (tarjetaRoja != null)
                {
                    _context.Entry(tarjetaRoja).State = EntityState.Deleted;
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
        #endregion DeleteTarjetaRoja

        #region GetAllTarjetasRojas
        public async Task<IEnumerable<TarjetaRojaDTO>> GetAll()
        {
            try
            {
                var _tarjetaRoja = await _context.TarjetaRoja.Select(g => new TarjetaRojaDTO()
                {
                   Id = g.Id,
                   Numero = g.Numero,
                   JugadorId = g.JugadorId,
                   NombreJugador = g.Jugador.Nombre + ' ' + g.Jugador.Apellidos

                }).ToListAsync();
                return _tarjetaRoja;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetAllTarjetasRojas

        #region GetTarjetaRojaById
        public async Task<TarjetaRojaDTO> GetById(int id)
        {
            try
            {
                var tarjetaRoja = await _context.TarjetaRoja.Select(g => new TarjetaRojaDTO()
                {
                    Id = g.Id,
                    Numero = g.Numero,
                    JugadorId = g.JugadorId,
                    NombreJugador = g.Jugador.Nombre + ' ' + g.Jugador.Apellidos

                }).FirstOrDefaultAsync(g => g.Id == id);
                return tarjetaRoja;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetTarjetaRojaById

        #region UpdateTarjetaRoja
        public async Task<HttpStatusCode> UpdateAsync(TarjetaRojaDTO c)
        {
            try
            {
                var tarjetaRoja = await _context.TarjetaRoja.FirstOrDefaultAsync(u => u.Id == c.Id);

                tarjetaRoja.Id = c.Id;
                tarjetaRoja.Numero = c.Numero;
                // tarjetaRoja.JugadorId = c.JugadorId; no se actualiza campo Unique en DB

                _context.Entry(tarjetaRoja).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion UpdateTarjetaRoja
    }
}
