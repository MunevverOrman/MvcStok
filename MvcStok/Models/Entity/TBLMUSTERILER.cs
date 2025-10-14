

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMUSTERILER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMUSTERILER()
        {
            this.TBLSATISLAR = new HashSet<TBLSATISLAR>();
        }
    
        public int MUSTERIID { get; set; }

        [Required(ErrorMessage ="Bu alaný boþ býrakamazsýnýz...")]
        [StringLength(50, ErrorMessage ="50 karakterden uzun olamaz...")]
        public string MUSTERIAD { get; set; }
        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSATISLAR> TBLSATISLAR { get; set; }
    }
}
