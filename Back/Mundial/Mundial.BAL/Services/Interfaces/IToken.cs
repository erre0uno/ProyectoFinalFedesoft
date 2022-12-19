namespace Mundial.BAL.Services.Interfaces
{ 
    using Mundial.DAL.DTO;
    using System.Threading.Tasks;

    public interface IToken
    {
        Task<string> BuildToken(string key, string issuer, UsuarioDTO usuario);
        Task<bool> ValidateToken(string key, string issuer, string audience, string token);

        //string BuildToken2(string key,UsuarioDTO usuario);
    }
}
