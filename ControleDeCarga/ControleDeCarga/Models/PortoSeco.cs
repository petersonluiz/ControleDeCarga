namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class PortoSeco: ModificationControlledModel
    {
        public PortoSeco()
        {
            //this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Porto Seco")]
        public string Nome { get; set; }

        [DisplayName("Estado")]
        public int UfId { get; set; }

        public virtual UF Uf { get; set; }

    
        //public virtual ICollection<Carga> Carga { get; set; }
    }
}
