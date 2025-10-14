using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Services
{
    public interface ISectorService
    {
        IEnumerable<Sector> ListarSetores(int userId, CancellationToken token, int pagina, int limite);
    }
}
