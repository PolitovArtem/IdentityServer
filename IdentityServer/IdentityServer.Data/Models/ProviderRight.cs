﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Models
{
    public class ProviderRight
    {
        //TODO this entity should be removed. All neccessary information will be stored in Role
        [Key]
        public long Id { get; set; }

        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AuthorisationResource Resource { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
