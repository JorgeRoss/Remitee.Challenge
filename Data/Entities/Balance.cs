
namespace remitee_challenge.Data.Entities;
public class Balance
{
    public int Id { get; set; }
    public decimal Saldo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaMoficacion { get; set; }
    public Cuenta Cuenta { get; set; }
}
