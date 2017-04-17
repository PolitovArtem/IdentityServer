﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Models
{
    public class Client
    {
            public Client()
            {
                ClientRoles = new List<Role>();
            }

            [Key]
            public int Id { get; set; }

            [Required()]
            public string Name { get; set; }

            [Required()]
            public string Identifier { get; set; }

            [Required()]
            public string Secret { get; set; }

            [Required()]
            public string Callback { get; set; }

            public string Description { get; set; }

            public string LogoutPage { get; set; }

            public ICollection<Role> ClientRoles { get; set; }
    }
}
