using System;

namespace ChangeMe
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        static void Main(string[] args)
        {
            using (MainMenu game = new MainMenu())
            {
                game.Run();
            }
        }
    }
#endif
}

