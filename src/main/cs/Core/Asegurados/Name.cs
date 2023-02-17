using System.Linq;

namespace RI.Novus.Core.Asegurados
{
    /// <summary>
    /// Asegurado's IdentificationNumber
    /// </summary>
    public sealed class Name : AbstractSimpleStringValue
    {
        /// <summary>Minimum allowed length.</summary>
        public const int MinLength = 4;

        /// <summary>Maximum allowed length. </summary>
        public const int MaxLength = 128;

        private static readonly Message _genericMessage = new("Invalid name.");

        private static readonly StringLengthRange _lengthRange =
            new(new StringLength(MinLength), new StringLength(MaxLength));

        /// <inheritdoc />
        protected override ConfigurableString InnerValue { get; }

        /// <summary>Shortcut for constructor.</summary>
        /// <param name="rawName"></param>
        /// <returns></returns>
        public static Name From(string rawName) => new(rawName);

        private Name(string rawName)
        {
            var builder = new ConfigurableString.Builder(_genericMessage, useSingleMessage: true)
                .WithRequiresTrimmed(true)
                .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase)
                .WithLengthRange(_lengthRange, _genericMessage, _genericMessage);

            InnerValue = builder.Build(rawName, rn =>
            {
                bool hasSomeControlCharacter = rn.Any(char.IsControl);
                if (hasSomeControlCharacter)
                {
                    throw new FormatException(_genericMessage.Value);
                }
            });
        }
    }
}
