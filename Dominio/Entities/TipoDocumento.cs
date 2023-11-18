namespace Dominio.Entities;
public class TipoDocumento
{
    public int IdTipoDocumento { get; set; }
    public string Descripcion { get; set; }

    // Cardinalidad de las relaciones
    public ICollection<Numeracion> Numeraciones { get; set; }
}