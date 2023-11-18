using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiAvancevscd.Controllers;
public class DocumentoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;

    public DocumentoController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
}