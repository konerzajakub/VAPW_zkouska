# Videostop: Aplikace pro více hráčů

## Funkce aplikace:
- **Hlavní formulář:**
  - Obsahuje tři pole, kde se náhodně střídají číslice 1, 2, 3.
  - Uživatel může nastavit periodu změny prvkem pod jednotlivými poli.
  - Zobrazuje seznam hráčů seřazených podle aktuálního skóre.
  - Obsahuje tlačítko pro spuštění hry, kde lze nastavit počet hráčů a vygenerovat příslušný počet ovládacích formulářů.

- **Ovládací formuláře hráčů:**
  - Každý hráč má svůj ovládací formulář.
  - Obsahuje pole pro zadání jména hráče (výchozí jméno je indexováno).
  - Při změně jména se okamžitě aktualizuje seznam na hlavním formuláři.

- **Tlačítko "Stop tahu":**
  - Po stisknutí:
    - Pokud jsou všechny číslice na hlavním formuláři stejné, zvyšuje se skóre o 1.
    - Jinak se snižuje o 1.
    - Aktualizuje se seznam hráčů s aktuálním skóre na hlavním formuláři.

- **Ukončení hry:**
  - Při zavření ovládacího formuláře se ruší hra daného hráče (odebere se ze seznamu hráčů).
