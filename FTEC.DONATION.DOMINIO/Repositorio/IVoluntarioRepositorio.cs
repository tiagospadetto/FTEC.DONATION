using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTEC.DONATION.DOMINIO.Entidade;

namespace FTEC.DONATION.DOMINIO.Repositorio
{
    public interface IVoluntarioRepositorio
    {

        void Inserir(EVoluntario voluntario);

        EVoluntario Acesso(string email, string senha);

        List<EVoluntario> List();

    }
}
