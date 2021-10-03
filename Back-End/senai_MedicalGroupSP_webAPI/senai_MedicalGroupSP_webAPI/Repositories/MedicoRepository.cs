using Microsoft.EntityFrameworkCore;
using senai_MedicalGroupSP_webAPI.Contexts;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        MedGroupContext ctx = new();
        public void Atualizar(int idMedico, Medico atualizarMedico)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            medicoBuscado.IdUsuario = medicoBuscado.IdUsuario;
            medicoBuscado.IdEspecialidade = atualizarMedico.IdEspecialidade;
            medicoBuscado.IdClinica = atualizarMedico.IdClinica;
            medicoBuscado.NomeMedico = atualizarMedico.NomeMedico;
            medicoBuscado.Crm = atualizarMedico.Crm;
            medicoBuscado.IdEspecialidade = atualizarMedico.IdEspecialidade;

            ctx.Medicos.Update(medicoBuscado);
            ctx.SaveChanges();
                               
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == idMedico);
        }

        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            ctx.Medicos.Remove(BuscarPorId(idMedico));

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.Include(m => m.IdClinicaNavigation).Include(m => m.IdEspecialidadeNavigation).ToList();
        }
    }
}
