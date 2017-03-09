namespace GameFifteen.UserInteraction
{
    using System;

    public class MatrixUserInterface : UserInterface
    {
        private static MatrixUserInterface singleInstance;

        private MatrixUserInterface()
        {
        }

        public static UserInterface GetInstance()
        {
            if (singleInstance == null)
            {
                singleInstance = new MatrixUserInterface();
            }

            return singleInstance;
        }

        public override string ReadLine()
        {
            return Console.ReadLine();
        }

        public override void Write(object data, params object[] arguments)
        {
            if (arguments.Length > 0)
            {
                Console.Write(data.ToString(), arguments);
            }
            else
            {
                Console.Write(data);
            }
        }

        public override void WriteLine(object data, params object[] arguments)
        {
            if (arguments.Length > 0)
            {
                Console.WriteLine(data.ToString(), arguments);
            }
            else
            {
                Console.WriteLine(data);
            }
        }
    }
}
