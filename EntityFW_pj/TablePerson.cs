namespace EntityFW_pj
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablePerson")]
    public partial class TablePerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TablePerson()
        {
            TableAppointments = new HashSet<TableAppointment>();
        }

        [Key]
        [StringLength(20)]
        public string PersonCPR { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableAppointment> TableAppointments { get; set; }
    }
}
