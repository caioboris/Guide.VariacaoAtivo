using Guide.VariacaoAtivo.Context;
using Guide.VariacaoAtivo.Domain.Interfaces.Repositories;
using Guide.VariacaoAtivo.Domain.Models;

namespace Guide.VariacaoAtivo.Data.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly DataContext _context;

        public AtivoRepository(DataContext context)
        {
            _context = context;
        }

        public  List<Ativo> GetAllAtivos()
        {
            return _context.Ativos.OrderBy(x => x.Dia).ToList();
        }

        public void PostAtivo(Ativo ativo)
        {
            _context.Ativos.Add(ativo);
            _context.SaveChanges();
        }

        public void ClearTable()
        {
            var ativos = _context.Ativos.ToList();
            _context.Ativos.RemoveRange(ativos);
            _context.SaveChanges();
        }
    }
}
