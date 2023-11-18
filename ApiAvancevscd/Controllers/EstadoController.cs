using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiAvancevscd.Controllers;
public class EstadoController : Controller
{
    private readonly IUnitOfWork unitOfWork;

    public EstadoController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
}