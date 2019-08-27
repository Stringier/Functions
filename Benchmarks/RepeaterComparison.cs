﻿using System;
using System.Text.Patterns;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	public class RepeaterComparison {

		Pattern Repeater = (Pattern)"Hi!" * 2;

		Regex Regex = new Regex("^(Hi!){2}");

		[Params("Hi!Hi!", "Hi!Hi!Hi!", "Hi!")]
		public String Source { get; set; }

		[Benchmark]
		public Result RepeaterConsume() => Repeater.Consume(Source);

		[Benchmark(Baseline = true)]
		public Match RegexMatch() => Regex.Match(Source);

	}
}
