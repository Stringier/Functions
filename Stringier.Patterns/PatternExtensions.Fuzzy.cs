﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	public partial class PatternExtensions {
		/// <summary>
		/// Marks this <see cref="String"/> as fuzzy.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to fuzzy match.</param>
		/// <returns>A new <see cref="Pattern"/> which will fuzzy match the <paramref name="string"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("string")]
		public static Pattern Fuzzy([AllowNull] this String @string) => Fuzzy(@string, 1, Case.Sensitive);

		/// <summary>
		/// Marks this <see cref="String"/> as fuzzy.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to fuzzy match.</param>
		/// <param name="maxEdits">The maximum allowed edits to still be considered a match.</param>
		/// <returns>A new <see cref="Pattern"/> which will fuzzy match the <paramref name="string"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("string")]
		public static Pattern Fuzzy([AllowNull] this String @string, Int32 maxEdits) => Fuzzy(@string, maxEdits, Case.Sensitive);

		/// <summary>
		/// Marks this <see cref="String"/> as fuzzy.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to fuzzy match.</param>
		/// <param name="casing">The <see cref="Case"/> of the comparison.</param>
		/// <returns>A new <see cref="Pattern"/> which will fuzzy match the <paramref name="string"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("string")]
		public static Pattern Fuzzy([AllowNull] this String @string, Case casing) => Fuzzy(@string, 1, casing);

		/// <summary>
		/// Marks this <see cref="String"/> as fuzzy.
		/// </summary>
		/// <param name="string">The <see cref="String"/> to fuzzy match.</param>
		/// <param name="maxEdits">The maximum allowed edits to still be considered a match.</param>
		/// <param name="casing">The <see cref="Case"/> of the comparison.</param>
		/// <returns>A new <see cref="Pattern"/> which will fuzzy match the <paramref name="string"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("string")]
		public static Pattern Fuzzy([AllowNull] this String @string, Int32 maxEdits, Case casing) => @string is not null ? new Fuzzer(@string, maxEdits, casing) : null;

	}
}
