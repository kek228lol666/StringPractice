using System;
using System.IO;
using System.Text;

namespace StringPractice;

public record Sale(string Product, int Quantity, decimal Price);

public class ReportBuilder
{
    public string BuildReport(Sale[] sales)
    {
        var sb = new StringBuilder();
        sb.AppendLine("ОТЧЁТ О ПРОДАЖАХ");
        sb.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
        sb.AppendLine(new string('-', 56));
        sb.AppendLine(
            "Товар".PadRight(20) +
            "Кол-во".PadLeft(10) +
            "Цена".PadLeft(12) +
            "Сумма".PadLeft(14)
        );
        sb.AppendLine(new string('-', 56));

        decimal grandTotal = 0;

        foreach (var sale in sales)
        {
            decimal rowTotal = sale.Quantity * sale.Price;
            grandTotal += rowTotal;

            sb.AppendLine(
                sale.Product.PadRight(20) +
                sale.Quantity.ToString().PadLeft(10) +
                $"{sale.Price:F2}".PadLeft(12) +
                $"{rowTotal:F2}".PadLeft(14)
            );
        }

        sb.AppendLine(new string('-', 56));
        sb.AppendLine($"ИТОГО:".PadRight(42) + $"{grandTotal:F2}".PadLeft(14));

        return sb.ToString();
    }

    public void SaveToFile(string filePath, string reportContent)
    {
        File.WriteAllText(filePath, reportContent, Encoding.UTF8);
    }
}
