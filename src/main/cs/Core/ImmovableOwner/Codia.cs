namespace RI.Novus.Core.ImmovableOwner
{
    /// <summary>
    /// Represents a InmovableOwner's Codia.
    /// </summary>
    public sealed class Codia : AbstractPositiveIntegerPrimitive
    {

        /// <summary>Creates a new instance checking parameter for <see langword="null"/>.</summary>
        /// <param name="rawCodia"></param>
        /// <returns></returns>
        public Codia(PositiveInteger rawCodia) : base(rawCodia)
        {

        }

        /// <summary>Creates a new instance from the given integer.</summary>
        /// <param name="rawAge">Must be greater than or equals to one: &gt;= 1</param>
        /// <returns></returns>
        public static Codia From(int rawAge) => new(new PositiveInteger(rawAge));
    }
}
