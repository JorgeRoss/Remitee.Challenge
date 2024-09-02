
namespace remitee_challenge.Business.Entities
{
    public class CajaAhorro : Cuenta
    {
        public override decimal CalcularComision(decimal monto)
        {
            return monto * 0.10m;
        }
    }
}
