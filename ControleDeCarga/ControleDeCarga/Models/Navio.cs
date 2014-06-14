namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Navio: ModificationControlledModel
    {
        public Navio()
        {
            
        }
    
        public int Id { get; set; }
        
        [DisplayName("Navio")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
       
    }
}
