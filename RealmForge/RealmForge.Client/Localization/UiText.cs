using RealmForge.Domain.Enums;

namespace RealmForge.Client.Localization
{
	public static class UiText
	{
		//	Navigation items
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

		//	Species Compendium page
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

		//	404 Not Found page
		public static string NotFoundTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "ROTTA SMARRITA" : "ROUTE LOST";

		public static string NotFoundSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Il sentiero che stai cercando non conduce ad alcuna sala di questa forgia."
				: "The path you are seeking leads to no hall in this forge.";

		public static string NotFoundBackHome(LanguageCode lang) =>
			lang == LanguageCode.It ? "RITORNA ALLA DASHBOARD" : "RETURN TO DASHBOARD";

		//	Species creation form & modal
		public static string BtnAddSpecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "+ NUOVA SPECIE" : "+ NEW SPECIES";

		public static string ModalTitleAddSpecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "FORGIA NUOVA SPECIE" : "FORGE NEW SPECIES";

		public static string LabelCreatureType(LanguageCode lang) =>
			lang == LanguageCode.It ? "Tipo di Creatura" : "Creature Type";

		public static string LabelSizes(LanguageCode lang) =>
			lang == LanguageCode.It ? "Taglie Disponibili" : "Available Sizes";

		public static string LabelSpeed(LanguageCode lang) =>
			lang == LanguageCode.It ? "Velocità Base" : "Base Speed";

		public static string LabelIsSRD(LanguageCode lang) =>
			lang == LanguageCode.It ? "Contenuto Ufficiale (SRD)" : "Official Content (SRD)";

		public static string BadgeSRD(LanguageCode lang) =>
			lang == LanguageCode.It ? "SRD" : "SRD";

		public static string BadgeHomebrew(LanguageCode lang) =>
			lang == LanguageCode.It ? "Homebrew" : "Homebrew";

		public static string TabItalian(LanguageCode lang) =>
			lang == LanguageCode.It ? "🇮🇹 Traduzione Italiana" : "🇮🇹 Italian Translation";

		public static string TabEnglish(LanguageCode lang) =>
			lang == LanguageCode.It ? "🇬🇧 Traduzione Inglese" : "🇬🇧 English Translation";

		public static string LabelName(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nome" : "Name";

		public static string LabelDescription(LanguageCode lang) =>
			lang == LanguageCode.It ? "Descrizione / Note" : "Description / Notes";

		public static string PlaceholderNameIt(LanguageCode lang) =>
			lang == LanguageCode.It ? "Es. Nano delle Colline..." : "E.g., Nano delle Colline...";

		public static string PlaceholderNameEn(LanguageCode lang) =>
			lang == LanguageCode.It ? "Es. Hill Dwarf..." : "E.g., Hill Dwarf...";

		public static string BtnSave(LanguageCode lang) =>
			lang == LanguageCode.It ? "FORGIA SPECIE" : "FORGE SPECIES";

		public static string BtnCancel(LanguageCode lang) =>
			lang == LanguageCode.It ? "ANNULLA" : "CANCEL";

		public static string ErrFillNames(LanguageCode lang) =>
			lang == LanguageCode.It ? "Inserire sia il nome italiano che quello inglese prima di salvare!" : "Please provide both Italian and English names before saving!";

		public static string ErrApiSave(LanguageCode lang) =>
			lang == LanguageCode.It ? "Errore durante il salvataggio della specie nell'archivio." : "Error while saving the species to the archive.";

		//	Creature Type localization
		public static string FormatCreatureType(CreatureType type, LanguageCode lang) => (type, lang) switch
		{
			(CreatureType.Humanoid, LanguageCode.It) => "Umanoide",
			(CreatureType.Beast, LanguageCode.It) => "Bestia",
			(CreatureType.Fey, LanguageCode.It) => "Folletto",
			(CreatureType.Fiend, LanguageCode.It) => "Immondo",
			(CreatureType.Celestial, LanguageCode.It) => "Celestiale",
			(CreatureType.Undead, LanguageCode.It) => "Non Morto",
			(CreatureType.Construct, LanguageCode.It) => "Costrutto",
			(CreatureType.Dragon, LanguageCode.It) => "Drago",
			(CreatureType.Elemental, LanguageCode.It) => "Elementale",
			(CreatureType.Monstrosity, LanguageCode.It) => "Mostruosità",
			(CreatureType.Aberration, LanguageCode.It) => "Aberrazione",
			(CreatureType.Giant, LanguageCode.It) => "Gigante",
			(CreatureType.Ooze, LanguageCode.It) => "Melma",
			(CreatureType.Plant, LanguageCode.It) => "Vegetale",
			_ => type.ToString()
		};

		//	Creature Size localization
		public static string FormatSizeSingle(CreatureSize size, LanguageCode lang) => (size, lang) switch
		{
			(CreatureSize.Tiny, LanguageCode.It) => "Minuscola",
			(CreatureSize.Small, LanguageCode.It) => "Piccola",
			(CreatureSize.Medium, LanguageCode.It) => "Media",
			(CreatureSize.Large, LanguageCode.It) => "Grande",
			(CreatureSize.Huge, LanguageCode.It) => "Enorme",
			(CreatureSize.Gargantuan, LanguageCode.It) => "Mastodontica",
			_ => size.ToString()
		};

		//	Multiple sizes formatter (e.g., "Media o Piccola" vs "Medium or Small")
		public static string FormatSizes(IEnumerable<CreatureSize>? sizes, LanguageCode lang)
		{
			if (sizes == null || !sizes.Any())
			{
				return "-";
			}

			var localizedSizes = sizes.Select(s => FormatSizeSingle(s, lang));
			var separator = lang == LanguageCode.It ? " o " : " or ";
			return string.Join(separator, localizedSizes);
		}

		//	Automatic metric / imperial speed conversion (5 ft = 1.5 m)
		public static string FormatSpeed(int speedInFeet, LanguageCode lang)
		{
			if (lang == LanguageCode.It)
			{
				double meters = (speedInFeet / 5.0) * 1.5;
				return $"{meters:0.#} m";
			}

			return $"{speedInFeet} ft.";
		}

		//	Ruleset Version Localization
		public static string LabelRuleset(LanguageCode lang) =>
			lang == LanguageCode.It ? "Regolamento / Edizione" : "Ruleset / Edition";

		public static string FormatRuleset(RulesetVersion ruleset, LanguageCode lang) => (ruleset, lang) switch
		{
			(RulesetVersion.Dnd5e_2014, LanguageCode.It) => "5e (2014)",
			(RulesetVersion.Dnd5e_2014, LanguageCode.En) => "5e (2014)",
			(RulesetVersion.Dnd5e_2024, LanguageCode.It) => "5.5e (2024)",
			(RulesetVersion.Dnd5e_2024, LanguageCode.En) => "5.5e (2024)",
			_ => ruleset.ToString()
		};

		//	Filter Bar Labels
		public static string LabelOrigin(LanguageCode lang) =>
			lang == LanguageCode.It ? "Origine Contenuto" : "Content Origin";

		public static string FilterAll(LanguageCode lang) =>
			lang == LanguageCode.It ? "Tutti" : "All";

		public static string FilterRulesetAll(LanguageCode lang) =>
			lang == LanguageCode.It ? "Tutte le Edizioni" : "All Editions";

		public static string FilterOriginAll(LanguageCode lang) =>
			lang == LanguageCode.It ? "Tutte le Origini" : "All Origins";

		public static string FilterOnlySRD(LanguageCode lang) =>
			lang == LanguageCode.It ? "Solo Ufficiale (SRD)" : "Official SRD Only";

		public static string FilterOnlyHomebrew(LanguageCode lang) =>
			lang == LanguageCode.It ? "Solo Homebrew" : "Homebrew Only";

		//	Interactive Sheet Labels & Detail Modal
		public static string LabelSelectSubspecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "Sottospecie / Lignaggio:" : "Subspecies / Lineage:";

		public static string OptionBaseSpeciesOnly(LanguageCode lang) =>
			lang == LanguageCode.It ? "Specie Base" : "Base Species";

		public static string BadgeSourceBase(LanguageCode lang) =>
			lang == LanguageCode.It ? "Specie" : "Species";

		public static string BadgeSourceSubspecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "Sottospecie" : "Subspecies";

		public static string SectionBaseTraits(LanguageCode lang) =>
			lang == LanguageCode.It ? "Tratti della Specie" : "Species Traits";

		public static string SectionSubspecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "Sottospecie e Lignaggi" : "Subspecies & Lineages";

		public static string BadgeTraitsCount(int count, LanguageCode lang) =>
			lang == LanguageCode.It ? $"{count} Tratti" : $"{count} Traits";

		public static string BadgeSubspeciesCount(int count, LanguageCode lang) =>
			lang == LanguageCode.It ? $"{count} Sottospecie" : $"{count} Subspecies";

		public static string BtnViewDetails(LanguageCode lang) =>
			lang == LanguageCode.It ? "DETTAGLI" : "DETAILS";

		public static string LabelRequiredLevel(int level, LanguageCode lang) =>
			lang == LanguageCode.It ? $"Livello {level}" : $"Level {level}";

		public static string BtnClose(LanguageCode lang) =>
			lang == LanguageCode.It ? "CHIUDI" : "CLOSE";
	}
}