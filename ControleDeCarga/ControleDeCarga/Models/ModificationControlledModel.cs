using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeCarga.Models
{
    public class ModificationControlledModel
    {
        [ScaffoldColumn(false)]
        [DisplayName("Criador por")]
        public string CriadoPorUserId { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        [DisplayName("Criado em")]
        public Nullable<System.DateTime> CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Modificado por")]
        public string ModificadoPorUserId { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        [DisplayName("Modificado em")]
        public Nullable<System.DateTime> ModificadoEm { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Criador por")]
        public virtual ApplicationUser CriadoPorUser { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Modificado por")]
        public virtual ApplicationUser ModificadoPorUser { get; set; }
        


        public virtual void OnCreate(string userId)
        {
            this.CriadoPorUserId = userId;
            this.CriadoEm = DateTime.Now;
            this.ModificadoPorUserId = userId;
            this.ModificadoEm = DateTime.Now;
        }

        public virtual void OnUpdate(string userId)
        {
            this.CriadoPorUserId = this.CriadoPorUserId;
            this.CriadoEm = this.CriadoEm;
            this.ModificadoPorUserId = userId;
            this.ModificadoEm = DateTime.Now;
        }


    }
}