namespace Mundial.BAL.Services.Repositories
{
    #region Using
    using Microsoft.EntityFrameworkCore;
    using Mundial.BAL.Services.Interfaces;
    using Mundial.DAL.DTO;
    using Mundial.DAL.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    public class LoginRepository : ILogin
    {
        private readonly MundialContext _context;

        public LoginRepository(MundialContext context){
            _context = context;
        }

        #region GetUsuario
        public async Task<UsuarioDTO> GetUsuario(UsuarioDTO usuario)
        {
            try
            {
                //ANTERIOR //Usuario user = await _context.Usuario.Where(u => u.Nombre == usuario.Nombre && u.Clave == usuario.Clave).FirstOrDefaultAsync();
                //var user = _context.Usuario.FirstOrDefault(u => u.Nombre == usuario.Nombre && u.Clave == usuario.Clave);

                // INSTANCIA
                var validarUsuario = new UsuarioDTO();
                bool pass = false;

                // VALIDA USUARIO    
                Usuario user = await _context.Usuario.Where(u => u.Nombre == usuario.Nombre).FirstOrDefaultAsync();

                // EVALUA RESULTADO DE USUARIO
                if (user != null)
                {
                    pass = BCrypt.Net.BCrypt.Verify(usuario.Clave, user.Clave);
                }

                // EVALUA RESULTADO DE USUARIO Y CONTRASEÑA
                if (user == null || pass==false)
                {
                    return validarUsuario = null;
                }
                else {
                    var _usuario = new UsuarioDTO()
                    {
                        Id = user.Id,
                        Nombre = user.Nombre,
                        Clave = user.Clave,
                        Tipo = user.Tipo
                    };
                    return _usuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }
        #endregion

        #region GetUsuarioAdmin
        //public UsuarioDTO GetUsuarioAdmin(UsuarioDTO usuario)
        //{
        //    try
        //    {
        //        var user = _context.Usuario.FirstOrDefault(u => u.Nombre == usuario.Nombre && u.Clave == usuario.Clave && u.Tipo == "admin");

        //        var _usuario = new UsuarioDTO()
        //        {
        //            Id = user.Id,
        //            Nombre = user.Nombre,
        //            Clave = user.Clave,
        //            Tipo = user.Tipo
        //        };
        //        return _usuario;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        #endregion

    }
}
