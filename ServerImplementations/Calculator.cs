using CoreCalculator.ServerDefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCalculator.ServerImplementations
{
    public class Calculator : ICalculator
    {        
        public double Calculate(string input)
        {
            var inputAsPostFixResult = ToPostFix(input);
            var postfixEvaluationResult = EvaluatePostFix(inputAsPostFixResult);

            return postfixEvaluationResult;
        }

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
