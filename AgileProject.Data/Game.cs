using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileProject.Data
{
    public class Game
    {
        [Key]
        public string SKU { get; set; }
        [Required]
        public string Title { get; set; }
        
        public double Rating { get; set; }
        
        public decimal Cost { get; set; }
        
        public int NumberInInventory { get; set; }
        public bool IsInStock
        {
            get
            {
                return NumberInInventory > 0;
            }
        }
    }
}
