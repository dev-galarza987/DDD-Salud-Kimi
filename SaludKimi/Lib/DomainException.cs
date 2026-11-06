using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    ///     Excepción base para todas las violaciones de reglas de negocios del dominio.
    /// </summary>
    /// <remarks>
    ///     En DDD, una regla de negocio que se viola debe lanzer una excepción de dominio (o devolver un resultado de error, según el estilo elegido).
    ///     Estas excepciones forman parte del lenguaje ubicio: su nombre describe la regla de negocio rota, no un error técnico.
    /// </remarks>
    public class DomainException : Exception
    {
        /// <summary>
        ///     Inicializa una nueva excepción de dominio con el mensaje de la regla violada.
        /// </summary>
        /// <param name="message">Descripción de la violación de la regla de negocio.</param>
        public DomainException(string message) : base(message) { }
    }
}
