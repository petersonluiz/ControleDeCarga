//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class TipoVeiculo
    {
        public TipoVeiculo()
        {
            this.Veiculo = new HashSet<Veiculo>();
        }
    
        public int id { get; set; }

        [DisplayName("Tipo")]
        public string Nome { get; set; }

        public string CriadoPor { get; set; }
        public Nullable<System.DateTime> CriadoEm { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> ModificadoEm { get; set; }
    
        public virtual ICollection<Veiculo> Veiculo { get; set; }
    }
}
