using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class NumeracionRepository : GenericRepository<Numeracion>, INumeracionRepository
    {
        public NumeracionRepository(ApiAvancevscdContext contex) : base(contex)
        {
        }
    }
}