using RealmForge.Domain.Enums;

namespace RealmForge.Client.Localization
{
	public static class UiText
	{
		#region Navigation & Layout
		public static string NavDashboard(LanguageCode lang) =>
			lang == LanguageCode.It ? "Dashboard" : "Dashboard";

		public static string NavSpecies(LanguageCode lang) =>
			lang == LanguageCode.It ? "Compendio Specie" : "Species Compendium";

		public static string VersionNotice(LanguageCode lang) =>
			lang == LanguageCode.It ? "RealmForge TTRPG Suite v0.1" : "RealmForge TTRPG Suite v0.1";
		#endregion

		#region Dashboard
		public static string HomeTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "BENVENUTO NELLA FORGIA" : "WELCOME TO THE FORGE";

		public static string HomeSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Gestisci le tue campagne, compendi e regole per i tuoi giochi di ruolo da tavolo."
				: "Manage your campaigns, compendiums, and rulebooks for tabletop roleplaying games.";
		#endregion

		#region Common UI Elements & Actions
		public static string Actions(LanguageCode lang) => lang == LanguageCode.It ? "Azioni" : "Actions";
		public static string Edit(LanguageCode lang) => lang == LanguageCode.It ? "Modifica" : "Edit";
		public static string Delete(LanguageCode lang) => lang == LanguageCode.It ? "Elimina" : "Delete";
		public static string Cancel(LanguageCode lang) => lang == LanguageCode.It ? "Annulla" : "Cancel";
		public static string BtnClose(LanguageCode lang) => lang == LanguageCode.It ? "CHIUDI" : "CLOSE";
		public static string BtnCancel(LanguageCode lang) => lang == LanguageCode.It ? "ANNULLA" : "CANCEL";
		public static string BtnViewDetails(LanguageCode lang) => lang == LanguageCode.It ? "DETTAGLI" : "DETAILS";
		public static string BtnInspect(LanguageCode lang) => lang == LanguageCode.It ? "Esamina →" : "Inspect →";
		public static string ConfirmDeletion(LanguageCode lang) => lang == LanguageCode.It ? "Conferma Eliminazione" : "Confirm Deletion";

		public static string TabItalian(LanguageCode lang) => lang == LanguageCode.It ? "🇮🇹 Traduzione Italiana" : "🇮🇹 Italian Translation";
		public static string TabEnglish(LanguageCode lang) => lang == LanguageCode.It ? "🇬🇧 Traduzione Inglese" : "🇬🇧 English Translation";

		public static string LabelName(LanguageCode lang) => lang == LanguageCode.It ? "Nome" : "Name";
		public static string LabelDescription(LanguageCode lang) => lang == LanguageCode.It ? "Descrizione / Note" : "Description / Notes";
		public static string NoDescription(LanguageCode lang) => lang == LanguageCode.It ? "Nessuna annotazione disponibile." : "No notes available.";
		#endregion

		#region Common Validation & Errors
		public static string ErrFillNames(LanguageCode lang) =>
			lang == LanguageCode.It ? "Inserire sia il nome italiano che quello inglese prima di salvare!" : "Please provide both Italian and English names before saving!";

		public static string ErrApiSave(LanguageCode lang) =>
			lang == LanguageCode.It ? "Errore durante il salvataggio nell'archivio." : "Error while saving to the archive.";
		#endregion

		#region Game System & Metadata (Shared)
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

		public static string LabelIsSRD(LanguageCode lang) => lang == LanguageCode.It ? "Contenuto Ufficiale (SRD)" : "Official Content (SRD)";
		public static string BadgeSRD(LanguageCode lang) => lang == LanguageCode.It ? "SRD" : "SRD";
		public static string BadgeHomebrew(LanguageCode lang) => lang == LanguageCode.It ? "Homebrew" : "Homebrew";
		public static string LabelRequiredLevel(int level, LanguageCode lang) => lang == LanguageCode.It ? $"Livello {level}" : $"Level {level}";
		#endregion

		#region Global Filters
		public static string LabelOrigin(LanguageCode lang) => lang == LanguageCode.It ? "Origine Contenuto" : "Content Origin";
		public static string FilterAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutti" : "All";
		public static string FilterRulesetAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le Edizioni" : "All Editions";
		public static string FilterOriginAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutte le Origini" : "All Origins";
		public static string FilterOnlySRD(LanguageCode lang) => lang == LanguageCode.It ? "Solo Ufficiale (SRD)" : "Official SRD Only";
		public static string FilterOnlyHomebrew(LanguageCode lang) => lang == LanguageCode.It ? "Solo Homebrew" : "Homebrew Only";
		#endregion

		#region Feats Compendium
		public static string FeatsTitle(LanguageCode lang) => lang == LanguageCode.It ? "Talenti" : "Feats";

		public static string FeatsSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Consulta i talenti di origine, le doti eroiche e le tecniche di combattimento del multiverso."
				: "Browse origin feats, heroic capabilities, and combat styles across the multiverse.";

		public static string LoadingFeats(LanguageCode lang) =>
			lang == LanguageCode.It ? "Caricamento talenti in corso..." : "Loading feats archive...";

		public static string NoFeatsFound(LanguageCode lang) =>
			lang == LanguageCode.It ? "Nessun talento trovato per i criteri selezionati." : "No feats found matching the criteria.";

		public static string BtnAddFeat(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVO TALENTO" : "+ ADD FEAT";
		public static string BtnSaveFeat(LanguageCode lang) => lang == LanguageCode.It ? "SALVA TALENTO" : "SAVE FEAT";
		public static string ModalTitleAddFeat(LanguageCode lang) => lang == LanguageCode.It ? "AGGIUNGI NUOVO TALENTO" : "ADD NEW FEAT";

		public static string LabelSearchFeat(LanguageCode lang) => lang == LanguageCode.It ? "Cerca Talento" : "Search Feat";
		public static string PlaceholderSearchFeats(LanguageCode lang) =>
			lang == LanguageCode.It ? "Cerca talento per nome o descrizione..." : "Search feat by name or description...";

		public static string LabelFeatCategory(LanguageCode lang) => lang == LanguageCode.It ? "Categoria Talento" : "Feat Category";
		public static string LabelCategory(LanguageCode lang) => lang == LanguageCode.It ? "Categoria:" : "Category:";
		public static string FilterCategoryAll(LanguageCode lang) => lang == LanguageCode.It ? "Tutti" : "All";

		public static string LabelPrerequisite(LanguageCode lang) => lang == LanguageCode.It ? "Prerequisito:" : "Prerequisite:";
		public static string PlaceholderPrerequisite(LanguageCode lang) => lang == LanguageCode.It ? "Es. Livello 4+, Forza 13+" : "e.g. Level 4+, Strength 13+";

		public static string PlaceholderFeatNameIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. Abile, Allerta, Fortunato..." : "e.g. Skilled, Alert, Lucky...";
		public static string PlaceholderFeatNameEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Skilled, Alert, Lucky..." : "e.g. Skilled, Alert, Lucky...";

		public static string DeleteFeatWarning(LanguageCode lang, string featName) =>
			lang == LanguageCode.It
				? $"Sei sicuro di voler eliminare il talento '{featName}'? L'azione è irreversibile."
				: $"Are you sure you want to delete the feat '{featName}'? This action cannot be undone.";

		public static string ErrDeleteFeat(LanguageCode lang) => lang == LanguageCode.It ? "Errore durante l'eliminazione del talento." : "Failed to delete feat.";

		public static string FormatFeatCategory(FeatCategory cat, LanguageCode lang) => (cat, lang) switch
		{
			(FeatCategory.Origin, LanguageCode.It) => "Origine",
			(FeatCategory.Origin, _) => "Origin",
			(FeatCategory.General, LanguageCode.It) => "Generale",
			(FeatCategory.General, _) => "General",
			(FeatCategory.FightingStyle, LanguageCode.It) => "Stile di Combattimento",
			(FeatCategory.FightingStyle, _) => "Fighting Style",
			(FeatCategory.EpicBoon, LanguageCode.It) => "Dono Epico",
			(FeatCategory.EpicBoon, _) => "Epic Boon",
			_ => cat.ToString()
		};
		#endregion

		#region Species Compendium
		public static string SpeciesTitle(LanguageCode lang) => lang == LanguageCode.It ? "COMPENDIO SPECIE" : "SPECIES COMPENDIUM";

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

		public static string BtnAddSpecies(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVA SPECIE" : "+ NEW SPECIES";
		public static string BtnSave(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA SPECIE" : "FORGE SPECIES";
		public static string ModalTitleAddSpecies(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA NUOVA SPECIE" : "FORGE NEW SPECIES";

		public static string LabelCreatureType(LanguageCode lang) => lang == LanguageCode.It ? "Tipo di Creatura" : "Creature Type";
		public static string LabelSizes(LanguageCode lang) => lang == LanguageCode.It ? "Taglie Disponibili" : "Available Sizes";
		public static string LabelSpeed(LanguageCode lang) => lang == LanguageCode.It ? "Velocità Base" : "Base Speed";

		public static string MetaSize(LanguageCode lang) => lang == LanguageCode.It ? "Taglia" : "Size";
		public static string MetaSpeed(LanguageCode lang) => lang == LanguageCode.It ? "Velocità" : "Speed";

		public static string PlaceholderNameIt(LanguageCode lang) => lang == LanguageCode.It ? "Es. Nano delle Colline..." : "E.g., Nano delle Colline...";
		public static string PlaceholderNameEn(LanguageCode lang) => lang == LanguageCode.It ? "Es. Hill Dwarf..." : "E.g., Hill Dwarf...";

		public static string DeleteSpeciesWarning(LanguageCode lang, string speciesName) =>
			lang == LanguageCode.It
				? $"Sei sicuro di voler eliminare la specie '{speciesName}'? L'azione è irreversibile."
				: $"Are you sure you want to delete the species '{speciesName}'? This action cannot be undone.";

		public static string LabelSelectSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie / Lignaggio:" : "Subspecies / Lineage:";
		public static string OptionBaseSpeciesOnly(LanguageCode lang) => lang == LanguageCode.It ? "Specie Base" : "Base Species";
		public static string BadgeSourceBase(LanguageCode lang) => lang == LanguageCode.It ? "Specie" : "Species";
		public static string BadgeSourceSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie" : "Subspecies";
		public static string SectionBaseTraits(LanguageCode lang) => lang == LanguageCode.It ? "Tratti della Specie" : "Species Traits";
		public static string SectionSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie e Lignaggi" : "Subspecies & Lineages";
		public static string BadgeTraitsCount(int count, LanguageCode lang) => lang == LanguageCode.It ? $"{count} Tratti" : $"{count} Traits";
		public static string BadgeSubspeciesCount(int count, LanguageCode lang) => lang == LanguageCode.It ? $"{count} Sottospecie" : $"{count} Subspecies";

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

		public static string FormatSpeed(int speedInFeet, LanguageCode lang)
		{
			if (lang == LanguageCode.It)
			{
				double meters = (speedInFeet / 5.0) * 1.5;
				return $"{meters:0.#} m";
			}

			return $"{speedInFeet} ft.";
		}
		#endregion

		#region Subspecies Compendium
		public static string SubspeciesTitle(LanguageCode lang) => lang == LanguageCode.It ? "Sottospecie e Lignaggi" : "Subspecies & Lineages";

		public static string SubspeciesSubtitle(LanguageCode lang) => lang == LanguageCode.It
			? "Gestisci le varianti regionali e i lignaggi derivati dalla specie madre."
			: "Manage regional variants and lineages derived from the parent species.";

		public static string BtnManageSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "Gestisci Sottospecie" : "Manage Subspecies";

		public static string BtnBackToSpecies(LanguageCode lang) => lang == LanguageCode.It ? "← TORNA ALLA SPECIE" : "← BACK TO SPECIES";

		public static string NoSubspeciesFound(LanguageCode lang) => lang == LanguageCode.It
			? "Nessuna sottospecie trovata. Forgia la prima variante!"
			: "No subspecies found. Forge the first variant!";

		public static string BtnAddSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "+ NUOVA SOTTOSPECIE" : "+ NEW SUBSPECIES";
		public static string ModalTitleAddSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "FORGIA SOTTOSPECIE" : "FORGE SUBSPECIES";
		public static string ModalTitleEditSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "MODIFICA SOTTOSPECIE" : "EDIT SUBSPECIES";
		public static string BtnSaveSubspecies(LanguageCode lang) => lang == LanguageCode.It ? "SALVA SOTTOSPECIE" : "SAVE SUBSPECIES";

		public static string LabelSpeedOverride(LanguageCode lang) => lang == LanguageCode.It ? "Override Velocità (Opzionale)" : "Speed Override (Optional)";

		public static string DeleteSubspeciesWarning(LanguageCode lang, string name) => lang == LanguageCode.It
			? $"Sei sicuro di voler eliminare la sottospecie '{name}'? L'azione è irreversibile."
			: $"Are you sure you want to delete the subspecies '{name}'? This action cannot be undone.";

		public static string InheritedFromParent(LanguageCode lang) => lang == LanguageCode.It ? "Ereditato dalla Specie" : "Inherited from Species";
		#endregion

		#region Error Pages (404)
		public static string NotFoundTitle(LanguageCode lang) =>
			lang == LanguageCode.It ? "ROTTA SMARRITA" : "ROUTE LOST";

		public static string NotFoundSubtitle(LanguageCode lang) =>
			lang == LanguageCode.It
				? "Il sentiero che stai cercando non conduce ad alcuna sala di questa forgia."
				: "The path you are seeking leads to no hall in this forge.";

		public static string NotFoundBackHome(LanguageCode lang) =>
			lang == LanguageCode.It ? "RITORNA ALLA DASHBOARD" : "RETURN TO DASHBOARD";
		#endregion
	}
}