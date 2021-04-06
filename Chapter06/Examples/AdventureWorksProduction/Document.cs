using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Examples.AdventureWorksProduction
{
    public partial class Document
    {
        public Document()
        {
            Productdocuments = new HashSet<Productdocument>();
        }

        public string Title { get; set; }
        public int Owner { get; set; }
        public bool Folderflag { get; set; }
        public string Filename { get; set; }
        public string Fileextension { get; set; }
        public string Revision { get; set; }
        public int Changenumber { get; set; }
        public short Status { get; set; }
        public string Documentsummary { get; set; }
        public byte[] Document1 { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime Modifieddate { get; set; }
        public string Documentnode { get; set; }

        public virtual ICollection<Productdocument> Productdocuments { get; set; }
    }
}
