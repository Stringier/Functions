﻿using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Patterns {
	/// <summary>
	/// Represents the optor pattern
	/// </summary>
	internal sealed class Optor : Node, IModifier, IEquatable<Optor> {
		private readonly INode Pattern;

		internal Optor(INode Pattern) => this.Pattern = Pattern;

		internal Optor(Pattern Pattern) : this(Pattern.Head) { }

		/// <summary>
		/// Attempt to consume the <see cref="Pattern"/> from the <paramref name="Source"/>, adjusting the position in the <paramref name="Source"/> as appropriate
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the captured string</returns>
		public override Result Consume(ref Source Source) {
			Result Result = Pattern.Consume(ref Source);
			Result.Success = true; //Consuming an optional pattern is always considered successful, the only thing that changes is what is captured
			return Result;
		}

		public override Boolean Equals(Object obj) {
			switch (obj) {
			case Optor Other:
				return Equals(Other);
			case String Other:
				return Equals(Other);
			default:
				return false;
			}
		}

		public override Boolean Equals(String other) => Pattern.Equals(other);

		public Boolean Equals(Optor other) => Pattern.Equals(other.Pattern);

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override Int32 GetHashCode() => ~Pattern.GetHashCode();

		/// <summary>
		/// Attempt to consume from the <paramref name="Source"/> while neglecting this <see cref="Pattern"/>
		/// </summary>
		/// <param name="Source">The <see cref="Source"/> to consume</param>
		/// <returns>A <see cref="Result"/> containing whether a match occured and the consumed string</returns>
		public override Result Neglect(ref Source Source) {
			Result Result = Pattern.Neglect(ref Source);
			Result.Success = true; //Consuming an optional pattern is always considered successful, the only thing that changes is what is captured
			return Result;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => $"~{Pattern}";
	}
}
