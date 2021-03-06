﻿using System.Diagnostics.CodeAnalysis;

namespace Stringier.Patterns {
	public partial class Pattern {
		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which matches the negation of <paramref name="pattern"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static Pattern operator !([AllowNull] Pattern pattern) => pattern?.Not();

		/// <summary>
		/// Marks this <see cref="Pattern"/> as negated.
		/// </summary>
		/// <returns>A new <see cref="Pattern"/> which matches the negation of this <see cref="Pattern"/>.</returns>
		[return: NotNull]
		public virtual Pattern Not() => new Negator(this);

		/// <summary>
		/// Marks the <paramref name="pattern"/> as negated.
		/// </summary>
		/// <param name="pattern">The <see cref="Pattern"/> to negate.</param>
		/// <returns>A new <see cref="Pattern"/> which matches the negation of the <paramref name="pattern"/>.</returns>
		[return: MaybeNull, NotNullIfNotNull("pattern")]
		public static Pattern Not([AllowNull] Pattern pattern) => pattern?.Not();
	}
}
