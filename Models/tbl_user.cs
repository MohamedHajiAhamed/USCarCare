namespace USCarCare.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_user
    {
        [Required]
        [Key]
        public int user_id { get; set; }
        [Required]
        [StringLength(50)]
        public string first_name { get; set; }
        [Required]
        [StringLength(50)]
        public string last_name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [StringLength(100)]
        public string email { get; set; }
        [Required]
        [RegularExpression("^.{8,}$",ErrorMessage = "Password Must Be 8 Charcters long")]
        [StringLength(50)]
        public string password { get; set; }
        [Required]
        [Compare("password")]
        [StringLength(50)]
        public string confirm_password { get; set; }
        [DefaultValue("Customer")]
        [StringLength(20)]
        public string user_type { get; set; }
        public tbl_user()
        {
            // Set the default value if it is not provided
            if (string.IsNullOrEmpty(user_type))
            {
                user_type = "Customer";
            }
        }
    }
}
