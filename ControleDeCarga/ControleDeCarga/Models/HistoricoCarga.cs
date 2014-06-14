namespace ControleDeCarga.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public partial class HistoricoCarga: ModificationControlledModel
    {
        public int Id { get; set; }

        [DisplayName("Evento")]
        public Nullable<int> EventoId { get; set; }

        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> Data { get; set; }

        [DisplayName("Motorista")]
        public Nullable<int> MotoristaId { get; set; }

        [DisplayName("Veiculo")]
        public Nullable<int> VeiculoId { get; set; }

        [DisplayName("Observações")]
        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }

        public Nullable<int> CargaId { get; set; }
        
    
        public virtual Carga Carga { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual Motorista Motorista { get; set; }
        public virtual Veiculo Veiculo { get; set; }

        public void AtualizaStatusDaCarga(ApplicationDbContext db)
        {            
            Evento evento = db.Evento.Include("ProximoStatus").Single(e => e.Id == this.EventoId);
            Carga carga = db.Cargas.Find(this.CargaId);
            carga.StatusCarga = evento.ProximoStatus;
        }

    }
}
