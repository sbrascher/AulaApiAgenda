using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaAPI.Servico.Seguranca
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public string Teste { get; set; }
    }
}
