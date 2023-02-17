using System.ComponentModel;

namespace RI.Novus.Core.ImmovableProperties
{

    /// <summary>List of all the actions performed in application</summary>
    #pragma warning disable CA1008 // Enums should have zero value
    public enum ImmovablePropertyTypes
    #pragma warning restore CA1008 // Enums should have zero value
    {
        /// <summary>Defines a new property of Home</summary>
        [Description("Home property has been created")]
        Home = 1,

        /// <summary>Defines a new property of Business</summary>
        [Description("Business property has been created")]
        Business
    }
}
