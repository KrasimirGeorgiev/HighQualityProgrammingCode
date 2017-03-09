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

