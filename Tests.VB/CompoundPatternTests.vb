Imports System.Text.Patterns
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class CompoundPatternTests
	<TestMethod>
	Sub Identifier()
		Dim Identifier = Pattern.Letter And +(Pattern.Letter Or Pattern.DecimalDigitNumber Or "_")
		ResultAssert.Captures("hello", Identifier.Consume("hello"))
		ResultAssert.Captures("example_name", Identifier.Consume("example_name"))
		ResultAssert.Fails(Identifier.Consume("_fail"))
	End Sub

	<TestMethod>
	Sub IPv4Address()
		Dim Digit = (-((CType("1", Pattern) Or "2") And Pattern.DecimalDigitNumber) Or Pattern.DecimalDigitNumber) And -Pattern.DecimalDigitNumber
		Dim Address = Digit And "." And Digit And "." And Digit And "." And Digit
		Dim Result = Address.Consume("192.168.1.1")
		ResultAssert.Captures("192.168.1.1", Result)
	End Sub

	<TestMethod>
	Sub PhoneNumber()
		Dim Number = Pattern.Number * 3 And "-" And Pattern.Number * 3 And "-" And Pattern.Number * 4
		Dim Result = Number.Consume("555-555-5555")
		ResultAssert.Captures("555-555-5555", Result)
	End Sub

	<TestMethod>
	Sub WebAddress()
		Dim Protocol = "http" And -CType("s", Pattern) And "://"
		Dim Host = +(Pattern.Letter Or Pattern.Number Or "-") And "." And -(+(Pattern.Letter Or Pattern.Number Or "-") And ".") And Pattern.Letter * 3
		Dim Location = +("/" And +(Pattern.Letter Or Pattern.Number Or "-" Or "_"))
		Dim Address = -Protocol And Host And -Location
		Dim Result = Address.Consume("www.google.com")
		ResultAssert.Captures("www.google.com", Result)
		Result = Address.Consume("http://www.google.com")
		ResultAssert.Captures("http://www.google.com", Result)
		Result = Address.Consume("https://www.google.com/about")
		ResultAssert.Captures("https://www.google.com/about", Result)
	End Sub
End Class
