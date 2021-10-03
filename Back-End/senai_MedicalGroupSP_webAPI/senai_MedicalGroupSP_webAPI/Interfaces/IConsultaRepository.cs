using senai_MedicalGroupSP_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> ListarTodos();
        List<Consulta> ListarMinhas(int id, int idTipo);
        void Cadastrar(Consulta novaConsulta);
        void Cancelar(int idConsulta);
        void Deletar(int idConsulta);
        void AlterarDescricao(string novaDescricao, int idConsulta);
        Consulta BuscarPorId(int idConsulta);
    }
}
