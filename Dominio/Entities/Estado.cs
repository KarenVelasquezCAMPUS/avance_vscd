namespace Dominio.Entities;
public class Estado
{
    public int IdEstado { get; set; }
    public string Descripcion { get; set; }
    public bool Exitoso { get; set; }

    // Cardinalidad de las relaciones
    public ICollection<Documento> Documentos { get; set; }
}