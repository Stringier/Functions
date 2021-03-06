﻿using Microsoft.CodeAnalysis.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace System.Traits.Testing {
	/// <summary>
	/// Provides extensions for testing Roslyn Analyzers.
	/// </summary>
	public static class AnalyzerExtensions {
		/// <summary>
		/// Prepares the <paramref name="file"/> to make assertions against it.
		/// </summary>
		/// <typeparam name="TAnalyzer">The type of the analyzer to make assertions against.</typeparam>
		/// <param name="_">This <see cref="Assert"/>.</param>
		/// <param name="file">The filename containing the source to make assertions against.</param>
		/// <returns>An <see cref="AnalyzerAssert{TAnalyzer}"/> instance.</returns>
		[CLSCompliant(false)]
		public static AnalyzerAssert<TAnalyzer> That<TAnalyzer>(this Assert _, [DisallowNull] String file) where TAnalyzer : DiagnosticAnalyzer, new() => new AnalyzerAssert<TAnalyzer>(file);

		/// <summary>
		/// Sets the default path to the source files.
		/// </summary>
		/// <param name="_">This <see cref="Config"/>.</param>
		/// <param name="path">The path to the source files.</param>
		public static void SetPath(this Config _, [DisallowNull] String path) => State.Path = path;
	}
}
