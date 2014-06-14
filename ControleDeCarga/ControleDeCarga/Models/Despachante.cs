namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Despachante: ModificationControlledModel
    {
        public int Id { get; set; }

        [DisplayName("Despachante")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        
    }
}
