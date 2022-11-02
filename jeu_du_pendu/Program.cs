using System;
using AsciiArt;

namespace jeu_du_pendu // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void AfficherMot(string mot, List<char> lettres)
        {

            for (int i = 0; i < mot.Length; i++)
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

        static bool ToutesLettresDevinees(string mot, List<char> lettres)
        {
            //si true toutes les lettres ont été trouvées
            foreach (var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }

            if (mot.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            var lettresOut = new List<char>();
            const int VIES = 6;
            int vieRestantes = VIES;

            while (vieRestantes > 0)
            {
                Console.WriteLine(Ascii.PENDU[VIES - vieRestantes]);
                Console.WriteLine();
                AfficherMot(mot, lettreDevinees);
                Console.WriteLine();
                var lettre = DemanderLettre();
                Console.Clear();
                if (mot.Contains(lettre))
                {
                    Console.WriteLine("cette lettre est dans le mot");
                    lettreDevinees.Add(lettre);
                    if (ToutesLettresDevinees(mot, lettreDevinees))
                    {
                        break;
                    };
                }
                else
                {
                    if (!lettresOut.Contains(lettre))
                    {
                        vieRestantes--;
                        lettresOut.Add(lettre);
                    }

                    Console.WriteLine($"Il vous reste {vieRestantes} vies");

                }
                if (lettresOut.Count > 0)
                {
                    Console.WriteLine($"Le mot ne contient pas les lettres {String.Join(", ", lettresOut)}");
                }

                Console.WriteLine();
            }

            Console.WriteLine(Ascii.PENDU[VIES - vieRestantes]);
            if (vieRestantes == 0)
            {
                Console.WriteLine($"Vous avez perdu, le mot était {mot}");
            }
            else
            {//pour faire beau
                AfficherMot(mot, lettreDevinees);
                Console.WriteLine();
                Console.WriteLine("Vous avez gagné");
            }


        }

        static string[] ChargerLesMots(string nomFichier)
        {
            try
            {
                return File.ReadAllLines(nomFichier);
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine($"Erreur: {ex.Message}");
                }
                return null;
            }
        }

        static bool DemanderRejouer()
        {
            Console.WriteLine("Voulez vous rejouer o/n ?");
            char reponse = DemanderLettre();
            if((reponse == 'o')||(reponse == 'O')){
                return true;
            }
            else if((reponse == 'n')|| (reponse == 'N')){
                return false;
            }
            else
            {
                Console.WriteLine("Erreur vous devez répondre o/n");
                return DemanderRejouer();
            }

        }
            static void Main(string[] args)
            {

                var mots = ChargerLesMots("mots.txt");

            if((mots == null) || (mots.Length) == 0)
            {
                Console.WriteLine("la liste de mots est vide");
            }
            else
            {
                while (true) {
                    Random r = new Random();
                    int i = r.Next(mots.Length);
                    string mot = mots[i].Trim().ToUpper();
                    DevinerMot(mot);

                    if (!DemanderRejouer())
                    {
                        break;
                    }
                    Console.Clear();
                }
                Console.WriteLine("Merci et à bientot ! Toto");
                

            }
                
                //char lettre = DemanderLettre();
                //AfficherMot(mot, new List<char> {lettre});
            }
        
    
    }
}