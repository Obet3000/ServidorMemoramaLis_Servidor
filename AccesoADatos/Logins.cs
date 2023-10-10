namespace AccesoADatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logins
    {
        [Key]
        [StringLength(20)]
        public string idLogin { get; set; }

        [StringLength(30)]
        public string contrasenia { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(20)]
        public string idJugador { get; set; }

        public virtual Jugadores Jugadores { get; set; }
    }
}
