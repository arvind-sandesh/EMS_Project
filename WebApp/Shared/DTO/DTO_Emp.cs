
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp.Shared.DTO
{
    public class EmployeeInsertDTO
    {
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(35)]
        public string MobileNumber { get; set; }

        [Required]        
        public int DepartmentId { get; set; }        
    }
}
