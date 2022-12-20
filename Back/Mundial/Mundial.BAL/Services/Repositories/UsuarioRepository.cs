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

    public class UsuarioRepository : IGeneric<UsuarioDTO>
    {

        //context
        private readonly MundialContext _context;

        public UsuarioRepository(MundialContext context)
        {
            _context = context;
        }

        #region CreateUsuario
        public async Task<UsuarioDTO> CreateAsync(UsuarioDTO c)
        {
            // tipo encriptacion y copnfiguracion
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);

            var usuario = new Usuario()
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Clave = BCrypt.Net.BCrypt.HashPassword(c.Clave, salt), // encriptacion de clave
                Tipo = c.Tipo
            };
            try
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion CreateUsuario

        #region DeleteUsuario
        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario != null)
                {
                    _context.Entry(usuario).State = EntityState.Deleted;
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
        #endregion DeleteUsuario

        #region GetAll
        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            try
            {
                var _usuario = await _context.Usuario.Select(g => new UsuarioDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    Clave = g.Clave,
                    Tipo = g.Tipo
                }).ToListAsync();
                return _usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetAll

        #region GetByID
        public async Task<UsuarioDTO> GetById(int id)
        {
            try
            {
                var usuario = await _context.Usuario.Select(g => new UsuarioDTO()
                {
                    Id = g.Id,
                    Nombre = g.Nombre,
                    Clave = g.Clave,
                    Tipo = g.Tipo
                }).FirstOrDefaultAsync(g => g.Id == id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion GetById

        #region UpdateUsuario
        public async Task<HttpStatusCode> UpdateAsync(UsuarioDTO c)
        {
            try
            {
                // tipo encriptacion
                string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
                
                var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == c.Id);

                usuario.Id = c.Id;
                usuario.Nombre = c.Nombre;
                usuario.Clave = BCrypt.Net.BCrypt.HashPassword(c.Clave, salt);// encriptacion de CLAVE
                //usuario.Tipo = c.Tipo; campo no va cambiar

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion UpdateUsuario
    }
}