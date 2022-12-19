namespace Mundial.BAL.Services.Interfaces
{
    using Mundial.DAL.DTO;
    using System.Threading.Tasks;

    public interface ILogin
    {
        Task <UsuarioDTO> GetUsuario(UsuarioDTO usuario);
    }
}
