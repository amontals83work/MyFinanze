namespace MyFinanzeAPI.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Concepto { get; set; }
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }
    }
}
