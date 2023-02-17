


namespace RI.Novus.Core.ImmovableOwner
{

    /// <summary>
    /// Represents a InmovableOwner's CreationDate.
    /// </summary>
    public sealed class CreationDate : AbstractPastOrPresentTimestampPrimitive
    {

        /// <summary>Creates a new instance with the system current time as UTC.</summary>
        /// <returns></returns>
        public static CreationDate Now()
            => new(new PastOrPresentTimestamp(DateTimeOffset.UtcNow));

        /// <summary>Shortcut for create a created</summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static CreationDate From(DateTimeOffset dateTimeOffset)
            => new(new PastOrPresentTimestamp(dateTimeOffset));

        private CreationDate(PastOrPresentTimestamp rawCreationDate) : base(rawCreationDate) { }
    }
}
