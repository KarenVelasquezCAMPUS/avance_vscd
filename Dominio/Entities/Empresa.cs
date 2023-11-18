namespace Dominio.Entities;
public class Empresa
{
    public int IdEmpresa { get; set; }
    public string Identificacion { get; set; }
    public string RazonSocial { get; set; }
    
    // Cardinalidad de las relaciones
    public ICollection<Numeracion> Numeraciones { get; set; }
}