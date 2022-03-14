using System;
using System.Collections.Generic;

namespace base_conhecimento.Models
{
    public partial class Historico
    {
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; } = null!;
        public byte[] DataHora { get; set; } = null!;

        public virtual Documento IdDocumentoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
