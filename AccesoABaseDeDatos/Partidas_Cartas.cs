namespace AccesoABaseDeDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partidas_Cartas
    {
        [Key]
        [StringLength(255)]
        public string idPartidasCartas { get; set; }

        public int? idCarta { get; set; }

        [StringLength(50)]
        public string IdPartida { get; set; }

        public virtual Cartas Cartas { get; set; }

        public virtual Partidas Partidas { get; set; }
    }
}
