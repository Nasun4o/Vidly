using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsLatter { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}