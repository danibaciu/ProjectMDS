### [8 / 5 / 2022]
- Fix Bug Inamici care se indeparteaza de tine chiar si cand stai pe loc ( In Rigidbody inamici -> bifati Freeze position x y z   + setati  min distance mai mare ca Stop distance din nav mash )
- System shooting inamici ( inamicii trag in tine, dar mai rar ca sa te poti feri, si doar cand intri in range-ul lor)
- System Viata jucator ( click pe obiectul Player si observati campul phealt in script. Are o valoare mare ptc nu avem meniu GameOver inca, dar pt test puteti sa il setati la 100 si sa vedeti cum jucatorul moare)
- Modificat valori pt range-ul inamicilor si distanta maxima la care se pot apropia de tine.
- Corectat greseli in Script Inamici cand te urmaresc (Erau niste conditii puse prost acolo. Vezi Enemy.cs de la linia 51 pana la linia 93 )
- Modificat niste parametri si setari in enemy prefab
