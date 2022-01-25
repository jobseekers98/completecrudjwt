using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
  
    [Table("EmpDetail")]
    public class EmployeeModel
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [Required]
        [DisplayName("Gender")]
        public string EmployeeGender { get; set; }
        [Required]
        [DisplayName("Designation")]
        public string EmployeeDesignation { get; set; }
    }
}
