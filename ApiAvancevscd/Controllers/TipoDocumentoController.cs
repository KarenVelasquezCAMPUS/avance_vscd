using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiAvancevscd.Controllers;
public class TipoDocumentoController : Controller
{
    private readonly IUnitOfWork unitOfWork;

    public TipoDocumentoController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoDocumento>>> Get()
    {
        var result = await unitOfWork.TipoDocumentos.GetAllAsync();
        return Ok (result);
    }
}