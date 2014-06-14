using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleDeCarga.Models
{
    public class Filial: ModificationControlledModel
    {        
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Cidade { get; set; }

        [DisplayName("Estado")]
        public int UfId { get; set; }
        
        [DisplayName("Endereço")]
        [DataType(DataType.MultilineText)]
        public string Endereco { get; set; }
                
        public string Telefone { get; set; }

        public string Radio { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        public string Contato { get; set; }

        public virtual UF Uf { get; set; }
    }
}