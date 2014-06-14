namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Exportador: ModificationControlledModel
    {
        public Exportador()
        {
            this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Exportador")]
        public string Nome { get; set; }

    
        public virtual ICollection<Carga> Carga { get; set; }
    }
}
