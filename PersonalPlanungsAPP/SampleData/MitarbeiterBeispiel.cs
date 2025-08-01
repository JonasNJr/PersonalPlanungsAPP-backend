using System;
using System.Collections.Generic;
using PersonalPlanungsAPP.Models;
using PersonalPlanungsAPP.Enums;

namespace PersonalPlanungsAPP.SampleData
{
    public static class MitarbeiterBeispiel
    {
        public static List<Mitarbeiter> Alle = new()
        {
            // schon vorhandene beiden
            new Mitarbeiter
            {
                Id = 1,
                Vorname = "Max",
                Name = "Mustermann",
                Eintrittsdatum = new DateTime(2015, 3, 1),
                Befristung = null,
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "Langjähriger Mitarbeiter",
                Funktion = "Teamleiter",
                Kostenstelle = "1100",
                Fte = 1.0,
                Bereich = Bereich.Direkt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenunabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Unbefristet
            },
            new Mitarbeiter
            {
                Id = 2,
                Vorname = "Lisa",
                Name = "Schmidt",
                Eintrittsdatum = new DateTime(2020, 8, 15),
                Befristung = new DateTime(2025, 8, 14),
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = null,
                Funktion = "Sachbearbeiterin",
                Kostenstelle = "1200",
                Fte = 1.14,
                Bereich = Bereich.Indirekt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Befristet
            },

            // 5–10 weitere, verteilt auf 3 "Kostenstellen"/Abteilungen:
            new Mitarbeiter
            {
                Id = 3,
                Vorname = "Anna",
                Name = "Weber",
                Eintrittsdatum = new DateTime(2019, 5, 10),
                Befristung = null,
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "Teilzeitkraft",
                Funktion = "Personalsachbearbeiterin",
                Kostenstelle = "1100",
                Fte = 0.75,
                Bereich = Bereich.Direkt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenunabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Unbefristet
            },
            new Mitarbeiter
            {
                Id = 4,
                Vorname = "Tom",
                Name = "Becker",
                Eintrittsdatum = new DateTime(2017, 11, 1),
                Befristung = null,
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "IT-Administrator",
                Funktion = "Systemadministrator",
                Kostenstelle = "1200",
                Fte = 1.0,
                Bereich = Bereich.Indirekt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenunabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Unbefristet
            },
            new Mitarbeiter
            {
                Id = 5,
                Vorname = "Eva",
                Name = "Müller",
                Eintrittsdatum = new DateTime(2018, 3, 1),
                Befristung = new DateTime(2024, 3, 1),
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "Produktionshilfe",
                Funktion = "Maschinenführerin",
                Kostenstelle = "1300",
                Fte = 0.90,
                Bereich = Bereich.Direkt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Befristet
            },
            new Mitarbeiter
            {
                Id = 6,
                Vorname = "Jan",
                Name = "Fischer",
                Eintrittsdatum = new DateTime(2021, 9, 15),
                Befristung = null,
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "HR-Unterstützung",
                Funktion = "Assistent",
                Kostenstelle = "1100",
                Fte = 0.60,
                Bereich = Bereich.Indirekt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenunabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Unbefristet
            },
            new Mitarbeiter
            {
                Id = 7,
                Vorname = "Sara",
                Name = "Krause",
                Eintrittsdatum = new DateTime(2016, 2, 20),
                Befristung = null,
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "Senior-Entwicklerin",
                Funktion = "Software Engineer",
                Kostenstelle = "1200",
                Fte = 1.0,
                Bereich = Bereich.Direkt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenunabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Unbefristet
            },
            new Mitarbeiter
            {
                Id = 8,
                Vorname = "Peter",
                Name = "Braun",
                Eintrittsdatum = new DateTime(2022, 1, 5),
                Befristung = new DateTime(2023,12,31),
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "Urlaubsvertretung",
                Funktion = "Produktionshelfer",
                Kostenstelle = "1300",
                Fte = 0.50,
                Bereich = Bereich.Direkt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Befristet
            },
            new Mitarbeiter
            {
                Id = 9,
                Vorname = "Laura",
                Name = "Schneider",
                Eintrittsdatum = new DateTime(2020, 12, 1),
                Befristung = new DateTime(2024,12,1),
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = null,
                Funktion = "HR-Managerin",
                Kostenstelle = "1100",
                Fte = 0.80,
                Bereich = Bereich.Indirekt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenunabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Befristet
            },
            new Mitarbeiter
            {
                Id = 10,
                Vorname = "Michael",
                Name = "Hofmann",
                Eintrittsdatum = new DateTime(2019, 6, 18),
                Befristung = new DateTime(2025, 6,18),
                Verlaengerung1 = null,
                Verlaengerung2 = null,
                BefristungMax = null,
                Freistellung = null,
                Kuendigung = null,
                Austritt = Austrittsart.KeineAngabe,
                Bemerkung = "IT-Support",
                Funktion = "Helpdesk",
                Kostenstelle = "1200",
                Fte = 0.70,
                Bereich = Bereich.Indirekt,
                Mengenabhaengigkeit = Mengenabhaengigkeit.Mengenunabhaengig,
                Arbeitsverhaeltnis = Arbeitsverhaeltnis.Befristet
            }
        };
    }
}
