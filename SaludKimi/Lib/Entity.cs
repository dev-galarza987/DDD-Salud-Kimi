using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludKimi.Lib
{
    /// <summary>
    /// Clase base abstracta para todas las entidades del dominio.
    /// </summary>
    /// <remarks>
    /// Una ENTIDAD en DDD es un objeto que tiene identidad propia que persiste a
    /// través del tiempo y de distintos estados. Dos entidades son iguales si
    /// comparten el mismo <see cref="Id"/>, aunque todos sus atributos sean distintos.
    ///
    /// Ejemplo en Salud: dos pacientes llamados "Juan Pérez" son pacientes
    /// distintos porque tienen distinto Id, aunque tengan el mismo nombre.
    /// </remarks>
    /// <typeparam name="TId">Tipo del identificador de la entidad (Guid, int, etc.).</typeparam>
    public abstract class Entity<TId>
    {
        /// <summary>
        /// Identificador único e inmutable de la entidad.
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// Determina si dos entidades son la misma, comparando por identidad y no por atributos.
        /// </summary>
        /// <param name="obj">Objecto a comparar.</param>
        /// <returns>
        ///     <c>true</c> si son la misma entidad; en caso contrario,<c>false</c>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TId> other && GetType() == other.GetType())) return false;
            return EqualityComparer<TId>.Default.Equals(Id, other.Id);
        }


        /// <summary>
        /// Devuelve el código hash basado en el identificador de la entidad.
        /// </summary>
        /// <returns>Código hash de la entidad.</returns>
        public override int GetHashCode()
        {
            return EqualityComparer<TId>.Default.GetHashCode(Id);
        }

        /// <summary>
        /// Operador de igualdad: dos entidades son iguales si tienen el mismo Id y tipo.
        /// </summary>
        public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        {
            if (left is null && right is null) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        /// <summary>
        /// Operador de desigualdad.
        /// </summary>
        public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        {
            return !(left == right);
        }
    }
}
