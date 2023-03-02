# CertificationApp_C_sharp_basics
Repository with simple planner.
Mateusz Goraj

Prosta lista zadań, która na każdy z siedmiu dni tygodnia umożliwa dodanie osobnej listy rzeczy do wykonania. 
Do każdego zadania będzie można dopisać godzinę wykonania i priorytet (w skali od 1-5). W każdym dniu będzie 
można wyświetlić listę rzeczy do zrobienia, albo ze względu na priorytet, albo ze względu na godzinę wykonania.

STRUKTURA APLIKACJI
Nieskończona pętla zawiera menu, które przekierowuje do odpowiednich
procedur odpowiedzialnych za opcje w aplikacji z głównego menu
Program zawiera 3 podstawowe klasy:
* Schedule - będzie istniała tylko 1 instancja na cały program
głównie przez jej metody wykonywane będą wszystkie operacje
* DayOfWeek - będzie 7 instancji znajdujących się na liście w Schedule,
będą one zawierać listy zadań z danego dnia
* TaskInShedule - klasa model danych zawierająca opis zadania, godzinę
wykonania i priorytet, tak by wygodnie można się było do nich odwoływać