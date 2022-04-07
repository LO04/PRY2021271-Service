using System;

namespace Montrac.Domain.Models
{
    public class AuditModel
    {
        public AuditModel()
        {
            CreatedAt = DateTime.Now;
        }
        
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}