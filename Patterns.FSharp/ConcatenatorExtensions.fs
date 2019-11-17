﻿namespace Stringier.Patterns

open System
open Stringier.Patterns.Bindings

[<AutoOpen>]
module ConcatenatorExtensions =

    type Binding =
        static member Concatenate(left:Pattern, right:Pattern) = PatternBindings.Concatenator(left, right)
        static member Concatenate(left:String, right:Pattern) = PatternBindings.Concatenator(p left, right)
        static member Concatenate(left:Pattern, right:String) = PatternBindings.Concatenator(left, p right)
        static member Concatenate(left:Char, right:Pattern) = PatternBindings.Concatenator(p left, right)
        static member Concatenate(left:Pattern, right:Char) = PatternBindings.Concatenator(left, p right)
        static member Concatenate(left:String, right:String) = PatternBindings.Concatenator(p left, p right)
        static member Concatenate(left:String, right:Char) = PatternBindings.Concatenator(p left, p right)
        static member Concatenate(left:Char, right:String) = PatternBindings.Concatenator(p left, p right)
        static member Concatenate(left:Char, right:Char) = PatternBindings.Concatenator(p left, p right)
        static member Concatenate(left:Pattern, right:Capture ref) = PatternBindings.Concatenator(left, p right)
        static member Concatenate(left:Capture ref, right:Pattern) = PatternBindings.Concatenator(p left, right)
        static member Concatenate(left:String, right:Capture ref) = PatternBindings.Concatenator(p left, p right)
        static member Concatenate(left:Capture ref, right:String) = PatternBindings.Concatenator(p left, p right)
        static member Concatenate(left:Char, right:Capture ref) = PatternBindings.Concatenator(p left, p right)
        static member Concatenate(left:Capture ref, right:Char) = PatternBindings.Concatenator(p left, p right)
        // This makes >> still do foreward composition
        static member Concatenate(left, right) = left >> right

    let inline private concatenate< ^t, ^a, ^b, ^c when (^t or ^a) : (static member Concatenate : ^a * ^b -> ^c)> left right = ((^t or ^a) : (static member Concatenate : ^a * ^b -> ^c)(left, right))

    let inline ( >> ) left right = concatenate<Binding, _, _, _> left right