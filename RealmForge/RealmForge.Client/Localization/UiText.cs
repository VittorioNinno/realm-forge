using RealmForge.Domain.Enums;

namespace RealmForge.Client.Localization
{
	public static class UiText
	{
		//	Voci di Navigazione
		public static string NavDashboard(LanguageCode lang) =>
			lang == LanguageCode.It ? "Dashboard" : "Dashboard";

		public static string NavSpecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "Compendio Specie" : "Species Compendium";

		//	Dashboard Home
		public static string HomeTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "BENVENUTO NELLA FORGIA" : "WELCOME TO THE FORGE";

		public static string HomeSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Gestisci le tue campagne, compendi e regole per i tuoi giochi di ruolo da tavolo."
				: "Manage your campaigns, compendiums, and rulebooks for tabletop roleplaying games.";

		//	Pagina Compendio Specie
		public static string SpeciesTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "COMPENDIO SPECIE" : "SPECIES COMPENDIUM";

		public static string SpeciesSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Archivio delle specie registrate per le tue sessioni"
				: "Archive of registered species for your tabletop sessions";

		public static string LoadingArchives(LanguageCode lang) =>
			lang == LanguageCode.It ? "Consultazione degli archivi..." : "Consulting the archives...";

		public static string NoSpeciesFound(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Nessuna specie registrata nel compendio per la lingua selezionata."
				: "No species registered in the compendium for the selected language.";

		public static string MetaSize(LanguageCode lang) =>
			lang == LanguageCode.It ? "Taglia" : "Size";

		public static string MetaSpeed(LanguageCode lang) =>
			lang == LanguageCode.It ? "Velocità" : "Speed";

		public static string NoDescription(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nessuna annotazione disponibile." : "No notes available.";

		public static string VersionNotice(LanguageCode lang) =>
			lang == LanguageCode.It ? "RealmForge TTRPG Suite v0.1" : "RealmForge TTRPG Suite v0.1";

		//	Pagina 404 Not Found
		public static string NotFoundTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "ROTTA SMARRITA" : "ROUTE LOST";

		public static string NotFoundSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Il sentiero che stai cercando non conduce ad alcuna sala di questa forgia."
				: "The path you are seeking leads to no hall in this forge.";

		public static string NotFoundBackHome(LanguageCode lang) =>
			lang == LanguageCode.It ? "RITORNA ALLA DASHBOARD" : "RETURN TO DASHBOARD";
	}
}