using System;
using System.IO;
using System.Text.Json;

public class FileLogger : ILogger
{
    private string logFilePath;

    public FileLogger(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }

    public void Log(LogRecord log)
    {
        try
        {
            string jsonLog = JsonSerializer.Serialize(new[]
            {
                new
                {
                    timestamp = log.GetTimestamp(),
                    message = log.GetReserverName(),
                    roomNumber = log.GetRoomNumber(),
                    situation = log.GetSituation()
                }
            });

            if (File.Exists(logFilePath) && new FileInfo(logFilePath).Length > 0)
            {
                string existingLogs = File.ReadAllText(logFilePath);
                existingLogs = existingLogs.TrimEnd(',', '\r', '\n');
                jsonLog = "," + jsonLog;
            }

            

            File.AppendAllText(logFilePath, jsonLog + Environment.NewLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error {ex.Message}");
        }
    }
}
