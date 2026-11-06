using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    ///     Representa una regla de negocio explícita del dominio.
    /// </summary>
    /// <remarks>
    ///     Encapsular reglas de negocio como objetos permite nombrarlas, probarlas
    ///     y reutilizarlas de forma independiente. El agregado las evalúa y lanza
    ///     una excepción de dominio cuando la regla se viola.
    /// </remarks>
    public interface IBusinessRule
    {
        /// <summary>
        ///     Mensaje descriptivo que se usa cuando la regla se viola.
        /// </summary>
        string Message { get; }

        /// <summary>
        ///     Indica si la regla de negocio se cumple.
        /// </summary>
        /// <returns>
        ///     <code>true</code> si la regla se cumple;
        ///     <code>false</code> si se viola;
        /// </returns>
        bool IsBroken();
    }
}
