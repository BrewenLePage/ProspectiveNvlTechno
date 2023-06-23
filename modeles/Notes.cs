using System;
using dataAccess;
namespace modeles{
    public class Notes{
        public int idEleve{get;set;}
        public int idCours{get;set;}
        public int year{get;set;}
        public int session{get;set;}
        public int grade{get;set;}
        NotesDB ndb = new NotesDB();
        public Notes(){
            this.idEleve = 0;
            this.idCours = 0;
            this.year = 0;
            this.session = 0;
            this.grade = 0;
        }
        public Notes(int idEleve, int idCours, int year, int session, int grade)
        {
            this.idEleve = idEleve;
            this.idCours = idCours;
            this.year = year;
            this.session = session;
            this.grade = grade;
        }
        public Notes(int grade){
            this.grade = grade;
        }
          public void saveNotes(int idEleve, int idCours, int year, int session, int grade){
            ndb.saveNotes(idEleve,idCours,year,session,grade);
        }
        public Notes getNotesByIdEleve(int idEleve){
           return ndb.getNotesByIdEleve(idEleve);
        }
        public Notes getNotesByIdCours(int idCours){
            return ndb.getNotesByIdCours(idCours);
        }
        public void updateNotesEleve(int idEleve, int idCours, int year, int session, int grade){
            ndb.updateNotesEleve(idEleve,idCours,year,session,grade);
        }
        public void deleteNoteEleve(int idEleve, int idCours, int year, int session){
            ndb.deleteNoteEleve(idEleve,idCours,year,session);
        }
    }
}