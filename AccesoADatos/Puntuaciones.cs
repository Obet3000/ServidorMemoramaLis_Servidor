namespace AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Puntuaciones
    {
        [Key]
        [StringLength(20)]
        public string idPuntuacion { get; set; }

        public int? puntuacion { get; set; }

        [StringLength(20)]
        public string idJugador { get; set; }

        public virtual Jugadores Jugadores { get; set; }
    }
}
