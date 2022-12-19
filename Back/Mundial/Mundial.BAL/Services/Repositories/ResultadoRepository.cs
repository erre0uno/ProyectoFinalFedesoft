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
    public class ResultadoRepository : IGeneric<ResultadoDTO>
    {
        //context
        private readonly MundialContext _context;

        public ResultadoRepository(MundialContext context)
        {
            _context = context;
        }

        #region CreateResultado
        public async Task<ResultadoDTO> CreateAsync(ResultadoDTO c)
        {
            var Resultado = new Resultado()
            {
                Id = c.Id,
                Gf = c.Gf,
                Gc = c.Gc,
                NumeroPartido = c.NumeroPartido,
                EquipoId = c.EquipoId
            };
            try
            {
                _context.Add(Resultado);
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion CreateResultado

        #region GetAll
        public async Task<IEnumerable<ResultadoDTO>> GetAll()
        {
            try
            {
                var _resultado = await _context.Resultado.Select(g => new ResultadoDTO()
                {
                    Id = g.Id,
                    Gf = g.Gf,
                    Gc = g.Gc,
                    NumeroPartido = g.NumeroPartido,
                    EquipoId = g.EquipoId,
                    NombreEquipo = g.Equipo.Nombre
                }).ToListAsync();
                return _resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetAll

        #region GetByID
        public async Task<ResultadoDTO> GetById(int id)
        {
            try
            {
                var resultado = await _context.Resultado.Select(g => new ResultadoDTO()
                {
                    Id = g.Id,
                    Gf = g.Gf,
                    Gc = g.Gc,
                    NumeroPartido = g.NumeroPartido,
                    EquipoId = g.EquipoId,
                    NombreEquipo = g.Equipo.Nombre
                }).FirstOrDefaultAsync(g => g.Id == id);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetById

        #region UpdateResultado
        public async Task<HttpStatusCode> UpdateAsync(ResultadoDTO c)
        {
            try
            {
                var resultado = await _context.Resultado.FirstOrDefaultAsync(u => u.Id == c.Id);

                resultado.Id = c.Id;
                resultado.Gf = c.Gf;
                resultado.Gc = c.Gc;
                resultado.NumeroPartido = c.NumeroPartido;
                //resultado.EquipoId = c.EquipoId; campo unique en DB no se actualiza

                _context.Entry(resultado).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion UpdateResultado

        #region DeleteResultado
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            try
            {
                var resultado = await _context.Resultado.FindAsync(id);

                if (resultado != null)
                {
                    _context.Entry(resultado).State = EntityState.Deleted;
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
        #endregion DeleteResultado
    }
}
