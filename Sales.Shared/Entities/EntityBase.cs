﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Item Id
        /// </summary>
        public int Id { get; set; }

        [NotMapped]
        public abstract string EndpoinName { get; }
    }
}
