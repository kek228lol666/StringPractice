using System;
using StringPractice;

// 1. Анализатор текста
string sampleText = "C# — отличный язык! C# быстрый, строгий и удобный. Разработка на C# приносит удовольствие.";
TextAnalyzer.Analyze(sampleText);
Console.WriteLine();

// 2. Генератор отчета
var sales = new[]
{
    new Sale("Ноутбук", 2, 75000.00m),
    new Sale("Мышь", 5, 1500.50m),
    new Sale("Клавиатура", 3, 4200.00m)
};
var reportBuilder = new ReportBuilder();
string report = reportBuilder.BuildReport(sales);
Console.WriteLine(report);
reportBuilder.SaveToFile("report.txt", report);

// 3. Шифр Цезаря
string secret = "Hello, World! 2026";
string encrypted = CaesarCipher.Encrypt(secret, 3);
string decrypted = CaesarCipher.Decrypt(encrypted, 3);
Console.WriteLine($"=== Шифр Цезаря ===\nИсходный: {secret}\nЗашифрован: {encrypted}\nРасшифрован: {decrypted}\n");

// 4. Парсер CSV
string csvLine = "\"Smith, John\",42,\"New York, NY\"";
var parsedFields = CsvParser.ParseLine(csvLine);
Console.WriteLine("=== Парсер CSV ===");
Console.WriteLine($"Поля: {string.Join(" | ", parsedFields)}");
Console.WriteLine($"Обратная сборка: {CsvParser.BuildLine(parsedFields)}\n");

// 5. Многопоточный логгер
ThreadSafeLogger.RunDemo();
