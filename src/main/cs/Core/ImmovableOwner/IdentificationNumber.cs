using System.Linq;

namespace RI.Novus.Core.ImmovableOwner;


    /// <summary>
    /// ImmovableOwnerClass's IdentificationNumber
    /// </summary>
    public sealed class IdentificationNumber : AbstractSimpleStringValue
    {

        /// <summary>Minimum allowed length.</summary>
        public const int MinLength = 9;

        /// <summary>Maximum allowed length. </summary>
        public const int MaxLength = 16;

        private static readonly Message _genericMessage = new("Invalid identificationNumber.");

        private static readonly StringLengthRange _lengthRange =
            new(new StringLength(MinLength), new StringLength(MaxLength));

        private IdentificationNumber(string rawidentificationNumber)
        {
            ConfigurableString.Builder builder = new ConfigurableString.Builder(_genericMessage, useSingleMessage: true)
                .WithRequiresTrimmed(true)
                .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase)
                .WithLengthRange(_lengthRange, _genericMessage, _genericMessage);

            InnerValue = builder.Build(rawidentificationNumber, rn =>
            {
                bool hasSomeControlCharacter = rn.Any(char.IsControl);
                if (hasSomeControlCharacter)
                {
                    throw new FormatException(_genericMessage.Value);
                }
            });
        }

        /// <inheritdoc />
        protected override ConfigurableString InnerValue { get; }

        /// <summary>Shortcut for constructor.</summary>
        /// <param name="rawidentificationNumber"></param>
        /// <returns></returns>
        public static IdentificationNumber From(string rawidentificationNumber) => new(rawidentificationNumber);
    }

