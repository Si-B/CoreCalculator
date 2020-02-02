# CoreCalculator

A lightweight .NET Core webservice which offers a simple calculator operation.

<strong>Available operations</strong>

There is one endpoint named <strong>calculus</strong> available which awaits the parameter <strong>query</strong> like <em>/calculus?query=MiAqICgyMy8oMyozKSktIDIzICogKDIqMyk=</em>

Please notice that the value for the parameter <strong>query</strong> has to be Base64 encoded.

With the current implementation the webservice allows you to use following mathematical operators:

- Addition with operator +
- Substraction with operator -
- Multiplication with operator *
- Divide with operator /
- You can also use parenthesis to group terms

<strong>Returnvalues</strong>

All operation results are in JSON.

<strong>Calculation was succesful</strong>

- Example input: 5*5+(8*8) as NSo1Kyg4Kjgp

  Result: {
    "error": false,
    "result": 89
  }

<strong>Fail</strong>

- Example input: 33-78)+34 as MzMtNzgpKzM0

  Result: {
      "error": true,
      "message": "Query parameter contains an parenthensis error. Provided value was: 33-78)+34"
  }

- Example input: 33t-34 as MzN0LTM0

  Result: {
      "error": true,
      "message": "Query parameter contains invalid characters. Allowed characters are digits, +, -, *, / and whitespace. Provided value was: 33t-34"
  }

- Example input: HDLKSA(W (invalid Base64)

  Result: {
      "error": true,
      "message": "Query parameter was not Base64 encoded or invalid. Provided value was: HDLKSA(W"
  }

<strong>Implementation</strong>

I am using ASP .NET Core because it is the current and more lighweight approach to create a webservice in C# then older version of Web Api and MVC.

<strong>Calculator</strong>

It uses an infix to postfix transformation followed by a postfix evaluation to calculate the given input. With the current implemenation it is necessary that the input string is valid. Valid in this case means it is only allowed to contain digits and the operators +, -, *, / and parenthesis. Therefore the InputHelper class was created to clean and check given input.

<strong>InputValidator</strong>

Offers several methods to either check given input for valid encoding or characters. It also is able to remove unwanted whitespace or prepare assumed Base64 input for correct encoding by adding paddings if needed.

<strong>Base64Handler</strong>

Simple class which offers methods to encode any string to Base64 or decode a Base64 string. There is no validation so an Exception is thrown when invalid Base64 input is entered. The current implementation of CoreCalculator makes sure input can be decoded.

<strong>Thoughts for future versions</strong>

- Add more operators like ^.
- Move validation calls from CalculusController.Get to InputValidator so only one call for validation is needed.
- Add a view to allow calls from a nice website as well including a resultpage.


