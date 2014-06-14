namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Carga: ModificationControlledModel
    {
        public Carga()
        {
            this.HistoricoCarga = new HashSet<HistoricoCarga>();
        }
    
        public int Id { get; set; }

        [DisplayName("Importador")]
        public int ImportadorId { get; set; }

        [DisplayName("Exportador")]
        public int ExportadorId { get; set; }

        public string DTA { get; set; }

        [DisplayName("DI/DSI")]
        public string DI_DSI { get; set; }

        [DisplayName("Mercadoria")]
        public int MercadoriaId { get; set; }

        [DisplayName("Espécie")]
        public int EspecieId { get; set; }

        [DisplayName("Filial")]
        public int? FilialId { get; set; }

        [DisplayName("Local de Entrega")]
        public int LocalDeEntregaId { get; set; }

        [DisplayName("Status")]
        public Nullable<int> StatusCargaId { get; set; }

        public virtual Especie Especie { get; set; }
        public virtual Exportador Exportador { get; set; }
        public virtual Importador Importador { get; set; }
        public virtual Filial Filial { get; set; }

        public virtual LocalDeEntrega LocalDeEntrega { get; set; }
        public virtual Mercadoria Mercadoria { get; set; }
        public virtual StatusCarga StatusCarga { get; set; }
        public virtual ICollection<HistoricoCarga> HistoricoCarga { get; set; }
    }
}
