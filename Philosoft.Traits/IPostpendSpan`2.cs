﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits {
	/// <summary>
	/// Indicates the type can have other elements postpended onto it, with additional span operations.
	/// </summary>
	/// <typeparam name="TElement">The type of the elements.</typeparam>
	/// <typeparam name="TResult">The resulting type; often itself.</typeparam>
	public interface IPostpendSpan<TElement, out TResult> : IPostpend<TElement, TResult> where TResult : IPostpendSpan<TElement, TResult> {
		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IPostpend<TElement, TResult>.Postpend(Memory<TElement> elements) => Postpend(elements.Span);

		/// <inheritdoc/>
		[return: MaybeNull]
		TResult IPostpend<TElement, TResult>.Postpend(ReadOnlyMemory<TElement> elements) => Postpend(elements.Span);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(Span<TElement> elements) => Postpend((ReadOnlySpan<TElement>)elements);

		/// <summary>
		/// Postpends the elements onto this object.
		/// </summary>
		/// <param name="elements">The elements to postpend.</param>
		/// <returns>If the postpend occurred successfully, returns a <typeparamref name="TResult"/> containing the original and postpended elements; otherwise, <see langword="null"/>.</returns>
		[return: MaybeNull]
		TResult Postpend(ReadOnlySpan<TElement> elements) {
			TResult? result = (TResult)this;
			for (Int32 i = elements.Length - 1; i >= 0; i--) {
				if ((result = result!.Postpend(elements[i])) is null) { return default; }
			}
			return result;
		}
	}
}