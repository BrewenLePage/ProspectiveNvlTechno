using System;
using modeles;
namespace vues{
    public  class NotesVue{
        Notes n = new Notes();
        public void saveNotes(){
            Console.WriteLine("--Enregistrement d'une note--");

            Console.Write("Id élève : " );  int idEleve=int.Parse(Console.ReadLine());
            Console.Write("Id cours : ");  int idCours=int.Parse(Console.ReadLine());
            Console.Write("Année : ");  int year=int.Parse(Console.ReadLine());
            Console.Write("Session : ");  int session=int.Parse(Console.ReadLine());
            Console.Write("Note : ");  int note=int.Parse(Console.ReadLine());
            Notes n = new Notes(idEleve,idCours,year,session,note);
            n.saveNotes(idEleve,idCours,year,session,note);
        }
        public void getNotesByIdEleve(){
            Console.Write("Id de l'élève : " );
            int idEleve=int.Parse(Console.ReadLine());
            n.getNotesByIdEleve(idEleve);
        }
        public void getNotesByIdCours(){
            Console.Write("Id du Cours : " );
            int idCours=int.Parse(Console.ReadLine());
            n.getNotesByIdCours(idCours);
        }
        public void updateNotesEleve(){
            Console.WriteLine("--Modification d'une Note d'un élève--" );
            Console.Write("Id de l'élève : " ); int idEleve=int.Parse(Console.ReadLine());
            Console.Write("Id du cours : " );   int idCours=int.Parse(Console.ReadLine());
            Console.Write("Année : " ); int year=int.Parse(Console.ReadLine());
            Console.Write("session: " );    int session=int.Parse(Console.ReadLine());
            n=n.getNotesByIdEleve(idEleve);
            if(n.idEleve!=0){
                Console.WriteLine("--Nouvelle note--" );
                Console.Write("Note : " );  int grade=int.Parse(Console.ReadLine());
                if(grade!=grade){
                    grade=n.grade;
                }
                n = new Notes(grade);
                n.updateNotesEleve(idEleve,idCours,year,session,grade);
            }
            else{
                Console.Write($"Aucune notes dans le cours {idCours} pour l'élève {idEleve}");
            }
        }
        public void deleteNoteEleve(){
            Console.Write("Id de l'élève : " );
            int idEleve=int.Parse(Console.ReadLine());
            Console.Write("Id du cours : " );
            int idCours=int.Parse(Console.ReadLine());
            Console.Write("Année : " );
            int year=int.Parse(Console.ReadLine());
            Console.Write("Session : " );
            int session=int.Parse(Console.ReadLine());
            n.deleteNoteEleve(idEleve,idCours,year,session);
        }
    }
}