Lista uwag:

1. Literówki - np. "dataa.csv"
2. Warto zamiast podawać nazwę pliku skorzystać z refleksji (Assembly), lub wpisania ścieżki pliku w konsoli.
3. Sugeruję rozdzielić funkcjonalność Read i Print data na dwie osobne klasy, zgodnie z zasadą 'Single Responsibility Principle' (SOLID).
4. Rozbijanie pomniejszych funkcjonalności na osobne metody, poprawia to czytelność kodu i jego testowanie.
5. Osobiście do czytania plików csv użyłbym gotowego narzędzia np. CsvHelper.
6. Warto przy Streamach stosować 'using', aby uniknąć problemów z pamięcią.
7. Parametr bool printData jest nieużywany, można by dać użytkownikowi wybór aby podał w konsoli czy np. chce wydrukować [Y/N].
8. Umieszczenie klas z modelami w osobnym pliku, poprawia czytelność kodu.
9. Using nad namespace -> poprawia czytelność kodu.

Oczywiście, możliwych do wprowadzenia zmian jest bardzo dużo, wszystko zależy od tego czy ta aplikacja ma mieć zastosowanie jednorazowe, czy być aplikacją szerszego zastosowania. Wtedy można pokusić się o większą generalizację, zastoswanie abstrakcji/interfejsów.
