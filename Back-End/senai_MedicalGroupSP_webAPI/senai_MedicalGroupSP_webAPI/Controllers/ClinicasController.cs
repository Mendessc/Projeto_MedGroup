using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using senai_MedicalGroupSP_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }
        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica)
        {
            _clinicaRepository.Cadastrar(novaClinica);

            return StatusCode(201, new
            {
                Mensagem = "Nova clinica criada",
                novaClinica
            });
        }

        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Listar()
        {
            List<Clinica> listaClinicas = _clinicaRepository.ListarTodos();

            if (listaClinicas == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Nenhum paciente encontrado"
                });
            }

            return Ok(listaClinicas);
        }
    }
}
