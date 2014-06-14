using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ControleDeCarga.Models
{
    public class Container
    {
        public int Id { get; set; }

        public int CargaContainerId { get; set; }

        [DisplayName("Tipo de Container")]
        public string TipoContainer { get; set; }

        public string Identificador { get; set; }

        public virtual CargaContainer CargaContainer { get; set; }
    }
}