namespace AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Amigos
    {
        [Key]
        [StringLength(20)]
        public string IdAmigos { get; set; }

        [StringLength(20)]
        public string IdJugador { get; set; }

        [StringLength(20)]
        public string IdAmigo { get; set; }

        public virtual Jugadores Jugadores { get; set; }

        public virtual Jugadores Jugadores1 { get; set; }
    }
}
