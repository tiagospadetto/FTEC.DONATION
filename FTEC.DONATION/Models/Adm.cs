using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FTEC.DONATION.Models
{
    public class Adm
    {
        public Adm()
        {
            Id = Guid.NewGuid();
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid Id { get; private set; }
    }
}