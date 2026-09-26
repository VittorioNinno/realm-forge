using RealmForge.Domain.Enums;

namespace RealmForge.Client.Services
{
	public class LanguageStateService
	{
		public LanguageCode CurrentLanguage { get; private set; } = LanguageCode.It;

		//	Evento notificato ai componenti registrati quando la lingua cambia
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