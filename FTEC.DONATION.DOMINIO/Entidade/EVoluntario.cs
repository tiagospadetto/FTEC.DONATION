using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTEC.DONATION.DOMINIO.Entidade
{
    public class EVoluntario
    {

        public string Nome      { get; set; }
        public string Sobrenome { get; set; }
        public string Email     { get; set; }
        public string Sexo      { get; set; }
        public string Senha     { get; set; }
        public Guid Id          { get; set; }


    }
}
