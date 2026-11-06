using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    /// Interfaz marcador para todos los eventos de dominio.
    /// </summary>
    /// <remarks>
    /// Un EVENTO DE DOMINIO representa algo que YA OCURRIÓ en el dominio y que
    /// es relevante para el negocio. Se expresa en pasado ("CitaAgendada",
    /// "PacienteAtendido") y transporta los datos necesarios para que otros
    /// interesados reaccionen.
    ///
    /// Los eventos se acumulan dentro del agregado y se despachan cuando la
    /// operación se confirma (patrón diferido de Jimmy Bogard), lo que desacopla
    /// la generación del evento de su procesamiento.
    /// </remarks>
    public interface IDomainEvent
    {
        /// <summary>
        /// Fecha y hora (UTC) en que ocurrió el hecho representado por el evento.
        /// </summary>
        DateTime OcurredOn { get; }
    }

    /// <summary>
    /// Clase base para los eventos de dominio.
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        /// <inheritdoc/>>
        public DateTime OcurredOn { get; }

        protected DomainEvent() => OcurredOn = DateTime.Now;
    }
}
