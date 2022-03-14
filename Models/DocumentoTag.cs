using System;
using System.Collections.Generic;

namespace base_conhecimento.Models
{
    public partial class DocumentoTag
    {
        public int Id { get; set; }
        public int IdTag { get; set; }
        public int IdDocument { get; set; }

        public virtual Documento IdDocumentNavigation { get; set; } = null!;
        public virtual Tag IdTagNavigation { get; set; } = null!;
    }
}
