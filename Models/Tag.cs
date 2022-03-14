using System;
using System.Collections.Generic;

namespace base_conhecimento.Models
{
    public partial class Tag
    {
        public Tag()
        {
            DocumentoTags = new HashSet<DocumentoTag>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<DocumentoTag> DocumentoTags { get; set; }
    }
}
