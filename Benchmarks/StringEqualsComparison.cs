﻿using System;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmarks {
	[ClrJob, CoreJob, CoreRtJob]
	[MemoryDiagnoser]
	public class StringEqualsComparison {
		
		[Params("Hello")]
		public String A { get; set; }

		[Params("Hello", "World", "Goodbye")]
		public String B { get; set; }

		[Benchmark(Baseline = true)]
		public Boolean NETEquals() => String.Equals(A, B);

		[Benchmark]
		public Boolean CompareToEquals() {
			return A.CompareTo(B) == 0;
		}

		[Benchmark]
		public Boolean ForeachEquals() {
			if (A.Length != B.Length) { return false; }
			for (Int32 i = 0; i < A.Length; i++) {
				if (A[i] != B[i])
					return false;
			}
			return true;
		}

		[Benchmark]
		public unsafe Boolean UnsafeForeachEquals() {
			String A = "Hello";
			String B = "Hello";
			if (A.Length != B.Length) { return false; }
			fixed (Char* a = A) {
				fixed (Char* b = B) {
					for (Int32 i = 0; i < A.Length; i++) {
						if (a[i] != b[i]) {
							return false;
						}
					}
				}
			}
			return true;
		}

		[Benchmark]
		public Boolean HashBeforeEquals() => A.GetHashCode() == B.GetHashCode() ? String.Equals(A, B) : false;

		[Benchmark]
		public Boolean FirstCharBeforeEquals() => A[0] == B[0] ? String.Equals(A, B) : false;

		[Benchmark]
		public Boolean ParallelForEquals() {
			Boolean Result = true;
			Parallel.For(0, 5, (i) => Result &= A[i] == B[i]);
			return Result;
		}

	}
}