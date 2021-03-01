﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Langly {
	public static partial class NumericExtensions {
		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<nint, TEnumerator> values) where TEnumerator : IEnumerator<nint> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<nuint, TEnumerator> values) where TEnumerator : IEnumerator<nuint> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Byte, TEnumerator> values) where TEnumerator : IEnumerator<Byte> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<SByte, TEnumerator> values) where TEnumerator : IEnumerator<SByte> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Int16, TEnumerator> values) where TEnumerator : IEnumerator<Int16> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<UInt16, TEnumerator> values) where TEnumerator : IEnumerator<UInt16> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Int32, TEnumerator> values) where TEnumerator : IEnumerator<Int32> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<UInt32, TEnumerator> values) where TEnumerator : IEnumerator<UInt32> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Int64, TEnumerator> values) where TEnumerator : IEnumerator<Int64> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		[CLSCompliant(false)]
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<UInt64, TEnumerator> values) where TEnumerator : IEnumerator<UInt64> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Single, TEnumerator> values) where TEnumerator : IEnumerator<Single> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Double GeometricMean<TEnumerator>([AllowNull] this ISequence<Double, TEnumerator> values) where TEnumerator : IEnumerator<Double> => Math.Pow(values.Product(), 1.0 / (values?.Count ?? 0));

		/// <summary>
		/// Averages the <paramref name="values"/>.
		/// </summary>
		/// <typeparam name="TEnumerator">The type of the enumerator of the <paramref name="values"/>.</typeparam>
		/// <param name="values">The values to find the mean of.</param>
		/// <returns>The mean of the <paramref name="values"/>.</returns>
		public static Decimal GeometricMean<TEnumerator>([AllowNull] this ISequence<Decimal, TEnumerator> values) where TEnumerator : IEnumerator<Decimal> {
			Guard.NotNull(values, nameof(values));
			Guard.NotEmpty(values, nameof(values));
			throw new NotImplementedException("Microsoft doesn't think there's a valid reason to exponentiate decimals despite this exact function being used to calculate numerous financial indicies, and other financial applications. Someone has to implement a replacement Pow() function");
		}
	}
}
