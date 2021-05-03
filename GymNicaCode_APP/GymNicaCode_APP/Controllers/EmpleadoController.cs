﻿using GymNicaCode_Aplicacion.Empleados;
using GymNicaCode_Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymNicaCode_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmpleadoController : MyControllerBase
    {
        //private readonly IMediator _mediator;
        //public EmpleadoController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        [HttpGet]
       
        public async Task<ActionResult<List<EmpleadoDto>>> getEmpleado()
        {
            return await Mediator.Send(new Const_ListaEmpleado.ListaEmpleado());
        }
        [HttpGet("{id}") ]
        public async Task<ActionResult<Empleado>> getEmpleadoxId(Guid id)
        {
            return await Mediator.Send(new Const_EmpleadoXid.EmpleadoXid{Id = id});
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateEmpleado(CreateEmpleado.Create data)
        { 
           return await Mediator.Send(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> UpdateEmpleado(int id, UpdateEmpleado.Update data)
        {
            data.IdEmpleado = id;
            return await Mediator.Send(data);
        }
  

    }
}