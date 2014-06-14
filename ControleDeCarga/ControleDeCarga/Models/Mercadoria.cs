namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Mercadoria: ModificationControlledModel
    {
        public Mercadoria()
        {
            this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Mercadoria")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    
        public virtual ICollection<Carga> Carga { get; set; }
    }
}
