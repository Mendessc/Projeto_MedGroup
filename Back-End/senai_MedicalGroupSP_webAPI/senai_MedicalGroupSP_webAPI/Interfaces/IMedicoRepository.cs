using senai_MedicalGroupSP_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();
        void Cadastrar(Medico novoMedico);
        void Atualizar(int idMedico, Medico atualizarMedico);
        void Deletar(int idMedico);
        Medico BuscarPorId(int idMedico);
    }
}
