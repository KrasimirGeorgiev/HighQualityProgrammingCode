# Шаблони за създаване

## Singleton

Singleton е клас който трябва да има само една инстанция от себе си и трябва да бъде създаден по такъв начин, че да не бъде възможно да се създаде друга инстанция от този клас. В Singleton се имплементира друг шаблон наречен Lazy Initialization - създава се така че да се инстанцира тогава когато за първи път бъде необходим.

Този шаблон се използва там където е необходима само една инстанция от създавания клас примерно ако класът е конзола.

## Диаграма:

![alt text](./singleton.png "Singleton Pattern")  

---

## Демо Код:

```C#
public class Console
{
    private static Console singleton;

    // Constructor should be set private or protected even if it's empty
    private Console()
    {
    }

    public static Console GetConsole()
    {
        // Lazy Initialization
        if (singleton == null)
        {
            singleton = new Console();
        }

        return singleton;
    }
}
```