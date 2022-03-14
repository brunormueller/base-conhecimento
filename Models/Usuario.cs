using System;
using System.Collections.Generic;

namespace base_conhecimento.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Documentos = new HashSet<Documento>();
            Historicos = new HashSet<Historico>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;

        public virtual ICollection<Documento> Documentos { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
    }
}
