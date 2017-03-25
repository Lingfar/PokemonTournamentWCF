﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EntityObject
    {
        [Required]
        public int ID { get; set; }

        public EntityObject()
        {

        }

        public EntityObject(int id)
        {
            ID = id;
        }
    }
}