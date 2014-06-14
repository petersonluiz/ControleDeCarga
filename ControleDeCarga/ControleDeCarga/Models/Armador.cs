namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Armador: ModificationControlledModel
    {
        public Armador()
        {
            //this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Armador")]
        [Required]
        public string Nome { get; set; }

        [DisplayName("Pessoa de contato")]
        public string PessoaContato { get; set; }

        public string Telefone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        //public virtual ICollection<Carga> Carga { get; set; }

       
        
    }
}
