using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_MedicalGroupSP_webAPI.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o Email do úsuario")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha do úsuario")]
        public string Senha { get; set; }
    }
}
