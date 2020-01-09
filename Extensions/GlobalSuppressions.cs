﻿using System.Diagnostics.CodeAnalysis;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: SuppressMessage("Design", "MA0048:File name must match type name", Justification = "When certain classes grow beyond a certain size, it's beneficial to split them up. This is why partial classes exist.")]
[assembly: SuppressMessage("Security", "MA0023:Add RegexOptions.ExplicitCapture", Justification = "There's no capturing even happening. Why do you think there is here?")]