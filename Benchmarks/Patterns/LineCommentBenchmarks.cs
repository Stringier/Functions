﻿using System;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using PCRE;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;
using Stringier.Patterns;
using static Stringier.Patterns.Pattern;

namespace Benchmarks.Patterns {
	[SimpleJob(RuntimeMoniker.Net48)]
	[SimpleJob(RuntimeMoniker.NetCoreApp30)]
	[SimpleJob(RuntimeMoniker.CoreRt30)]
	[SimpleJob(RuntimeMoniker.Mono)]
	[MemoryDiagnoser]
	public class LineCommentBenchmarks {
		readonly Regex msregex = new Regex("^--(?:[^\u000D][^\u000A]|[^\u000A][^\u000D]|[^\u000A]|[^\u000B]|[^\u000C]|[^\u000D]|[^\u0085]|[^\u2028]|[^\u2029])+", RegexOptions.IgnoreCase | RegexOptions.Singleline);

		readonly PcreRegex pcreregex = new PcreRegex("^--(?:[^\u000D][^\u000A]|[^\u000A][^\u000D]|[^\u000A]|[^\u000B]|[^\u000C]|[^\u000D]|[^\u0085]|[^\u2028]|[^\u2029])+", PcreOptions.IgnoreCase);

		readonly Parser<Char, String> pidgin = Map((start, end) => start + end, String("--"), Not(OneOf(String("\u000D\u000A"), String("\u000A\u000D"))));

		readonly Pattern stringier = "--".Then(Many(Not(LineTerminator)));

		[Params("--Comment\u2028")] //NEL is chosen instead of other line terminators because it's very unlikely that any system actually handles it, despite it literally being for this exact purpose.
		public String Source { get; set; }

		[Benchmark]
		public Match MSRegex() => msregex.Match(Source);

		[Benchmark]
		public PcreMatch PcreRegex() => pcreregex.Match(Source);

		[Benchmark]
		public Result<Char, String> Pidgin() => pidgin.Parse(Source);

		[Benchmark]
		public Result Stringier() => stringier.Consume(Source);
	}
}
