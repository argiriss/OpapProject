using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpapProject.Models
{
    public class Draw
    {
        //Properties
        [Required]
        public int id { get; set; }

        [Required]
        public int DrawNumber { get; set; }

        [Required]
        public DateTime DrawDate { get; set; }

        [Required]
        public int Number1 { get; set; }

        [Required]
        public int Number2 { get; set; }

        [Required]
        public int Number3 { get; set; }

        [Required]
        public int Number4 { get; set; }

        [Required]
        public int Number5 { get; set; }

        [Required]
        public int Joker { get; set; }

        [Required]
        public bool Jackpot { get; set; }

        //Methods
    }
}
