using System;
using System.IO;
using FileManager.Abstractions;

namespace FileManager.Services
{
	public class Logger : ILogger
	{
		private readonly string _logFilePath;

		public Logger(string logFilePath)
		{
			_logFilePath = logFilePath;
		}

		public void Log(string message)
		{
			File.AppendAllText(_logFilePath, $@"{DateTime.Now}: {message}{Environment.NewLine}");
		}
	}
}