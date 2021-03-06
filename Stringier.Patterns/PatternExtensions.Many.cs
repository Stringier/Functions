﻿using System;
using System.Diagnostics.CodeAnalysis;
#if NETCOREAPP3_0_OR_GREATER
using System.Text;
#endif

namespace Stringier.Patterns {
	public static partial class PatternExtensions {
		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <param name="char">The char literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which spans, repeating as many times as necessary until it doesn't match anymore.</returns>
		[return: NotNull]
		public static Pattern Many(this Char @char) => new CharLiteral(@char).Many();

#if NETCOREAPP3_0_OR_GREATER
		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <param name="rune">The rune literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which spans, repeating as many times as necessary until it doesn't match anymore.</returns>
		[return: NotNull]
		public static Pattern Many(this Rune rune) => new RuneLiteral(rune).Many();
#endif

		/// <summary>
		/// Marks this <see cref="Pattern"/> as spanning.
		/// </summary>
		/// <param name="string">The string literal pattern.</param>
		/// <returns>A new <see cref="Pattern"/> which spans, repeating as many times as necessary until it doesn't match anymore.</returns>
		[return: NotNull]
		public static Pattern Many([DisallowNull] this String @string) => new MemoryLiteral(@string).Many();
	}
}
