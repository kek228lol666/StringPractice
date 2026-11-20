using System;
using System.Text;
using System.Threading.Tasks;

namespace StringPractice;

public class ThreadSafeLogger
{
    private readonly StringBuilder _safeBuilder = new();
    private readonly StringBuilder _unsafeBuilder = new();
    private readonly object _lock = new();

    public void LogSafe(string message)
    {
        lock (_lock)
        {
            _safeBuilder.AppendLine(message);
        }
    }

    public void LogUnsafe(string message)
    {
        _unsafeBuilder.AppendLine(message);
    }

    public string GetSafeLogs()
    {
        lock (_lock)
        {
            return _safeBuilder.ToString();
        }
    }

    public string GetUnsafeLogs() => _unsafeBuilder.ToString();

    public static void RunDemo()
    {
        var logger = new ThreadSafeLogger();
        const int messagesCount = 1000;

        Parallel.For(0, messagesCount, i =>
        {
            string msg = $"Сообщение #{i}";
            logger.LogSafe(msg);
            logger.LogUnsafe(msg);
        });

        int safeLines = logger.GetSafeLogs().Split('\n', StringSplitOptions.RemoveEmptyEntries).Length;
        int unsafeLines = logger.GetUnsafeLogs().Split('\n', StringSplitOptions.RemoveEmptyEntries).Length;

        Console.WriteLine("=== Тест многопоточного логгера ===");
        Console.WriteLine($"Ожидалось строк: {messagesCount}");
        Console.WriteLine($"С синхронизацией (lock): {safeLines}");
        Console.WriteLine($"Без синхронизации: {unsafeLines}");
    }
}
