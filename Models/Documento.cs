using System;
using System.Collections.Generic;

namespace base_conhecimento.Models
{
    public partial class Documento
    {
        public Documento()
        {
            DocumentoTags = new HashSet<DocumentoTag>();
            Historicos = new HashSet<Historico>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int IdUsuario { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<DocumentoTag> DocumentoTags { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
    }
}
