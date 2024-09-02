using remitee_challenge.Data.Entities;

namespace remitee_challenge.Data.Interfaces
{
    public interface IBalanceRepository
    {
        Task<Balance> GetBalanceByCodigoCuenta(string CodigoCuenta);
        Task<Balance> GetBalanceByCuenta(string cuentaId);
        void Update(Balance balance);
        Task<int> SaveChanges();
    }
}