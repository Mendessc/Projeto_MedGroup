using senai_MedicalGroupSP_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.Interfaces
{
    interface ILocalizacaoRepository
    {
        List<Localizacao> ListarTodas();

        void Cadastrar(Localizacao novaLocalizacao);
    }
}
