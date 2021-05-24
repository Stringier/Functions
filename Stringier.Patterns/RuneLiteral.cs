﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a rune literal, a pattern matching this exact rune.
	/// </summary>
	/// <remarks>
	/// This exists to box <see cref="System.Text.Rune"/> into something that we can treat as part of a pattern.
	/// </remarks>
	internal sealed class RuneLiteral : Literal {
		/// <summary>
		/// The <see cref="System.Text.Rune"/> being matched.
		/// </summary>
		internal readonly Rune Rune;

		/// <summary>
		/// Initialize a new <see cref="RuneLiteral"/> with the given <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune"></param>
		internal RuneLiteral(Rune rune) : this(rune, default) { }

		/// <summary>
		/// Initialize a new <see cref="RuneLiteral"/> with the given <paramref name="rune"/>.
		/// </summary>
		/// <param name="rune">The <see cref="System.Text.Rune"/> to parse.</param>
		/// <param name="casing">The <see cref="Case"/> to use when parsing.</param>
		internal RuneLiteral(Rune rune, Case casing) : base(casing) => Rune = rune;

		/// <inheritdoc/>
		[return: NotNull]
		public override String ToString() => Rune.ToString();

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		private void Consume(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 length = Rune.Utf16SequenceLength;
			if (location + length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (Text.Equals(Rune, source.Slice(location, length), Casing)) {
				trace?.Add(source.Slice(location, length), location);
				location += length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}

		private void Neglect(ReadOnlySpan<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) {
			Int32 length = Rune.Utf16SequenceLength;
			if (location + length > source.Length) {
				exception = AtEnd;
				trace?.Add(exception, location);
			} else if (!Text.Equals(Rune, source.Slice(location, length), Casing)) {
				trace?.Add(source.Slice(location, length), location);
				location += length;
				exception = null;
			} else {
				exception = NoMatch;
				trace?.Add(exception, location);
			}
		}
	}
}
