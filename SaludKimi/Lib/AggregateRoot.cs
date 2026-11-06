using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    ///     Clase base para las raíces de agregado del dominio.
    /// </summary>
    /// <remarks>
    ///     Un AGREGADO es un conjunto de entidades y objetos de valor que se tratan
    ///     como una unidad para cambios de estado. La RAÍZ DE AGREGADO es la única
    ///     entidad a la que el exterior puede acceder; garantiza los invariantes del
    ///     agregado completo.
    ///
    ///     Regla de oro: una transacción modifica UN solo agregado. Si una regla de
    ///     negocio cruza agregados, se resuelve con consistencia eventual mediante
    ///     eventos de dominio.
    /// </remarks>
    /// <typeparam name="TId">Tipo del identificador de la raíz de agregado.
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        /// <summary>
        ///     Eventos de dominio producidos por este agregado, pendientes de despachar.
        ///     Se publican normalmente justo antes de confirmar la transacción de persistencia.
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        ///     Agrega un evento de dominio a la lista de eventos pendientes.
        ///     NO dispara el evento inmediatamente: solo lo registra para su despacho posterior.
        /// </summary>
        /// <param name="domainEvent">Evento de dominio ocurrido.</param>
        protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

        /// <summary>
        ///     Elimina un evento de dominio de la lista pendiente.
        /// </summary>
        /// <param name="domainEvent"></param>
        public void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);

        /// <summary>
        ///     Limpia todos los eventos pendientes. Se invoca después de despacharlos.
        /// </summary>
        public void ClearDomainEvent() => _domainEvents.Clear();
    }
}
