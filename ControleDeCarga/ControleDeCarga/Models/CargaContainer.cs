using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ControleDeCarga.Models
{
    public class CargaContainer: Carga
    {       
        [DisplayName("Porto Seco")]
        public Nullable<int> PortoSecoId { get; set; }

        [DisplayName("Local de Devolução")]
        public Nullable<int> LocalDeDevolucaoId { get; set; }

        [DisplayName("Navio")]
        public Nullable<int> NavioId { get; set; }

        [DisplayName("Armador")]
        public Nullable<int> ArmadorId { get; set; }

        public virtual PortoSeco PortoSeco { get; set; }
        public virtual LocalDeDevolucao LocalDeDevolucao { get; set; }
        public virtual Navio Navio { get; set; }
        public virtual Armador Armador { get; set; }
        public virtual ICollection<Container> Containers { get; set; }

    }
}