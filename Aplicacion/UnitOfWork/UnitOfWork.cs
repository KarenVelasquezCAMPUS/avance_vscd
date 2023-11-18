
using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
        private readonly ApiAvancevscdContext _context;

        private DocumentoRepository _documentos;
        private EmpresaRepository _empresas; 
        private EstadoRepository _estados;
        private NumeracionRepository _numeraciones; 
        private TipoDocumentoRepository _tipodocumentos;

        public UnitOfWork (ApiAvancevscdContext context)
        {
            _context = context;
        }

        public IDocumentoRepository Documentos
        {
            get
            {
                if (_documentos == null)
                {
                    _documentos = new DocumentoRepository(_context);
                }
                return _documentos;
            }
        }

        public IEmpresaRepository Empresas
        {
            get
            {
                if (_empresas == null)
                {
                    _empresas = new EmpresaRepository(_context);
                }
                return _empresas;
            }
        }

        public IEstadoRepository Estados
        {
            get
            {
                if (_estados == null)
                {
                    _estados = new EstadoRepository(_context);
                }
                return _estados;
            }
        }

        public INumeracionRepository Numeraciones
        {
            get
            {
                if (_numeraciones == null)
                {
                    _numeraciones = new NumeracionRepository(_context);
                }
                return _numeraciones;
            }
        }

        public ITipoDocumentoRepository TipoDocumentos
        {
            get
            {
                if (_tipodocumentos == null)
                {
                    _tipodocumentos = new TipoDocumentoRepository(_context);
                }
                return _tipodocumentos;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}