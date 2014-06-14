using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ControleDeCarga.Models
{
    public class UF
    {
        [DisplayName("Estado")]
        public int Id { get; set; }

        [DisplayName("Estado")]
        public string Sigla { get; set; }

        public string Nome { get; set; }
    }
}