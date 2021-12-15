﻿using Microsoft.AspNetCore.Http;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacoesController : ControllerBase
    {
        private ILocalizacaoRepository _localizacaoRepository { get; set; }

        public LocalizacoesController()
        {
            _localizacaoRepository = new LocalizacaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_localizacaoRepository.ListarTodas());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Localizacao novaLocalizacao) 
        {
            try
            {
                _localizacaoRepository.Cadastrar(novaLocalizacao);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
