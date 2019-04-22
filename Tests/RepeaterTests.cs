﻿using System;
using System.Text.Patterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
	[TestClass]
	public class RepeaterTests {
		[TestMethod]
		public void Constructor() {
			Repeater _ = (Literal)"Hi! " * 2;
		}

		[TestMethod]
		public void Consume() {
			Repeater Repeater = (Literal)"Hi! " * 2;
			Assert.AreEqual("Hi!", Repeater.Consume("Hi! Hi! Hi!"));
			Pattern Pattern = (((Literal)"Hi" | "Bye") & "! ") * 2;
			Assert.AreEqual("Hi!", Pattern.Consume("Hi! Bye! Hi!"));
		}
	}
}
