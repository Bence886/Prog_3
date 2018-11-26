# Prog3_HW_Moq

## Moq gyakorló feladat

**Feladat:**  
Készítsen egy ILogging interfészt ami előír egy WriteLog metódust. Visszatérési értéke void bemeneti paraméterei LogLevel enum és string message. *(enum LogLevel { Exception, Trace, Debug, Message, Warning, Error })*  

Készítsen egy ConsoleLogger osztály atmi megvalósítja az előbbiekben létrehozott interfészt.  

Készítsen egy Logika osztályt, aminek Dependency Injection használatával adjon meg egy Loggoló osztályt.
A Logika osztálynak legyen egy metódusa ami a megadott log osztályt logolja a tevékenységét. (Nem kell tényleges logikát tartalmaznia a metódusnak.)  

Készítsen egy Teszt projektet amiben leteszteli hogy a logika osztály megfelelően használja-e a megadott logger osztályt.
Hazsnáljon NUnit és Moq keretrendszereket.

