﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Traits;

namespace Stringier.Patterns {
	/// <summary>
	/// Represents a <see cref="Ranger"/>, a "range" of text between two <see cref="Pattern"/>.
	/// </summary>
	internal class Ranger : Combinator {
		/// <summary>
		/// The <see cref="Pattern"/> to start from.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly Pattern From;

		/// <summary>
		/// The <see cref="Pattern"/> to read to.
		/// </summary>
		[DisallowNull, NotNull]
		protected readonly Pattern To;

		/// <summary>
		/// Initialize a new <see cref="Ranger"/> with the given <paramref name="from"/> and <paramref name="to"/> nodes.
		/// </summary>
		/// <param name="from">The <see cref="Pattern"/> to start from.</param>
		/// <param name="to">The <see cref="Pattern"/> to read to.</param>
		internal protected Ranger([DisallowNull] Pattern from, [DisallowNull] Pattern to) {
			From = from;
			To = to;
		}

		/// <inheritdoc/>
		[return: NotNull]
		public override Pattern Not() => throw new InvalidOperationException("Ranges can not be negated, as there is no valid concept to describe this behavior");

		/// <inheritdoc/>
		protected internal override void Consume(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Consume([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Consume(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override void Neglect(ReadOnlyMemory<Char> source, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(source.Span, ref location, out exception, trace);

		/// <inheritdoc/>
		protected internal override unsafe void Neglect([DisallowNull] Char* source, Int32 length, ref Int32 location, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => Neglect(new ReadOnlySpan<Char>(source, length), ref location, out exception, trace);

		private void Consume(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();

		private void Neglect(ReadOnlySpan<Char> source, ref Int32 length, [AllowNull, MaybeNull] out Exception exception, [AllowNull] IAdd<Capture> trace) => throw new NotImplementedException();
	}
}
