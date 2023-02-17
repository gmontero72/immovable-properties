namespace RI.Novus.Core.Asegurados
{   /// <summary>
    /// Represents a asegurado's Birthdate.
    /// </summary>
    public sealed class Birthdate : AbstractPastOrPresentTimestampPrimitive
    {
        /// <summary>Creates a new instance with the system current time as UTC.</summary>
        /// <returns></returns>
        public static Birthdate Now()
            => new(new PastOrPresentTimestamp(DateTimeOffset.UtcNow));

        /// <summary>Shortcut for create a created</summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static Birthdate From(DateTimeOffset dateTimeOffset)
            => new(new PastOrPresentTimestamp(dateTimeOffset));

        private Birthdate(PastOrPresentTimestamp rawBirthdate) : base(rawBirthdate) { }
    }
}
