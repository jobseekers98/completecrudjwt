using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("tbl_Department")]
    public class DepartmentModel
    {
        [Key]

        public int DeptId {get;set;}
        public string DeptName { get; set; }



    }
}
