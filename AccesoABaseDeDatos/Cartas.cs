namespace AccesoABaseDeDatos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cartas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cartas()
        {
            Partidas_Cartas = new HashSet<Partidas_Cartas>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idCarta { get; set; }

        [StringLength(25)]
        public string nombre_carta { get; set; }

        [StringLength(255)]
        public string descripcion { get; set; }

        [StringLength(255)]
        public string imagenRuta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partidas_Cartas> Partidas_Cartas { get; set; }
    }
}
