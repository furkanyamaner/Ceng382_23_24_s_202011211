using System;
using System.IO;

public static class LogHelper
{
    private static readonly string LogFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs", "log.txt");

    public static void Log(string message)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        catch (Exception ex)
        {
            // Hata yönetimi, log dosyasına yazılamazsa buraya işlem eklenebilir.
        }
    }
}
