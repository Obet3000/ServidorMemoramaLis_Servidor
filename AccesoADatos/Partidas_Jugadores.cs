namespace AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partidas_Jugadores
    {
        [Key]
        [StringLength(50)]
        public string idPartida_IdJugador { get; set; }

        [StringLength(50)]
        public string idPartida { get; set; }

        [StringLength(20)]
        public string idJugador { get; set; }

        public virtual Jugadores Jugadores { get; set; }

        public virtual Partidas Partidas { get; set; }
    }
}
