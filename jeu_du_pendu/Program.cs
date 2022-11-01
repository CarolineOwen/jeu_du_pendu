using System;

namespace jeu_du_pendu // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void AfficherMot(string mot, List<char> lettres)
        {
            
            for(int i=0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
              
            }
            Console.WriteLine();
        }

        static char DemanderLettre()
        {
            while (true)
            {
                Console.WriteLine("Renseignez une lettre");
                string reponse = Console.ReadLine();
                if (reponse.Length == 1)
                {
                    reponse = reponse.ToUpper();
                    return reponse[0];
                }
                Console.WriteLine("Erreur: Vous devez rentrer une lettre");
            }
        }
        static void DevinerMot(string mot)
        {
            var lettreDevinees = new List<char>();

            while (true) {
                AfficherMot(mot, lettreDevinees);
                Console.WriteLine( );
                var lettre = DemanderLettre();
                Console.Clear();
                if (mot.Contains(lettre))
                {
                    Console.WriteLine("cette lettre est dans le mot");
                    lettreDevinees.Add(lettre);
                }
                else
                {
                    Console.WriteLine("cette lettre n'est pas dans le mot");
                }
                Console.WriteLine();
            }
            

        }
        static void Main(string[] args)
        {
            string mot = "ELEPHANT";

            DevinerMot(mot);
            //char lettre = DemanderLettre();
            //AfficherMot(mot, new List<char> {lettre});
        }
    }
}