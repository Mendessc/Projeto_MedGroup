using System;
using System.Collections.Generic;

#nullable disable

namespace senai_MedicalGroupSP_webAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }
        public string NomeClinica { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
