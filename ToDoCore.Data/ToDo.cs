using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoCore.Data
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Boş geçilemez")]
        [MaxLength(500, ErrorMessage = "En çok 500 karakter")]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "Boş geçilemez")]
        [MaxLength(1000, ErrorMessage = "En çok 1000 karakter")]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
