using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Novus.Core.ImmovableProperties
{
    ///<summary>Represents ImmovableProperty's Surface</summary>
    public sealed class Surface : ICoreDomainPrimitive<decimal>
    {
        
        /// <summary>
        /// As primitive types are inlined by the compiler the coverlet tool does not catch a hit for 
        /// lines `private const decimal MinValue = 0.01M; and MaxValue.
        /// </summary>
    #pragma warning disable CA1802 //Field 'xxx' is 'readonly' but initialized with constant value. Use 'const' instead.
        private static readonly decimal MinValue = 0.01M;
        private static readonly decimal MaxValue = 99_999M;

#pragma warning restore CA1802 //Field 'xxx' is 'readonly' but initialized with constant value. Use 'const' instead.

        /// <summary>
        /// Shortcut for constructor <see cref="Surface"/>.
        /// <param name="surface">Represents a surface.</param>
        /// <returns>An instance of <see cref="Surface"/></returns>
        /// </summary>
        public static Surface From(decimal surface) => new(surface);

        private Surface(decimal rawSurface)
          => Value = Arguments.Between(rawSurface, MinValue, MaxValue, nameof(rawSurface), "Invalid value or format for ImmovableProperty's Surface");

        /// <summary>
        /// Gets property value
        /// </summary>
        public decimal Value { get; }

    }
}
