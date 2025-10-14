

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLKATEGORILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKATEGORILER()
        {
            this.TBLURUNLER = new HashSet<TBLURUNLER>();
        }
    
        public short KATEGORIID { get; set; }

        [Required(ErrorMessage ="Kategori adýný boþ býrakamazsýnýz...")]
        public string KATEGORIAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLURUNLER> TBLURUNLER { get; set; }
    }
}
