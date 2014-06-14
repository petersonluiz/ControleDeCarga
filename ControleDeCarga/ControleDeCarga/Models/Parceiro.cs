namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Parceiro: ModificationControlledModel
    {
        public int Id { get; set; }

        [DisplayName("Parceiro")]
        public string Nome { get; set; }

        public string Telefone { get; set; }

    }
}
