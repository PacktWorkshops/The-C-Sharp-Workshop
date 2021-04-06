using System;
using System.Collections.Generic;

#nullable disable

namespace Chapter06.Models3
{
    public partial class Productphoto
    {
        public Productphoto()
        {
            Productproductphotos = new HashSet<Productproductphoto>();
        }

        public int Productphotoid { get; set; }
        public byte[] Thumbnailphoto { get; set; }
        public string Thumbnailphotofilename { get; set; }
        public byte[] Largephoto { get; set; }
        public string Largephotofilename { get; set; }
        public DateTime Modifieddate { get; set; }

        public virtual ICollection<Productproductphoto> Productproductphotos { get; set; }
    }
}
