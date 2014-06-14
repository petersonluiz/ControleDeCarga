namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StatusCarga
    {
        public StatusCarga()
        {
            this.Carga = new HashSet<Carga>();
        }
    
        public int Id { get; set; }
        public string Status { get; set; }
        
    
        public virtual ICollection<Carga> Carga { get; set; }
    }
}
