using senai_MedicalGroupSP_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<Tipousuario> Listar();
        Tipousuario BuscarPorId(int idTipousuario);
        void Cadastrar(Tipousuario novoTipousuario);
        void Atualizar(int idTipousuario, Tipousuario TipousuarioAtualizado);
        void Deletar(int idTipousuario);
    }
}
