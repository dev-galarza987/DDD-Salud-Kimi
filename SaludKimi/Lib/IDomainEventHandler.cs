using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    ///     Interfaz para los manejadores de eventos de dominio.
    /// </summary>
    /// <remarks>
    ///     Un manejador de eventos contiene la LÓGICA DE APLICACIÓN que reacciona a
    ///     un evento de dominio (enviar notificaciones, actualizar otros agregados,
    ///     registrar auditoría...). El dominio solo publica; los efectos secundarios
    ///     viven fuera del modelo, en la capa de aplicación.
    ///
    ///     En este ejemplo de consola los manejadores se invocan manualmente para
    ///     que puedas ver el flujo completo sin frameworks.
    /// </remarks>
    /// <typeparam name="TEvent">Tipo del evento de dominio que maneja.</typeparam>
    public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
    {
        /// <summary>
        ///     Maneja el evento de dominio.
        /// </summary>
        /// <param name="domainEvent"></param>
        void Handle(TEvent domainEvent);
    }
}
