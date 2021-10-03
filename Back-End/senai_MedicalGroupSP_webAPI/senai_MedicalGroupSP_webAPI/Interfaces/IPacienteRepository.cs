using senai_MedicalGroupSP_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Interfaces
{
    interface IPacienteRepository
    {
        void Cadastrar(Paciente novoPaciente);
        void Atualizar(int idPaciente, Paciente atualizarPaciente);
        void Deletar(int idPaciente);
        List<Paciente> ListarTodos();
        Paciente BuscarPorId(int idPaciente);
    }
}
