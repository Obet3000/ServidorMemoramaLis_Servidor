//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoADatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partidas_Jugadores
    {
        public string idPartida_IdJugador { get; set; }
        public string idPartida { get; set; }
        public Nullable<System.Guid> idJugador { get; set; }
    
        public virtual Jugadores Jugadores { get; set; }
        public virtual Partidas Partidas { get; set; }
    }
}
