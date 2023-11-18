using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(ApiAvancevscdContext contex) : base(contex)
        {
        }
    }
}