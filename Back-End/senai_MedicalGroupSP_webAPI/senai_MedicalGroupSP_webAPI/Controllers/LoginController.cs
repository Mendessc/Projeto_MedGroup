﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using senai_MedicalGroupSP_webAPI.Repositories;
using senai_MedicalGroupSP_webAPI.ViewModel;
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
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel Login)
        {
            Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha incorretos");
            }

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai_MedicalGroupSP.webAPI.securitykey"));

            var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "senai_MedicalGroupSP.webAPI",
                audience: "senai_MedicalGroupSP.webAPI",
                claims: Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: Creds
                );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
}
