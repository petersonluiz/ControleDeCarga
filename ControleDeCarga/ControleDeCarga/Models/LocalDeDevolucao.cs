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

        
        [DisplayName("Local de devolu��o")]
        public string Nome { get; set; }

        //[DisplayName("Endere�o")]
        //public string Endereco { get; set; }
        
    
        //public virtual ICollection<Carga> Carga { get; set; }
    }
}
