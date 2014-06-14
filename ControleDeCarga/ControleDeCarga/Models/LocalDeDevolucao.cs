namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class LocalDeDevolucao: ModificationControlledModel
    {
        public LocalDeDevolucao()
        {
            //this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }

        
        [DisplayName("Local de devolução")]
        public string Nome { get; set; }

        //[DisplayName("Endereço")]
        //public string Endereco { get; set; }
        
    
        //public virtual ICollection<Carga> Carga { get; set; }
    }
}
