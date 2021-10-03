using senai_MedicalGroupSP_webAPI.Contexts;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        MedGroupContext ctx = new();
        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            clinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
            clinicaBuscada.Telefone = clinicaAtualizada.Telefone;
            clinicaBuscada.Email = clinicaAtualizada.Email;

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);
            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            ctx.Clinicas.ToList();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
