namespace remitee_challenge.Business.Entities
{
    public abstract class Cuenta
    {
        public int Id { get; set; }
        public string CodigoCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime FechaCreacion { get; set; }

        public abstract decimal CalcularComision(decimal monto);

    }
}
