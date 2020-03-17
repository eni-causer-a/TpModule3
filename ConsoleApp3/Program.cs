using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        static void Main(string[] args)
        {
            InitialiserDatas();
            var meceng = ListeAuteurs.Where(a => a.Nom.Substring(0, 1) == "G");

            Console.WriteLine("Ces personnes ont un nom qui commence par un G : \n");

            foreach (var mec in meceng)
            {
                Console.WriteLine($"{mec.Prenom}");
            }

            //2

            //var lePlusDeLivre = ListeAuteurs.Select(a => ListeLivres.Where(l => l.Auteur == a)).OrderByDescending(l => l.Count()).First() ;
            var lePlusDeLivre = ListeAuteurs.OrderByDescending(a => ListeLivres.Count(l => l.Auteur == a)).First();

            Console.WriteLine($"L'auteur ayant écrit le plus de livres {lePlusDeLivre.Nom}");

            //3

            var paquetsDeLivres = ListeAuteurs.Select(a => ListeLivres.Where(l => l.Auteur == a)).Where(p => p.Count() > 0);

            foreach( var paquetDeLivres in paquetsDeLivres)
            {
                var moyenne = 0;
                var cmpt = 0;
                var auteur = paquetDeLivres.First().Auteur.Nom;
                foreach (var livre in paquetDeLivres)
                {
                    moyenne += livre.NbPages;
                    cmpt++;
                }
                Console.WriteLine($"{auteur} a une moyenne de {moyenne / cmpt } pages par livres ");
            }

            //4

            var livrePlusPages = ListeLivres.OrderByDescending(l => l.NbPages).First();

            Console.WriteLine();
            Console.WriteLine($"Le livre avec le plus de pages : {livrePlusPages.Titre}");

            //5

            var moyenneTri = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));

            Console.WriteLine();
            Console.WriteLine($"La moyenne des gains est de  : {moyenneTri}");


            //6

            var livresParAuteur = ListeAuteurs.Select(a => ListeLivres.Where(l => l.Auteur == a)).Where(p => p.Count() > 0);

            foreach (var paquetDeLivres in paquetsDeLivres)
            {
                
                var auteur = paquetDeLivres.First().Auteur.Nom;
                Console.WriteLine($"Les livres de {auteur} : ");
                foreach (var livre in paquetDeLivres)
                {
                    Console.WriteLine(livre.Titre);
                }
            }

            //7

            var ordreAlphaLivres = ListeLivres.OrderBy(l => l.Titre);
            Console.WriteLine("Ordre Alphabetique : ");
            foreach(var livre in ordreAlphaLivres)
            {
                Console.WriteLine($"{livre.Titre}");
            }

            //8

            var moyenneBis = ListeLivres.Select(l => l.NbPages).Average();

            foreach (var livre in ListeLivres)
            {
                if (livre.NbPages > moyenneBis)
                {
                    Console.WriteLine($"Le livre {livre.Titre} a un nombre de pages supérieur à la moyenne qui est de {moyenneBis}");
                }
            }

            //9

            var dernierAuteur = ListeAuteurs.OrderBy(a => ListeLivres.Count(l => l.Auteur == a)).First();

            Console.WriteLine($"L'auteur qui a ecrit le moins de livre : {dernierAuteur.Nom}");


            //Read

            Console.ReadKey();


        }

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
