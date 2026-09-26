using RealmForge.Domain.Enums;

namespace RealmForge.Client.Services
{
	public class LanguageStateService
	{
		public LanguageCode CurrentLanguage { get; private set; } = LanguageCode.It;

		//	Event raised to notify registered components when the language changes
		public event Action? OnLanguageChanged;

		public void SetLanguage(LanguageCode newLanguage)
		{
			if (CurrentLanguage != newLanguage)
			{
				CurrentLanguage = newLanguage;
				OnLanguageChanged?.Invoke();
			}
		}
	}
}