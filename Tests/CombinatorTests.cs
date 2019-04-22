﻿using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class CombinatorTests {
		[TestMethod]
		public void Constructor() {
			Combinator _ = ((Literal)"Hello" | "Goodbye") & " " & "world";
		}

		[TestMethod]
		public void Consume() {
			Combinator Combinator = ((Literal)"Hello" | "Goodbye") & " " & "world";
			ResultAssert.Remains("", Combinator.Consume("Hello world"));
			ResultAssert.Remains("", Combinator.Consume("Goodbye world"));
			ResultAssert.Remains("World", Combinator.Consume("Hello World")); // Remember, string comparisons are case sensitive, so "World" isn't a match
		}
	}
}
