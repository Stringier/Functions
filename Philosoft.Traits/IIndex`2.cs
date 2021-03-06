﻿namespace System.Traits {
	/// <summary>
	/// Indicates the type is indexable, read and write.
	/// </summary>
	/// <typeparam name="TIndex">The type used to index the collection.</typeparam>
	/// <typeparam name="TElement">The type of the elements in the collection.</typeparam>
	public interface IIndex<in TIndex, TElement> : IIndexReadOnly<TIndex, TElement> where TIndex : notnull {
		/// <summary>
		/// Gets  the element at the specified index.
		/// </summary>
		/// <param name="index">The index of the element to get.</param>
		/// <returns>The element at the specified index.</returns>
		new TElement this[TIndex index] { get; set; }

#if !NETSTANDARD1_3
		/// <inheritdoc/>
		TElement IIndexReadOnly<TIndex, TElement>.this[TIndex index] => this[index];
#endif
	}
}
