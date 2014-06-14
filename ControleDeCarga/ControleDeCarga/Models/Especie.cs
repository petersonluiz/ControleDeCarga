namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Especie: ModificationControlledModel
    {
        public Especie()
        {
            this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Esp�cie")]
        public string Nome { get; set; }
        
        
        [DisplayName("Descri��o")]
        public string Descricao { get; set; }
    
        public virtual ICollection<Carga> Carga { get; set; }
    }
}
