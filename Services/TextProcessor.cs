namespace CommandPattern.Services
{
    public class TextProcessor
    {
        private string _text;
        private string _clipboard;

        public TextProcessor(string initialText)
        {
            _text = initialText;
            _clipboard = string.Empty;
        }

        public string GetText() => _text;

        public void SetText(string text) => _text = text;

        public void Copy(int startIdx, int endIdx)
        {
            _clipboard = _text.Substring(startIdx, endIdx - startIdx + 1);
        }

        public void Paste(int idx)
        {
            _text = _text.Insert(idx, _clipboard);
        }

        public void Insert(string text, int idx)
        {
            _text = _text.Insert(idx, text);
        }

        public void Delete(int startIdx, int endIdx)
        {
            _text = _text.Remove(startIdx, endIdx - startIdx + 1);
        }

        public override string ToString() => _text;
    }
}
