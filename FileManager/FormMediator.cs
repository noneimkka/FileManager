using System;

namespace FileManager
{
	/// <summary>
	/// Обработчик форм
	/// </summary>
	public static class FormMediator
	{
		// Событие при обновлении одной из форм
		public static event Action<string[]> OnUpdate;

		// Метод для вызова события
		public static void UpdateFrom(params string[] pathsToUpdate)
		{
			OnUpdate?.Invoke(pathsToUpdate);
		}
	}
}