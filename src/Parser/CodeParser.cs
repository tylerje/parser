namespace Parser
{
    public interface ICodeParser
    {
        (bool allClosed, int failedIndex) AreBracketsClosed(string text, char openingBracket, char closingBracket);
    }


    public class CodeParser : ICodeParser
    {
        public (bool allClosed, int failedIndex) AreBracketsClosed(string text, char openingBracket, char closingBracket)
        {
            if (string.IsNullOrEmpty(text)) return (true, 0);
            
            var stack = new Stack<int>();
            for (int i = 0; i < text.Length; i++) 
            { 
                if (text[i] == openingBracket) stack.Push(i);
                else if (text[i] == closingBracket)
                {
                    if (stack.Count == 0) return (false, i);
                    stack.Pop();
                }
            }

            var lastOpenBracketUnclosedIndex = 0;
            var stackCount = stack.Count;
            while (stack.Count > 0)
            {
                lastOpenBracketUnclosedIndex = stack.Pop();
            }

            return (stackCount == 0, lastOpenBracketUnclosedIndex);
        }
    }
}