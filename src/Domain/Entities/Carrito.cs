﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrito
    {
        public Carrito()
        {
            CarritoProductos = new HashSet<CarritoProducto>();
            Ordens = new HashSet<Orden>();
        }

        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; }
        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
