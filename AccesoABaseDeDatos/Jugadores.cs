namespace AccesoABaseDeDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jugadores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jugadores()
        {
            Amigos = new HashSet<Amigos>();
            Amigos1 = new HashSet<Amigos>();
            Logins = new HashSet<Logins>();
            Partidas_Jugadores = new HashSet<Partidas_Jugadores>();
            Puntuaciones = new HashSet<Puntuaciones>();
        }

        [Key]
        [StringLength(20)]
        public string idJugador { get; set; }

        [StringLength(20)]
        public string nombreJugador { get; set; }

        [StringLength(30)]
        public string contrasenia { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(255)]
        public string Fotos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Amigos> Amigos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Amigos> Amigos1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Logins> Logins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partidas_Jugadores> Partidas_Jugadores { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puntuaciones> Puntuaciones { get; set; }
    }
}
