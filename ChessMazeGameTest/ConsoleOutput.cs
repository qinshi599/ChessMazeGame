namespace ChessMazeGameTest;

public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalConsoleOutput;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalConsoleOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput()
        {
            return _stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(_originalConsoleOutput);
            _stringWriter.Dispose();
        }
    }
