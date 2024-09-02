using remitee_challenge.Business.Entities;
using remitee_challenge.Data.Entities;
using remitee_challenge.Data.Interfaces;
using remitee_challenge.Helpers;
using remitee_challenge.Models;

namespace remitee_challenge;

public class BalanceService : IBalanceService
{
    private readonly IBalanceRepository _balanceRepository;
    public BalanceService(IBalanceRepository balanceRepository)
    {
        _balanceRepository = balanceRepository;
    }

    public async Task<Balance> GetBalanceByCuenta(string cuentaId)
    {        
        var obtengoBalance = await _balanceRepository.GetBalanceByCuenta(cuentaId);


        if (obtengoBalance == null)
        {
            throw new KeyNotFoundException($"Balance no encontrado, cuenta : {cuentaId}");
        }

        return obtengoBalance;

    }

    public async Task<Balance> GetDinero(ExtraccionModelo extraccion)
    {

        var obtengoBalance = await _balanceRepository.GetBalanceByCodigoCuenta(extraccion.CodigoCuenta);

        if (obtengoBalance == null)
        {
            throw new KeyNotFoundException($"Balance no encontrado, codigo de cuenta :  {extraccion.CodigoCuenta}");
        }

        obtengoBalance.Saldo = obtengoBalance.Saldo - extraccion.Monto;

        obtengoBalance.Saldo = CalculoComision.Calcular(obtengoBalance.Saldo, extraccion);


        _balanceRepository.Update(obtengoBalance);
        _balanceRepository.SaveChanges();

        if (obtengoBalance == null)
        {
            return new Balance();
        }

        return obtengoBalance;
    }
}
