﻿using RI.Novus.Core.ImmovableProperties;

namespace RI.Novus.Core.Facts.ImmovableProperty.ImmovablePropertyFacts.SurfaceFacts;

[TestFixture]
internal sealed class FromMessage
{

    private static readonly decimal[] ValidAmounts = {
        0.01M,
        49_999.51M,
        99_999
    };

    [Test]
    public void With_Valid_Values_Throws_Nothing([ValueSource(nameof(ValidAmounts))] decimal rawSurface)
        => Assert.That(() => Surface.From(rawSurface), Throws.Nothing);

    [TestCase(-0.01)]
    [TestCase(0)]
    public void With_Below_Minimum_Throws_ArgumentOutOfRangeException(decimal rawSurface)
        => Assert.That(() => Surface.From(rawSurface), Throws.InstanceOf<ArgumentOutOfRangeException>());

    [TestCase(99_999.01)]
    [TestCase(100_000)]
    public void With_Above_Maximum_Throws_ArgumentOutOfRangeException(decimal rawSurface)
        => Assert.That(() => Surface.From(rawSurface), Throws.InstanceOf<ArgumentOutOfRangeException>());
}
