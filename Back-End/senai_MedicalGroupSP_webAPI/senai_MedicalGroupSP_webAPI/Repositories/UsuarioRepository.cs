using Microsoft.AspNetCore.Http;
using senai_MedicalGroupSP_webAPI.Contexts;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        MedGroupContext ctx = new();
        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario userBuscado = BuscarPorId(idUsuario);

            userBuscado.IdTipoUsuario = userBuscado.IdTipoUsuario;
            userBuscado.Nome = UsuarioAtualizado.Nome;
            userBuscado.Email = UsuarioAtualizado.Email;
            userBuscado.Senha = UsuarioAtualizado.Senha;

            ctx.Usuarios.Update(userBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
        }

        public string ConsultarPerfil(int idUsuario)
        {
            ImagemUser imagemBuscada = new();

            imagemBuscada = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == idUsuario);

            if (imagemBuscada != null)
            {
                return Convert.ToBase64String(imagemBuscada.Binario);
            }

            return null;
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Select(u => new Usuario()
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email=u.Email,
                IdTipoUsuario=u.IdTipoUsuario,
                IdTipoUsuarioNavigation = new Tipousuario()
                {
                    IdTipoUsuario=u.IdTipoUsuarioNavigation.IdTipoUsuario,
                    Tipo=u.IdTipoUsuarioNavigation.Tipo
                }
            })
            .ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }

        public void SalvarPerfil(IFormFile foto, int idUsuario)
        {
            ImagemUser novaImagem = new();

            using (var ms = new MemoryStream())
            {
                foto.CopyTo(ms);

                novaImagem.Binario = ms.ToArray();

                novaImagem.NomeArquivo = foto.FileName;
                novaImagem.MimeType = foto.FileName.Split('.').Last();
                novaImagem.IdUsuario = idUsuario;
            }

            ImagemUser imagemExistente = new();
            imagemExistente = ctx.ImagemUsuarios.FirstOrDefault(i => i.IdUsuario == idUsuario);

            if (imagemExistente != null)
            {
                imagemExistente.Binario = novaImagem.Binario;
                imagemExistente.NomeArquivo = novaImagem.NomeArquivo;
                imagemExistente.MimeType = novaImagem.MimeType;
                imagemExistente.IdUsuario = idUsuario;

                ctx.ImagemUsuarios.Update(imagemExistente);
            }
            else
            {
                ctx.ImagemUsuarios.Add(novaImagem);
            }

            ctx.SaveChanges();
        }
    }
}
