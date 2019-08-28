﻿namespace System.Text.Patterns {
	[Serializable]
	public sealed class PatternConstructionException : PatternException {
		public PatternConstructionException() { }
		public PatternConstructionException(String message) : base(message) { }
		public PatternConstructionException(String message, Exception inner) : base(message, inner) { }
		public PatternConstructionException(
		  Runtime.Serialization.SerializationInfo info,
		  Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
