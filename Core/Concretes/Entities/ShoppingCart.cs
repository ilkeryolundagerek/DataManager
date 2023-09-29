using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class ShoppingCart
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required]
        public string UserId { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
    }
}
