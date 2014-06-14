namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Evento
    {
        public Evento()
        {
            this.HistoricoCarga = new HashSet<HistoricoCarga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Evento")]
        public string Nome { get; set; }

        public int ProximoStatusId { get; set; }

        public bool EnviarEmail { get; set; }

        public virtual ICollection<HistoricoCarga> HistoricoCarga { get; set; }
        public virtual StatusCarga ProximoStatus { get; set; }
    }
}
