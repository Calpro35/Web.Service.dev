using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _repository;

        public SectorService(ISectorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Sector> ListarSetores(int userId, CancellationToken token, int pagina, int limite) => _repository.GetAllAsync(userId, token).Result;
    }
}
