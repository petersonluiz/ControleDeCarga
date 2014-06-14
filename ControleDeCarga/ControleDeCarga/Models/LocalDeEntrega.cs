using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ControleDeCarga.Models
{   
    
    public class LocalDeEntrega: ModificationControlledModel
    {
        public LocalDeEntrega()
        {
            //this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }
        public string Cidade { get; set; }
        
        [DisplayName("Estado")]
        public int UfId { get; set; }
        
        //public virtual ICollection<Carga> Carga { get; set; }

       

        public virtual UF Uf { get; set; }
    }
}
