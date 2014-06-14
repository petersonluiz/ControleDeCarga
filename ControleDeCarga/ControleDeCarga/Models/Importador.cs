namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Importador: ModificationControlledModel
    {
        public Importador()
        {
            this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Importador")]
        public string Nome { get; set; }

        public string CNPJ { get; set; }
        
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        
    
        public virtual ICollection<Carga> Carga { get; set; }
    }
}
