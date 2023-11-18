namespace Dominio.Entities;
public class Numeracion
{
    public int IdNumeracion { get; set; }
    public int IdTipoDocumentoFk { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public int IdEmpresaFk { get; set; }
    public Empresa Empresa { get; set; }
    public string Prefijo { get; set; }
    public int ConsecutivoInicial { get; set; }
    public int ConsecutivoFinal { get; set; }
    public DateTime VigenciaInicial { get; set; }
    public DateTime VigenciaFinal { get; set; }

    // Cardinalidad de las relaciones
    public ICollection<Documento> Documentos { get; set; }
}