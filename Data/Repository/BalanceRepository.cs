using Microsoft.EntityFrameworkCore;
using remitee_challenge.Data.Entities;
using remitee_challenge.Data.Interfaces;
using remiteechallenge;

namespace remitee_challenge.Data.Repository
{
    public class BalanceRepository : IBalanceRepository
    {
        protected readonly ApplicationDbContext _contexto;
        public BalanceRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Balance> GetBalanceByCuenta(string cuentaId)
        {
            var balance = await _contexto.Balances.FirstOrDefaultAsync(x => x.Cuenta.CodigoCuenta == cuentaId);

            return balance;
        }

        public async Task<Balance> GetBalanceByCodigoCuenta(string CodigoCuenta)
        {
            var balance = await _contexto.Balances.FirstOrDefaultAsync(x => x.Cuenta.CodigoCuenta == CodigoCuenta);

            return balance;
        }

        public void Update(Balance balance)
        {
            _contexto.Update(balance);
        }

        public async Task<int> SaveChanges()
        {
            return await _contexto.SaveChangesAsync();
        }

    }
}
