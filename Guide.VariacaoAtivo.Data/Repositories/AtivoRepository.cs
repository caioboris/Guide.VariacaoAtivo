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

        public async Task<List<Ativo>> GetAllAtivos()
        {
            return _context.Set<Ativo>().ToList();
        }

        public async Task<Ativo> GetAtivoById(Guid id)
        {
            return await _context.Set<Ativo>().FindAsync(id);
        }

        public async void PostAtivo(Ativo ativo)
        {
            _context.Set<Ativo>().Add(ativo);
            await _context.SaveChangesAsync();
        }

        public async void PutAtivo(Ativo ativo)
        {
            _context.Entry(ativo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async void DeleteAtivo(Guid id)
        {
            var ativo = _context.Set<Ativo>().Find(id);
            if(ativo != null)
            {
                _context.Set<Ativo>().Remove(ativo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
