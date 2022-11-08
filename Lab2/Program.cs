using System.Collections;

namespace Lab2;
public class Program
{
    public static void Main(string[] args)
    {
        IsBalanced("{ ( < > ) }");  // true
        IsBalanced("<> {(})");      // false
    }

    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        // iterate over all chars in string
        foreach(var c in s)
        {
            // if char is an open thing, push it
            if ( c=='<' || c=='(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }

            // if char is a close thing,
            // compare it to top of stack;
            else if (c == '>' || c == ')' || c == '}' || c == ']')
            {
                char top;
                bool result = stack.TryPeek(out top);
                // handle result == false

                // if they match, pop()
                if (Matches(c, top) ) 
                {
                    stack.Pop();
                }
                // else, return false
                else
                {
                    return false;
                }
            }
            
        }

        // if stack is empty, return true
        if( stack.Count == 0)
        {
            return true;
        }

        return false;

    }

    private static bool Matches(char closing, char opening)
    {
        if (opening == '(' && closing == ')')
        {
            return true;
        }
        else if (opening == '[' && closing == ']')
        {
            return true;
        }
        else if (opening == '{' && closing == '}')
        {
            return true;
        }
        else if (opening == '<' && closing == '>')
        {
            return true;
        }

        return false;
    }


    public static double? Evaluate(string s)
    {
        // parse string into tokens
        string[] tokens = s.Split();
        Stack<double> stack = new Stack<double>();

        // foreach token
        foreach (string token in tokens)
        {
            // if it's a number, push to stack
            double value;
            if(double.TryParse(token, out value))
            {
                stack.Push(value);
            }
            // if it's a math operator, pop twice;
            else
            {
                // compute result
                // push result onto stack
                double val1 = stack.Pop();
                double val2 = stack.Pop();
                if(token == "+")
                {
                    stack.Push(val2 + val1);
                }
                else if (token == "-")
                {
                    stack.Push(val2 - val1);
                }
                else if (token == "*")
                {
                    stack.Push(val2 * val1);
                }
                else if (token == "/")
                {
                    //double answer = val2 / val1;
                    stack.Push(val2 / val1);
                }
            }
            //return top of stack (if the stack has 1 element)
            
        }

        if(stack.Count == 1)
        {
            return stack.Pop();
        }
        else
        {
            return null;
        }
    }

}

