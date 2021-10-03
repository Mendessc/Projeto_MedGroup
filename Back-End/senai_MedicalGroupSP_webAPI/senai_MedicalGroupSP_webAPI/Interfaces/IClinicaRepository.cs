using senai_MedicalGroupSP_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Interfaces
{
    interface IClinicaRepository
    {
        void Cadastrar(Clinica novaClinica);
        void Atualizar(int idClinica, Clinica clinicaAtualizada);
        void Deletar(int idClinica);
        List<Clinica> ListarTodos();
        Clinica BuscarPorId(int idClinica);
    }
}
