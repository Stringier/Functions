﻿namespace System.Text.Patterns {
	/// <summary>
	/// Represents a named capture component
	/// </summary>
	/// <remarks>
	/// This is used primarily in the implementation of backreferences (which are like in [Regex](https://www.regular-expressions.info/backref.html)).
	/// </remarks>
	public sealed class Capture : IEquatable<String> {
		//! No matter how good of an idea it might seem like, do not add an implicit conversion to String inside this class. Resolution of conversions causes String to be favored over Pattern, in which case StringLiteral's will be formed over CaptureLiteral's, which causes lazy resolution to no longer be done, breaking a bunch of shit

		internal String Value;

		internal Capture() => Value = "";

		public static Boolean operator ==(Capture Left, String Right) {
			if (Left is null || Right is null) {
				return false;
			}
			return Left.Equals(Right);
		}

		public static Boolean operator ==(String Left, Capture Right) {
			if (Left is null || Right is null) {
				return false;
			}
			return Right.Equals(Left);
		}

		public static Boolean operator !=(Capture Left, String Right) {
			if (Left is null || Right is null) {
				return false;
			}
			return !Left.Equals(Right);
		}

		public static Boolean operator !=(String Left, Capture Right) {
			if (Left is null || Right is null) {
				return false;
			}
			return !Right.Equals(Left);
		}

		public Boolean Equals(String other) {
			if (other is null) {
				return false;
			}
			return Stringier.Equals(Value, other, true);
		}

		/// <summary>
		/// Converts the value of this instance to a <see cref="String"/>.
		/// </summary>
		/// <returns>Returns the captured <see cref="String"/></returns>
		public override String ToString() => $"{Value}";
	}
}