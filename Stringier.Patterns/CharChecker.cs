﻿namespace System.Text.Patterns {
	/// <summary>
	/// This is an internal pattern used to programatically check a <see cref="Char"/> for existance within a set.
	/// </summary>
	/// <remarks>
	/// Specifically, it's used in the construction of predefined patterns. This is because it's considerably easier to define a range of codepoints and check for the existance within that. The code to do this is clunky and awkward however, so not something to expose publicly.
	/// Testing: While it might seem like testing this class is somehow not possible because of the visibility, this isn't the case at all. <see cref="CharChecker"/> is exposed, non-obviously, through the predefined patterns, and can easily be checked that way; if those fail while the isolated tests pass, the issue is almost certainly with this class.
	/// </remarks>
	internal sealed class CharChecker : Checker, IEquatable<CharChecker> {
		internal new readonly Func<Char, Boolean> Check;

		/// <summary>
		/// Construct a new <see cref="CharChecker"/> from the specified <paramref name="Check"/>
		/// </summary>
		/// <param name="Name">The name to refer to this as</param>
		/// <param name="Check">A <see cref="Func{T, TResult}"/> taking a <see cref="Char"/> and returning a <see cref="Boolean"/></param>
		internal CharChecker(String Name, Func<Char, Boolean> Check) : base(Name) => this.Check = Check;

		internal override Boolean CheckHeader(ref Source Source) => Source.EOF ? false : Check(Source.Peek());

		internal override void Consume(ref Source Source, ref Result Result) {
			if (Source.Length == 0) {
				Result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				if (Check(Source.Peek())) {
					Source.Position++;
					Result.Length++;
					Result.Error.Clear();
				} else {
					Result.Error.Set(ErrorType.ConsumeFailed, this);
				}
			}
		}

		internal override void Neglect(ref Source Source, ref Result Result) {
			if (Source.Length == 0) {
				Result.Error.Set(ErrorType.EndOfSource, this);
			} else {
				if (!Check(Source.Peek())) {
					Source.Position++;
					Result.Length++;
					Result.Error.Clear();
				} else {
					Result.Error.Set(ErrorType.NeglectFailed, this);
				}
			}
		}

		public override Boolean Equals(Object? obj) {
			switch (obj) {
			case CharChecker other:
				return Equals(other);
			case String other:
				return Equals(other);
			default:
				return false;
			}
		}

		public override Boolean Equals(ReadOnlySpan<Char> other) => other.Length != 1 ? false : Check(other[0]);

		public override Boolean Equals(String other) => other.Length != 1 ? false : Check(other[0]);

		public Boolean Equals(CharChecker other) => Check.Equals(other.Check);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => Check.GetHashCode();

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"┋{Name}┋";

		#region Alternator

		internal override Pattern Alternate(Pattern Right) {
			switch (Right) {
			case CharChecker right:
				return new AlternateCharChecker(Name, Check, right.Check);
			default:
				return base.Alternate(Right);
			}
		}

		#endregion

		#region Repeater

		internal override Pattern Repeat(Int32 Count) => new RepeatCharChecker(Name, Check, Count);

		#endregion
	}
}
