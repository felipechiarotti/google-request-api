using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleRequestWebAPI.Model
{
    public class Website
    {
        public string Nome { get; private set; }
        public string Url { get; private set; }

        public Website(string nome, string url)
        {
            this.Nome = nome;
            this.Url = url;
        }
    }
}
