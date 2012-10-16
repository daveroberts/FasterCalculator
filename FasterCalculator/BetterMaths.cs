using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FasterCalculator
{
    class BetterMaths
    {
        public BetterMaths() { }
        public static double DoParse(string formula)
        {
            BetterMaths bm = new BetterMaths();
            return bm.parse(formula);
        }
        private static char[] validOperators = { '/', '*', '+', '-', '^', 'e', '%' };
        public double parse(string formula)
        {
            // tokenize the formula
            List<Token> tokens = tokenize(formula);
            return evaluateTokens(tokens);
        }
        private List<Token> tokenize(string formula)
        {
            formula = formula.Replace(" ","");
            List<Token> tokens = new List<Token>();
            Token currentToken = new Token();
			bool bypass = false;
			int position = -1;
            foreach (char c in formula)
            {
				position++;
				if (bypass)
				{
					bypass = false;
					continue;
				}
                if (isNumber(c))
                {
                    if (!currentToken.isEmpty() && !currentToken.isNumber)
                    {
                        tokens.Add(currentToken);
                        currentToken = new Token();
                    }
                    currentToken.isNumber = true;
                    currentToken.numberValue += c;
                }
                else if (isOperator(c))
                {
                    if (!currentToken.isEmpty())
                    {
                        tokens.Add(currentToken);
                        currentToken = new Token();
                    }
                    currentToken.isOperator = true;
                    currentToken.operatorValue = c;
                }
				else if (isParen(c))
				{
					if (!currentToken.isEmpty())
					{
						tokens.Add(currentToken);
						currentToken = new Token();
					}
					currentToken.isParen = true;
					currentToken.parenValue = c;
				}
				else if (c == 'E')
				{
					if (formula[position + 1] == '+')
					{
						bypass = true;
						if (!currentToken.isEmpty())
						{
							tokens.Add(currentToken);
							currentToken = new Token();
						}
						currentToken.isOperator = true;
						currentToken.operatorValue = 'e';
					}
					else
					{
						throw new Exception("Scientific notation is E+ or e");
					}
				}
				else
				{
					throw new Exception("I don't know how to handle '" + c + "'");
				}
            }
            if (!currentToken.isEmpty()) { tokens.Add(currentToken); }
            return tokens;
        }
        private bool isNumber(char c)
        {
            return (c >= '0' && c <= '9' || c == '.') ;
        }
        private bool isOperator(char c)
        {
            return validOperators.Contains(c);
        }
        private bool isParen(char c)
        {
            return (c == '(' || c == ')');
        }
        private double evaluateTokens(List<Token> tokens)
        {
            // process left parens
            ProcessParens(ref tokens);
			ProcessOperator(ref tokens, 'e');
			ProcessUnaryMinus(ref tokens);
            ProcessOperator(ref tokens, '^');
            ProcessOperator(ref tokens, 'm');
            ProcessOperator(ref tokens, '%');
            ProcessOperator(ref tokens, 'a');
            return Convert.ToDouble(tokens[0].numberValue);
        }
        private void ProcessParens(ref List<Token> tokens)
        {
            int posLParen = -1;
            do
            {
                posLParen = tokens.indexOfLParen();
                if (posLParen != -1)
                {
                    int posRParen = tokens.indexOfRParen(posLParen);
                    // remove this range from the array
                    List<Token> subExpression = new List<Token>();
                    for(int i = posLParen+1; i < posRParen; i++)
                    {
                        subExpression.Add(tokens[i]);
                    }
                    tokens.RemoveRange(posLParen, (posRParen - posLParen + 1));
                    double subExpressionValue = evaluateTokens(subExpression);
                    Token t = new Token();
                    t.isNumber = true;
                    t.numberValue = subExpressionValue.ToString();
                    tokens.Insert(posLParen, t);
                }
            }
            while (posLParen != -1);
            // shouldn't be any R parens left
        }
		private void ProcessUnaryMinus(ref List<Token> tokens)
		{
			int posOperator = 0;
			do
			{
				posOperator = tokens.indexOfNextOperator('-', posOperator);
				if (posOperator != -1)
				{
					Token left = null;
					Token right = null;
					if (posOperator - 1 != -1) { left = tokens[posOperator - 1]; }
					if (posOperator + 1 < tokens.Count) { right = tokens[posOperator + 1]; }

					// special case, unary minus.  If there is nothing to the left of the minus, or there is a non token number, perform unary minus
					if (left == null || (left != null && !left.isNumber && right.isNumber))
					{
						Token unt = new Token();
						unt.isNumber = true;
						unt.numberValue = (-1 * Convert.ToDouble(right.numberValue)).ToString();
						// remove this range from the array
						tokens.RemoveRange(posOperator, 2);
						tokens.Insert(posOperator, unt);
					}
					posOperator++;
				}
			}
			while (posOperator != -1);
		}
        private void ProcessOperator(ref List<Token> tokens, char op)
        {
            int posOperator = -1;
            do
            {
                posOperator = tokens.indexOfOperator(op);
                if (posOperator != -1)
                {
					Token left = null;
					Token right = null;
					if (posOperator - 1 != -1) { left = tokens[posOperator - 1]; }
					if (posOperator + 1 < tokens.Count) { right = tokens[posOperator + 1]; }
					if (right == null) { throw new Exception("Nothing to the right of the operator"); }
					if (left == null) { throw new Exception("Nothing to the left of the operator"); }
					if (!left.isNumber) { throw new Exception("Left side is not a number"); }
					if (!right.isNumber) { throw new Exception("Right side is not a number"); }

					Token t = new Token();
					t.isNumber = true;
                    switch (tokens[posOperator].operatorValue)
					{
						case '^':
							t.numberValue = Math.Pow(Convert.ToDouble(left.numberValue), Convert.ToDouble(right.numberValue)).ToString(); break;
						case '/':
							t.numberValue = (Convert.ToDouble(left.numberValue) / Convert.ToDouble(right.numberValue)).ToString(); break;
						case '*':
							t.numberValue = (Convert.ToDouble(left.numberValue) * Convert.ToDouble(right.numberValue)).ToString(); break;
                        case '%':
                            t.numberValue = (Convert.ToDouble(left.numberValue) % Convert.ToDouble(right.numberValue)).ToString(); break;
						case '+':
							t.numberValue = (Convert.ToDouble(left.numberValue) + Convert.ToDouble(right.numberValue)).ToString(); break;
						case '-':
							t.numberValue = (Convert.ToDouble(left.numberValue) - Convert.ToDouble(right.numberValue)).ToString(); break;
						case 'e':
							t.numberValue = (Convert.ToDouble(left.numberValue) * Math.Pow(10, Convert.ToDouble(right.numberValue))).ToString(); break;
					}
					// remove this range from the array
					tokens.RemoveRange(posOperator - 1, 3);
					tokens.Insert(posOperator - 1, t);
                }
            }
            while (posOperator != -1);
        }
    }
    public class Token
    {
        public bool isNumber;
        public string numberValue;
        public bool isOperator;
        public char operatorValue;
        public bool isParen;
        public char parenValue;
        public bool isEmpty()
        {
            return (!isNumber && !isOperator && !isParen);
        }
        public override string ToString()
        {
            if (isNumber) { return numberValue; }
            if (isOperator) { return operatorValue.ToString(); }
            if (isParen) { return parenValue.ToString(); }
            return "";
        }
    }
    public static class MyExtensions
    {
        public static int indexOfLParen(this List<Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Token token = tokens[i];
                if (token.isParen && token.parenValue == '(') return i;
            }
            return -1;
        }
        public static int indexOfRParen(this List<Token> tokens, int posLParen)
        {
            int cntLParen = 0;
            for (int i = posLParen; i < tokens.Count; i++)
            {
                Token token = tokens[i];
                if (token.isParen)
                {
                    if (cntLParen == 0)
                    {
                        if (token.parenValue == ')')
                        {
                            return i;
                        }
                    }
                    else
                    {
                        if (token.parenValue == '(')
                        {
                            cntLParen++;
                        }
                        else if (token.parenValue == ')')
                        {
                            cntLParen--;
                        }
                    }
                }
            }
			throw new Exception("Left and right parenthesis don't match");
        }
        public static int indexOfOperator(this List<Token> tokens, char op)
        {
			return tokens.indexOfNextOperator(op, 0);
        }
		public static int indexOfNextOperator(this List<Token> tokens, char op, int start)
		{
			if (start < 0) { start = 0; }
			if (start >= tokens.Count) { start = tokens.Count; }
			for (int i = start; i < tokens.Count; i++)
			{
				Token token = tokens[i];
                if (op == 'a')
                {
                    if (token.isOperator && token.operatorValue == '+') return i;
                    if (token.isOperator && token.operatorValue == '-') return i;
                }
                else if (op == 'm')
                {
                    if (token.isOperator && token.operatorValue == '*') return i;
                    if (token.isOperator && token.operatorValue == '/') return i;
                }
                else
                {
                    if (token.isOperator && token.operatorValue == op) return i;
                }
			}
			return -1;
		}
        public static string ToString(this List<Token> tokens)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Token t in tokens)
            {
                sb.Append(t.ToString());
            }
            return sb.ToString();
        }
    }
}
