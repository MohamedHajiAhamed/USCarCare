namespace USCarCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_service
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Car_Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Car_Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Car_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Car_Registration_Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Service_Type { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Special_Request { get; set; }
    }
}
