using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FTEC.DONATION.Models
{
    public class Fundacao
    {
        public Fundacao()
        {
            Id = Guid.NewGuid();
        }
        public string Nome  { get; set;}
        public string Tipo  { get; set;}
        public string Email { get; set; }
        public string Senha { get; set; }
        public Guid Id { get; private set; }

    }
}