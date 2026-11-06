using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    /// Clase base abstracta para todos los objetos de valor del dominio.
    /// </summary>
    /// <remarks>
    /// Un OBJETO DE VALOR (Value Object) en DDD describe una característica del
    /// dominio y NO tiene identidad propia. Se define completamente por sus
    /// atributos: dos objetos de valor con los mismos datos son iguales e
    /// intercambiables. Deben ser inmutables.
    ///
    /// Ejemplo en Salud: una <c>PresionArterial</c> de 120/80 es igual a otra
    /// de 120/80, sin importar a qué paciente pertenezca.
    /// </remarks>
    public abstract class ValueObject
    {
        /// <summary>
        /// Devuelve los componentes que definen la igualdad del objeto de valor.
        /// La igualdad se calcula comparando estos componentes uno a uno.
        /// </summary>
        /// <returns>Secuencia de objetos que componen la identidad del valor.</returns>
        protected abstract IEnumerable<object?> GetEqualityComponents();

        /// <summary>
        /// Determina si dos objetos de valor son iguales comparando sus componentes.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns><c>true</c> si todos los componentes son iguales; en caso contrario, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Devuelve el código hash combinando los hashes de todos los componentes.
        /// </summary>
        /// <returns>Código hash del objeto de valor.</returns>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x?.GetHashCode() ?? 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Operador de igualdad para objetos de valor.
        /// </summary>
        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        /// <summary>
        /// Operador de desigualdad para objetos de valor.
        /// </summary>
        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return !(left == right);
        }
    }
}
