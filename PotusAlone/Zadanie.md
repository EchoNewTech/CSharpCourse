# All Alone - Analiza Izolacji (Codewars)

## Cel zadania
Program sprawdza, czy postać **POTUS** (oznaczona jako `X`) jest odizolowana od **elfów** (oznaczonych jako `o`). Izolację zapewniają ściany wykonane z symbolu `#`.

## Mapa testowa
W poniższym przypadku `X` znajduje się wewnątrz zamkniętego pomieszczenia, więc algorytm powinien potwierdzić, że jest on **sam** (`AllAlone = true`), mimo że elfy znajdują się na tej samej mapie.

```text
   o                o        #######
 ###############             #     #
 #             #        o    #     #
 #  X          ###############     #
 #                                 #
 ###################################
```
 ## Technologie
 - Język: C#
 - Struktury: char[][] (Jagged Array), List<Point>, struct Point

 ## Link do zadania
 `https://www.codewars.com/kata/5c230f017f74a2e1c300004f`