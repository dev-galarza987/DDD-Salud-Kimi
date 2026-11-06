using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    ///     Despachador síncrono y mínimo de eventos de dominio.
    /// </summary>
    /// <remarks>
    ///     Recorre los eventos pendientes de los agregados y los entrega a los
    ///     manejadores registrados. En una aplicación real esto lo haría MediatR
    ///     o un bus de eventos; aquí se implementa a mano para mantener el ejemplo
    ///     libre de dependencias NuGet y que puedas ver exactamente qué ocurre.
    /// </remarks>
    public class DomainEventDispatcher
    {
        private readonly Dictionary<Type, List<Action<IDomainEvent>>> _handlers = new Dictionary<Type, List<Action<IDomainEvent>>>();

        /// <summary>
        ///     Registra un manejador para un tipo de evento de dominio.
        /// </summary>
        /// <typeparam name="TEvent">Tipo del evento.</typeparam>
        /// <param name="handler">Acción que procesará el evento.</param>
        public void Register<TEvent>(Action<TEvent> handler) where TEvent : IDomainEvent
        {
            var eventType = typeof(TEvent);
            if (!_handlers.ContainsKey(eventType)) _handlers[eventType] = new List<Action<IDomainEvent>>();
            _handlers[eventType].Add(e => handler((TEvent)e));
        }

        /// <summary>
        ///     Despacha todos los eventos pendientes de los agregados indicados.
        /// </summary>
        /// <param name="aggregates">Agregados cuyos eventos pendientes se despacharán.</param>
        public void Dispatch(IEnumerable<IDomainEvent> aggregates)
        {
            foreach (var domainEvent in aggregates.ToList())
            {
                var eventType = domainEvent.GetType();
                if (_handlers.TryGetValue(eventType, out var handlers))
                {
                    foreach (var handler in handlers) handler(domainEvent);
                }
            }
        }
    }
}
