﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Models
{
    public class Role
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название роли")]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Client")]
        public Client Client { get; set; }

        [Required]
        [ForeignKey("ResourceRight")]
        public ResourceRight Right { get; set; }
    }
}
