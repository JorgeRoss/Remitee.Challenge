using remitee_challenge.Data.Entities;
using remitee_challenge.Models;

namespace remitee_challenge
{
    public interface IBalanceService
    {
        Task<Balance> GetBalanceByCuenta(string cuentaId);
        Task<Balance> GetDinero(ExtraccionModelo extraccion);
    }
}