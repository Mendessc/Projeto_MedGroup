using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using senai_MedicalGroupSP_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }
        private IMedicoRepository _medicoRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
            _medicoRepository = new MedicoRepository();
        }

        
        [HttpPost]
        public IActionResult Cadastrar(Consulta novaConsulta)
        {
            if (novaConsulta == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Dados da consulta invalidos ou incompletos"
                });
            }

            _consultaRepository.Cadastrar(novaConsulta);

            return StatusCode(201, new
            {
                Mensagem = "Cadastro de consulta feito"
            });
        }

        [Authorize(Roles = "2")]
        [HttpPatch("Cancelar/{id}")]
        public IActionResult Cancelar(int id)
        {
            if (id < 0 || _consultaRepository.BuscarPorId(id) == null)
            {
                return BadRequest(new
                {
                    Mensagem = "Id invalido ou inexistente"
                });
            }

            _consultaRepository.Cancelar(id);

            return StatusCode(204, new
            {
                Mensagem = "Consulta cancelada"
            });
        }

        
        [HttpGet("Listar/Minhas")]
        public IActionResult ListarMinhas()
        {

                try
                {
                    short id = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                    short idTipo = Convert.ToInt16(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                    List<Consulta> listaConsulta = _consultaRepository.ListarMinhas(id, idTipo);

                    if (listaConsulta.Count == 0)
                    {
                        return BadRequest(new
                        {
                            Mensagem = "Não há nenhuma consulta do medico informado"
                        });
                    }


                    return Ok(listaConsulta);
                }
                catch (Exception erro)
                {

                    return BadRequest(new
                    {
                        mensagem = "Nao foi possivel ver suas consultas",
                        erro
                    });
                }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("Descricao/{id}")]
        public IActionResult AlterarDescricao(Consulta consultaAtualizada, int id)
        {
            Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);
            int idUser = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            int idMed = _medicoRepository.BuscarPorId(idUser).IdMedico;

            if (consultaAtualizada.Descricao == null)
            {
                return BadRequest(new
                {
                    Mensagem = "É necessário informar a descrição"
                });
            }

            if (id <= 0 || _consultaRepository.BuscarPorId(id) == null)
            {
                return NotFound(new
                {
                    Mensagem = "Id informado invalido ou inexistente"
                });
            }

            if (consultaBuscada.IdMedico != idMed)
            {
                return Unauthorized(new
                {
                    Mensagem = "Somente o médico titular pode alterar a descrição dessa consulta"
                });
            }

            _consultaRepository.AlterarDescricao(consultaAtualizada.Descricao, id);

            return Ok(new
            {
                Mensagem = "Descrição da consulta alterada com sucesso",
                consultaAtualizada
            });
        }

        
        [HttpGet]
        public IActionResult ListarTodos()
        {
            if (_consultaRepository.ListarTodos().Count == 0)
            {
                return BadRequest(new
                {
                    Mensagem = "Nenhuma consulta encontrada"
                });
            }

            return Ok(_consultaRepository.ListarTodos());
        }
    }
}

