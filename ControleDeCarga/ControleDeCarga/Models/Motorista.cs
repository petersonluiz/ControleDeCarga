namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Motorista: ModificationControlledModel
    {
        public Motorista()
        {
            this.HistoricoCarga = new HashSet<HistoricoCarga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Motorista")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        
    
        public virtual ICollection<HistoricoCarga> HistoricoCarga { get; set; }
    }
}
