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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            if (novoMedico.IdUsuario <= 0 || novoMedico.IdEspecialidade <= 0 || novoMedico.IdClinica <= 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Dados invalidos ou incompletos"
                });
            }

            _medicoRepository.Cadastrar(novoMedico);

            return Ok(new
            {
                Mensagem = "Novo médico cadastrado",
                novoMedico
            });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            if (_medicoRepository.ListarTodos().Count <= 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Nenhum médico encontrado"
                });
            }

            return Ok(_medicoRepository.ListarTodos());
        }
    }
}

