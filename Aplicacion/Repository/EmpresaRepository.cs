using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApiAvancevscdContext contex) : base(contex)
        {
        }
    }
}