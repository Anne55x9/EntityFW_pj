namespace EntityFW_pj
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableAppointment")]
    public partial class TableAppointment
    {
        [Key]
        public int AppointmentNo { get; set; }

        [Required]
        [StringLength(30)]
        public string AppointmentDate { get; set; }

        [Required]
        [StringLength(20)]
        public string PersonCPR { get; set; }

        public virtual TablePerson TablePerson { get; set; }
    }
}
