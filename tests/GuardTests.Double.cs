﻿namespace Dawn.Tests
{
    using System;
    using Xunit;

    public sealed partial class GuardTests
    {
        [Fact(DisplayName = T + "Guard supports doubles.")]
        public void GuardSupportsDoubles()
        {
            // "Not a number".
            var nan = double.NaN;
            var nanArg = Guard.Argument(() => nan);
            nanArg.NaN();

            var zero = 0d;
            var zeroArg = Guard.Argument(() => zero);
            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).NaN());

            var message = RandomMessage;
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).NaN(f =>
                {
                    Assert.Equal(zero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(zero), () => Guard.Argument(() => zero).Modify(zero).NaN());

            // Nullable "not a number".
            var @null = null as double?;
            var nullArg = Guard.Argument(() => @null);
            nullArg.NaN();

            var nullableNaN = nan as double?;
            var nullableNaNArg = Guard.Argument(() => nullableNaN);
            nullableNaNArg.NaN();

            var nullableZero = zero as double?;
            var nullableZeroArg = Guard.Argument(() => nullableZero);
            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).NaN());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).NaN(f =>
                {
                    Assert.Equal(nullableZero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).Modify(nullableZero).NaN());

            // Not "not a number".
            zeroArg.NotNaN();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).NotNaN());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).NotNaN(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nan), () => Guard.Argument(() => nan).Modify(nan).NotNaN());

            // Nullable not "not a number".
            nullArg.NotNaN();
            nullableZeroArg.NotNaN();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).NotNaN());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).NotNaN(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).Modify(nullableNaN).NotNaN());

            // Infinity.
            var negInfinity = double.NegativeInfinity;
            var negInfinityArg = Guard.Argument(() => negInfinity);
            negInfinityArg.Infinity();

            var posInfinity = double.PositiveInfinity;
            var posInfinityArg = Guard.Argument(() => posInfinity);
            posInfinityArg.Infinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).Infinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).Infinity(f =>
                {
                    Assert.Equal(nan, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nan), () => Guard.Argument(() => nan).Modify(nan).Infinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).Infinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).Infinity(f =>
                {
                    Assert.Equal(zero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(zero), () => Guard.Argument(() => zero).Modify(zero).Infinity());

            // Nullable infinity.
            nullArg.Infinity();

            var nullableNegInfinity = negInfinity as double?;
            var nullableNegInfinityArg = Guard.Argument(() => nullableNegInfinity);
            nullableNegInfinityArg.Infinity();

            var nullablePosInfinity = posInfinity as double?;
            var nullablePosInfinityArg = Guard.Argument(() => nullablePosInfinity);
            nullablePosInfinityArg.Infinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).Infinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).Infinity(f =>
                {
                    Assert.Equal(nullableNaN, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).Modify(nullableNaN).Infinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).Infinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).Infinity(f =>
                {
                    Assert.Equal(nullableZero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).Modify(nullableZero).Infinity());

            // Not infinity.
            nanArg.NotInfinity();
            zeroArg.NotInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).NotInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).NotInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).Modify(posInfinity).NotInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).NotInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).NotInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).Modify(negInfinity).NotInfinity());

            // Nullable not infinity.
            nullArg.NotInfinity();

            nullableNaNArg.NotInfinity();
            nullableZeroArg.NotInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).NotInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).NotInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).Modify(nullablePosInfinity).NotInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).NotInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).NotInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).Modify(nullableNegInfinity).NotInfinity());

            // Positive infinity.
            posInfinityArg.PositiveInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).PositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).PositiveInfinity(f =>
                {
                    Assert.Equal(nan, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nan), () => Guard.Argument(() => nan).Modify(nan).PositiveInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).PositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).PositiveInfinity(f =>
                {
                    Assert.Equal(negInfinity, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).Modify(negInfinity).PositiveInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).PositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).PositiveInfinity(f =>
                {
                    Assert.Equal(zero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(zero), () => Guard.Argument(() => zero).Modify(zero).PositiveInfinity());

            // Nullable positive infinity.
            nullArg.PositiveInfinity();

            nullablePosInfinityArg.PositiveInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).PositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).PositiveInfinity(f =>
                {
                    Assert.Equal(nullableNaN, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).Modify(nullableNaN).PositiveInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).PositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).PositiveInfinity(f =>
                {
                    Assert.Equal(nullableNegInfinity, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).Modify(nullableNegInfinity).PositiveInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).PositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).PositiveInfinity(f =>
                {
                    Assert.Equal(nullableZero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).Modify(nullableZero).PositiveInfinity());

            // Not positive infinity.
            nanArg.NotPositiveInfinity();
            negInfinityArg.NotPositiveInfinity();
            zeroArg.NotPositiveInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).NotPositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).NotPositiveInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).Modify(posInfinity).NotPositiveInfinity());

            // Nullable not positive infinity.
            nullArg.NotPositiveInfinity();

            nullableNaNArg.NotPositiveInfinity();
            nullableNegInfinityArg.NotPositiveInfinity();
            nullableZeroArg.NotPositiveInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).NotPositiveInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).NotPositiveInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).Modify(nullablePosInfinity).NotPositiveInfinity());

            // Negative infinity.
            negInfinityArg.NegativeInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).NegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nan), () => Guard.Argument(() => nan).NegativeInfinity(f =>
                {
                    Assert.Equal(nan, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nan), () => Guard.Argument(() => nan).Modify(nan).NegativeInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).NegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).NegativeInfinity(f =>
                {
                    Assert.Equal(posInfinity, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(posInfinity), () => Guard.Argument(() => posInfinity).Modify(posInfinity).NegativeInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).NegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(zero), () => Guard.Argument(() => zero).NegativeInfinity(f =>
                {
                    Assert.Equal(zero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(zero), () => Guard.Argument(() => zero).Modify(zero).NegativeInfinity());

            // Nullable negative infinity.
            nullArg.NegativeInfinity();

            nullableNegInfinityArg.NegativeInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).NegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).NegativeInfinity(f =>
                {
                    Assert.Equal(nullableNaN, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableNaN), () => Guard.Argument(() => nullableNaN).Modify(nullableNaN).NegativeInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).NegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).NegativeInfinity(f =>
                {
                    Assert.Equal(nullablePosInfinity, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullablePosInfinity), () => Guard.Argument(() => nullablePosInfinity).Modify(nullablePosInfinity).NegativeInfinity());

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).NegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).NegativeInfinity(f =>
                {
                    Assert.Equal(nullableZero, f);
                    return message;
                }));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableZero), () => Guard.Argument(() => nullableZero).Modify(nullableZero).NegativeInfinity());

            // Not negative infinity.
            nanArg.NotNegativeInfinity();
            posInfinityArg.NotNegativeInfinity();
            zeroArg.NotNegativeInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).NotNegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).NotNegativeInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(negInfinity), () => Guard.Argument(() => negInfinity).Modify(negInfinity).NotNegativeInfinity());

            // Nullable not negative infinity.
            nullArg.NotNegativeInfinity();

            nullableNaNArg.NotNegativeInfinity();
            nullablePosInfinityArg.NotNegativeInfinity();
            nullableZeroArg.NotNegativeInfinity();

            Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).NotNegativeInfinity());

            message = RandomMessage;
            ex = Assert.Throws<ArgumentOutOfRangeException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).NotNegativeInfinity(message));

            Assert.StartsWith(message, ex.Message);

            Assert.Throws<ArgumentException>(
                nameof(nullableNegInfinity), () => Guard.Argument(() => nullableNegInfinity).Modify(nullableNegInfinity).NotNegativeInfinity());
        }
    }
}