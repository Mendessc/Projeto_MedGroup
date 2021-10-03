using Microsoft.AspNetCore.Http;
using senai_MedicalGroupSP_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int idUsuario);
        void Cadastrar(Usuario novoUsuario);
        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);
        void Deletar(int idUsuario);
        Usuario Login(string email, string senha);
        void SalvarPerfil(IFormFile foto, int idUsuario);
        string ConsultarPerfil(int idUsuario);
    }
}
