using CoreCalculator.ServerDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCalculator.ServerImplementations
{
    /// <summary>
    /// A class that can calculate string input with valid characters (digits, +, -, * and /) and no whitespace.
    /// There is no validation for valid characters or whitespace so please make sure to provide valid input to get valid results.
    /// </summary>
    public class Calculator : ICalculator
    {
        /// <summary>
        /// Calculates given input by transforming it into postfix notation and evaluation.       
        /// </summary>
        /// <param name="input">A string that can be calculated. This means it has to only contain valid operators (digits, +, -, * or /) and no whitespace.</param>
        /// <returns>Calculationresult as double.</returns>
        public double Calculate(string input)
        {
            var inputAsPostFixResult = ToPostFix(input);
            var postfixEvaluationResult = EvaluatePostFix(inputAsPostFixResult);

            return postfixEvaluationResult;
        }
        /// <summary>
        /// Given input is being transformed from infix to postfix notation.
        /// To handle digits greater then 9 whitespace is added between every operand and operator.
        /// </summary>
        /// <param name="input">Any string will get transformed. There is no validation for valid characters.</param>
        /// <returns>A string that has been transformed into postifx notation with additionael whitespace as separator.</returns>
        public string ToPostFix(string input)
        {
            var postFixBuilder = new StringBuilder();
            var operators = new Stack<char>();
            var lastValueWasOperator = false;

            for (int i = 0; i < input.Length; i++)
            {
                var currentCharacter = input[i];

                if (char.IsDigit(currentCharacter))
                {
                    if (lastValueWasOperator)
                    {
                        postFixBuilder.Append(' ');
                        lastValueWasOperator = false;
                    }
                    postFixBuilder.Append(currentCharacter);
                    continue;
                }

                lastValueWasOperator = true;

                if (currentCharacter == '(') {
                    operators.Push(currentCharacter);
                }
                else if (currentCharacter == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        postFixBuilder.Append(' ');
                        postFixBuilder.Append(operators.Pop());
                    }
                    operators.Pop();
                }
                else
                {
                    if (operators.Count == 0 || operators.Contains('(') || GetPrecedence(currentCharacter) > GetPrecedence(operators.Peek())) {
                        operators.Push(currentCharacter);
                    }
                    else
                    {
                        while (operators.Count > 0 && GetPrecedence(currentCharacter) <= GetPrecedence(operators.Peek()) && operators.Peek() != '(' && operators.Peek() != ')')
                        {
                            postFixBuilder.Append(' ');
                            postFixBuilder.Append(operators.Pop());
                        }
                        operators.Push(currentCharacter);
                    }
                }
            }

            while (operators.Count > 0)
            {
                postFixBuilder.Append(' ');
                postFixBuilder.Append(operators.Pop());
            }

            return postFixBuilder.ToString();
        }

        /// <summary>
        /// Helper function to get the mathematical precedence of a given character.
        /// +, -, * and / are deteced currently.
        /// </summary>
        /// <param name="c">Any character.</param>
        /// <returns>1 for + and -. 2 for * and /. 0 for any other character.</returns>
        private int GetPrecedence(char c) 
        {
            switch (c) {
                case '+':
                case '-': return 1;
                case '*':
                case '/': return 2;
                default: return 0;
            }
        }

        /// <summary>
        /// Evaluates a postfix input with additionel whitespace as separator and returns evaluated value.
        /// </summary>
        /// <param name="inputAsPostifx">A postfix expression with additional whitespace between every operator and operand.</param>
        /// <returns>A double with the result of the evaluated input.</returns>
        public double EvaluatePostFix(string inputAsPostifx)
        {
            var values = new Stack<double>();            
            var splittedInput = inputAsPostifx.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < splittedInput.Length; i++)
            {
                var currentValue = splittedInput[i];
                var isNumeric = double.TryParse(currentValue, out double numericValue);

                if (isNumeric)
                {
                    values.Push(numericValue);
                }
                else
                {
                    var b = values.Pop();
                    var a = values.Pop();

                    switch (currentValue) {
                        case "+":                                                        
                            values.Push(a + b);                            
                            break;
                        case "-":                                                                                            
                            values.Push(a - b);                            
                            break;
                        case "*":
                            values.Push(a * b);
                            break;
                        case "/":
                            values.Push(a / b);
                            break;
                    }
                }
            }

            return values.Pop();
        }
    }
}
