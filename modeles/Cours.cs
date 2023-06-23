using System;
using dataAccess;
namespace modeles{
    public class Cours{
        public int id{get;set;}
        public string name_cours{get;set;}
        public int coef_cours{get;set;}
        CoursDB cdb = new CoursDB();
        public Cours(){
            this.id = 0;
            this.name_cours = "";
            this.coef_cours = 0;
        }
        public Cours(string? name_cours, int coef_cours)
        {
            this.name_cours = name_cours;
            this.coef_cours = coef_cours;
        }
        public void saveCours(string name_cours, int coef_cours){
            cdb.saveCours(name_cours, coef_cours);
        }
        public Cours getCoursById(int id){
            return cdb.getCoursById(id);
        }
        public void deleteCoursById(int id){
            cdb.deleteCoursById(id);
        }
        public void updateCoursById(int id,string name_cours,int coef_cours){
            cdb.updateCoursById(id,name_cours,coef_cours);
        }
    }
}