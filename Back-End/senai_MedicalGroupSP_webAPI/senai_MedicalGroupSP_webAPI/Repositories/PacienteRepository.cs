using senai_MedicalGroupSP_webAPI.Contexts;
using senai_MedicalGroupSP_webAPI.Domains;
using senai_MedicalGroupSP_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        MedGroupContext ctx = new();
        public void Atualizar(int idPaciente, Paciente atualizarPaciente)
        {
            Paciente pacienteBuscado = BuscarPorId(idPaciente);

            pacienteBuscado.IdUsuario = pacienteBuscado.IdUsuario;
            pacienteBuscado.NomePaciente = atualizarPaciente.NomePaciente;
            pacienteBuscado.Rg = atualizarPaciente.Rg;
            pacienteBuscado.Cpf = atualizarPaciente.Cpf;
            pacienteBuscado.DataNascimento = atualizarPaciente.DataNascimento;
            pacienteBuscado.Telefone = atualizarPaciente.Telefone;
            pacienteBuscado.Endereco = atualizarPaciente.Endereco;

            ctx.Pacientes.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            ctx.Pacientes.Remove(BuscarPorId(idPaciente));

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();     
        }
    }
}
