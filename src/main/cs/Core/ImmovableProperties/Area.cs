

namespace RI.Novus.Core.ImmovableProperties
{

    ///<summary>Represents ImmovableProperty's Area</summary>
    public sealed class Area : ICoreDomainPrimitive<decimal>
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
        /// Shortcut for constructor <see cref="Area"/>.
        /// <param name="area">Represents a area.</param>
        /// <returns>An instance of <see cref="Area"/></returns>
        /// </summary>
        public static Area From(decimal area) => new(area);

        private Area(decimal rawArea)
          => Value = Arguments.Between(rawArea, MinValue, MaxValue, nameof(rawArea), "Invalid value or format for ImmovableProperty's Area");

        /// <summary>
        /// Gets property value
        /// </summary>
        public decimal Value { get; }
    }
}
