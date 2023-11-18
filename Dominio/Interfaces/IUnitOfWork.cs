using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        IDocumentoRepository Documentos { get; }
        IEmpresaRepository Empresas { get; }
        IEstadoRepository Estados { get; }
        INumeracionRepository Numeraciones { get; }
        ITipoDocumentoRepository TipoDocumentos { get; }
    }
}