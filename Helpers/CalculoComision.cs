using remitee_challenge.Business.Entities;
using remitee_challenge.Models;

namespace remitee_challenge.Helpers
{
    public static class CalculoComision
    {
        public static decimal Calcular(decimal saldo, ExtraccionModelo extraccion) {
            switch (extraccion.CodigoCuenta)
            {
                case "CajaAhorro":
                    var cajaahorro = new CajaAhorro();
                    saldo = saldo - cajaahorro.CalcularComision(extraccion.Monto);
                    break;
                case "CtaCte":
                    var ctaCte = new CtaCte();
                    saldo = saldo - ctaCte.CalcularComision(extraccion.Monto);
                    break;
            }
            return saldo;
        }
    }
}
