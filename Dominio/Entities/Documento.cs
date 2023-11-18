
namespace Dominio.Entities;
public class Documento
{
    public int IdDocumento { get; set; }
    public int IdNumeracionFk { get; set; }
    public Numeracion Numeracion { get; set; }
    public int IdEstadoFk { get; set; }
    public Estado Estado { get; set; }
    public int Numero { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Base { get; set; }
    public decimal Impuesto { get; set; }
}