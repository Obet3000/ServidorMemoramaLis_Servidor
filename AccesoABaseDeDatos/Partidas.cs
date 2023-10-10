namespace AccesoABaseDeDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Partidas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partidas()
        {
            Partidas_Cartas = new HashSet<Partidas_Cartas>();
            Partidas_Jugadores = new HashSet<Partidas_Jugadores>();
        }

        [Key]
        [StringLength(50)]
        public string idPartida { get; set; }

        public int? numeroJugadores { get; set; }

        [StringLength(6)]
        public string codigoPartida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partidas_Cartas> Partidas_Cartas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partidas_Jugadores> Partidas_Jugadores { get; set; }
    }
}
