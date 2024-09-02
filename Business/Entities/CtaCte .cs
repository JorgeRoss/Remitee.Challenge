
namespace remitee_challenge.Business.Entities
{
    public class CtaCte : Cuenta
    {
        public override decimal CalcularComision(decimal monto)
        {
            return monto * 0.05m;
        }
    }
}
