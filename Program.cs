// See https://aka.ms/new-console-template for more information
using System;
using vues;
using dataAccess;
namespace  monApp
{
    public class Program{
        private static void elevesSwitch()
        {
            Console.WriteLine("--Gestion des étudiants--");
            Console.Write("1-Enregistrement \n2-Liste des éléves \n3-Recherche \n4-Suppression \n5-Update \nChoix : ");
            int choix = int.Parse(Console.ReadLine());
            EleveVue ev = new EleveVue();

            switch (choix)
            {
                case 1:
                    ev.save();
                    break;

                case 2:
                    ev.getListEleve();
                    break;

                case 3:
                    ev.getEleveById();
                    break;

                case 4:
                    ev.deleteEleveById();
                    break;

                case 5:
                    ev.updateEleveById();
                    break;
                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }
        }
        private static void coursSwitch()
        {
            Console.WriteLine("--Gestion des cours--");
            Console.Write("1-Enregistrement \n2-Liste des cours \n3-Recherche \n4-Suppression \n5-Update \nChoix : ");
            int choix = int.Parse(Console.ReadLine());
            CoursVue cv = new CoursVue();

            switch (choix)
            {
                case 1:
                    cv.saveCours();
                    break;

                case 2:
                    cv.getCoursById();
                    break;

                case 3:
                    cv.deleteCoursById();
                    break;

                case 4:
                    cv.updateCoursById();
                    break;
                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }
        }

        private static void notesSwitch()
        {
            Console.WriteLine("--Gestion des notes--");
            Console.Write("1-Enregistrement \n2-Liste des notes \n3-Recherche \n4-Suppression \n5-Update \nChoix : ");
            int choix = int.Parse(Console.ReadLine());
            NotesVue nv = new NotesVue();

            switch (choix)
            {
                case 1:
                    nv.saveNotes();
                    break;

                case 2:
                    nv.getNotesByIdCours();
                    break;
                case 3:
                    nv.getNotesByIdEleve();
                    break;

                case 4:
                    nv.updateNotesEleve();
                    break;
                case 5:
                    nv.deleteNoteEleve();
                    break;
                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("--Menu Principal--");
            Console.Write("1-Etudiant \n2-Cours \n3-Note \nChoix : ");
            int choix = int.Parse(Console.ReadLine());
            DataBase.connecter();
            DataBase.getDBVersion();
            switch (choix)
            {
                case 1:
                    elevesSwitch();
                    break;

                case 2:
                    coursSwitch();
                    break;

                case 3:
                    notesSwitch();
                    break;
                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }
            DataBase.deconnecter();
        }
        }
    }
