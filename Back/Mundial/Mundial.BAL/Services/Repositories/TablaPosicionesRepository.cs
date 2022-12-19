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

    public class TablaPosicionesRepository : IGeneric<TablaPosicionesDTO>
    {
        //context
        private readonly MundialContext _context;

        public TablaPosicionesRepository(MundialContext context)
        {
            _context = context;
        }

        #region createAsync
        public async Task<TablaPosicionesDTO> CreateAsync(TablaPosicionesDTO c)
        {
            var tablaposiciones = new TablaPosiciones()
            {
                Id = c.Id,
                Pj = c.Pj,
                Pg = c.Pg,
                Pe = c.Pe,
                Pp = c.Pp,
                Gf = c.Gf,
                Gc = c.Gc,
                Puntos = c.Puntos,
                EquipoId = c.EquipoId //campo unique en DB
            };
            try
            {
                _context.Add(tablaposiciones);
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion createAsync

        #region DeleteAsync
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            try
            {
                var tablaposiciones = await _context.TablaPosiciones.FindAsync(id);

                if (tablaposiciones != null)
                {
                    _context.Entry(tablaposiciones).State = EntityState.Deleted;
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
        #endregion DeleteAsync

        #region GetAll
        public async Task<IEnumerable<TablaPosicionesDTO>> GetAll()
        {
            try
            {
                var tablaposiciones = await _context.TablaPosiciones.Select(g => new TablaPosicionesDTO()
                {

                    Id = g.Id,
                    Pj = g.Pj,
                    Pg = g.Pg,
                    Pe = g.Pe,
                    Pp = g.Pp,
                    Gf = g.Gf,
                    Gc = g.Gc,
                    Puntos = g.Puntos,
                    EquipoId = g.EquipoId, // Se trae esta linea para evitar valores nulos en la consulta
                    NombreEquipo = g.Equipo.Nombre
                }).ToListAsync();
                return tablaposiciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion GetAll

        #region GetById
        public async Task<TablaPosicionesDTO> GetById(int id)
        {
            try
            {
                var tablaposiciones = await _context.TablaPosiciones.Select(g => new TablaPosicionesDTO()
                {
                    Id = g.Id,
                    Pj = g.Pj,
                    Pg = g.Pg,
                    Pe = g.Pe,
                    Pp = g.Pp,
                    Gf = g.Gf,
                    Gc = g.Gc,
                    Puntos = g.Puntos,
                    EquipoId = g.EquipoId, // Se trae esta linea para evitar valores nulos en la consulta
                    NombreEquipo = g.Equipo.Nombre
                }).FirstOrDefaultAsync(g => g.Id == id);
                return tablaposiciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetById

        #region UpdateAsync
        public async Task<HttpStatusCode> UpdateAsync(TablaPosicionesDTO c)
        {
            try
            {
                var tablaposiciones = await _context.TablaPosiciones.FirstOrDefaultAsync(u => u.Id == c.Id);

                tablaposiciones.Id = c.Id;
                tablaposiciones.Pj = c.Pj;
                tablaposiciones.Pg = c.Pg;
                tablaposiciones.Pe = c.Pe;
                tablaposiciones.Pp = c.Pp;
                tablaposiciones.Gf = c.Gf;
                tablaposiciones.Gc = c.Gc;
                tablaposiciones.Puntos = c.Puntos;
                //tablaposiciones.EquipoId = c.EquipoId; no se actuliza campo Unique en DB

                _context.Entry(tablaposiciones).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion UpdateAsync

    }

}

/*  BackCode 
        #region createAsync
        public async Task<TablaPosicionesDTO> CreateAsync(TablaPosicionesDTO c)
        {
            var tablaposiciones = new TablaPosiciones()
            {
                Id = c.Id,
                Pj = c.Pj,
                Pg = c.Pg,
                Pe = c.Pe,
                Pp = c.Pp,
                Gf = c.Gf,
                Gc = c.Gc,
                Puntos = c.Puntos,
                EquipoId = c.EquipoId
            };
            try
            {
                _context.Add(tablaposiciones);
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion createAsync

        #region DeleteAsync
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            try
            {
                var tablaposiciones = await _context.TablaPosiciones.FindAsync(id);

                if (tablaposiciones != null)
                {
                    _context.Entry(tablaposiciones).State = EntityState.Deleted;
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
        #endregion DeleteAsync

        #region GetAll
        public async Task<IEnumerable<TablaPosicionesDTO>> GetAll()
        {

            try
            {

                var resultados = from r in _context.Resultado.Where(r => r.Gf > r.Gc)
                                 group r by r.EquipoId==1
                                 into r
                                 where r.Count() > 0
                                 orderby r.Key
                                 select new { r.Key, Count = r.Count() };
                                 
                Console.WriteLine(resultados);

                //var resultados = await _context.Resultado.Where(re => re.EquipoId == 1).Where(eq => eq.Gf > eq.Gc).Count();

                var tablaposiciones = await _context.TablaPosiciones.Select(g => new TablaPosicionesDTO()
                {
                    Id = g.Id,
                    Pj = g.Pj,
                    Pg = g.Pg,
                    Pe = g.Pe,
                    Pp = g.Pp,
                    Gf = g.Gf,
                    Gc = g.Gc,
                    Puntos = g.Puntos,
                    EquipoId = g.EquipoId,
                    NombreEquipo = g.Equipo.Nombre
                }).ToListAsync();
                return tablaposiciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            //try
            //{
            //    var tablaposiciones = await _context.TablaPosiciones.Select(g => new TablaPosicionesDTO()
            //    {
            //        Id = g.Id,
            //        Pj = g.Pj,
            //        Pg = g.Pg,
            //        Pe = g.Pe,
            //        Pp = g.Pp,
            //        Gf = g.Gf,
            //        Gc = g.Gc,
            //        Puntos = g.Puntos,
            //        EquipoId = g.EquipoId,
            //        NombreEquipo = g.Equipo.Nombre
            //    }).ToListAsync();
            //    return tablaposiciones;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}

        }
        #endregion GetAll

        #region GetById
        public async Task<TablaPosicionesDTO> GetById(int id)
        {
            try
            {
                var tablaposiciones = await _context.TablaPosiciones.Select(g => new TablaPosicionesDTO()
                {
                    Id = g.Id,
                    Pj = g.Pj,
                    Pg = g.Pg,
                    Pe = g.Pe,
                    Pp = g.Pp,
                    Gf = g.Gf,
                    Gc = g.Gc,
                    Puntos = g.Puntos,
                    NombreEquipo = g.Equipo.Nombre
                }).FirstOrDefaultAsync(g => g.Id == id);
                return tablaposiciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetById

        #region UpdateAsync
        public async Task<HttpStatusCode> UpdateAsync(TablaPosicionesDTO c)
        {
            try
            {
                var tablaposiciones = await _context.TablaPosiciones.FirstOrDefaultAsync(u => u.Id == c.Id);

                tablaposiciones.Id = c.Id;
                tablaposiciones.Pj = c.Pj;
                tablaposiciones.Pg = c.Pg;
                tablaposiciones.Pe = c.Pe;
                tablaposiciones.Pp = c.Pp;
                tablaposiciones.Gf = c.Gf;
                tablaposiciones.Gc = c.Gc;
                tablaposiciones.Puntos = c.Puntos;
                //tablaposiciones.EquipoId = c.EquipoId; no se actuliza campo Unique en DB

                _context.Entry(tablaposiciones).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion UpdateAsync
*/
