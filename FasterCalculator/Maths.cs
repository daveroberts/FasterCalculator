using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FasterCalculator
{
    class Maths
    {
        private static char[] validOperators = {'/','*','+','-','^','%'};
        public static int parse(string formula)
        {
            return Maths.evaluate(formula,'+',"0");
        }
        private static int evaluate(string leftSide, char oper, string rightSide)
        {
            int total = 0;
            int leftResult = 0;
            int rightResult = 0;

            int operatorLoc = findOperatorLocation(leftSide);
            if (operatorLoc > 0 && operatorLoc < leftSide.Length - 1)
            {
                leftResult = evaluate(
                                leftSide.Substring(0, operatorLoc),
                                leftSide[operatorLoc],
                                leftSide.Substring(operatorLoc + 1));
            }
            else
            {
                leftResult = Convert.ToInt32(leftSide);
            }

            operatorLoc = findOperatorLocation(rightSide);
            if (operatorLoc > 0 && operatorLoc < rightSide.Length - 1)
            {
                rightResult = evaluate(rightSide.Substring(0, operatorLoc),
                    rightSide[operatorLoc],
                    rightSide.Substring(operatorLoc + 1, rightSide.Length));
            }
            else
            {
                rightResult = Convert.ToInt32(rightSide);
            }

            switch (oper)
            {
                case '^':
                    total = Convert.ToInt32(Math.Pow(Convert.ToDouble(leftResult), Convert.ToDouble(rightResult))); break;
                case '/':
                    total = leftResult / rightResult; break;
                case '*':
                    total = leftResult * rightResult; break;
                case '%':
                    total = leftResult % rightResult; break;
                case '+':
                    total = leftResult + rightResult; break;
                case '-':
                    total = leftResult - rightResult; break;
            }
            return total;
        }
        private static int findOperatorLocation(String str)
        {
            int index = -1;
            for(int i = validOperators.Length-1; i >= 0; i--)
            {
                index = str.IndexOf(validOperators[i]);
                if(index >= 0)
                return index;
            }
            return index;
        }
    }
}
