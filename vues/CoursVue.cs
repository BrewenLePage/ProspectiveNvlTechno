using System;
using modeles;
namespace vues{
    public class CoursVue{
        Cours c = new Cours();
         public void saveCours(){
            Console.WriteLine("--Enregistrement d'un cours--");

            Console.Write("Nom : " );  string name_cours=Console.ReadLine();
            Console.Write("Coef du cours : ");  int coef_cours=int.Parse(Console.ReadLine());
            Cours c = new Cours(name_cours,coef_cours);
            c.saveCours(name_cours,coef_cours);
        }
        public void getCoursById(){
            Console.Write("Id du cours : " );
            int id=int.Parse(Console.ReadLine());
            c.getCoursById(id);
        }
        public void deleteCoursById(){
            Console.Write("Id du cours : " );
            int id=int.Parse(Console.ReadLine());
            c.deleteCoursById(id);
        }
         public void updateCoursById(){
             Console.WriteLine("--Modification d'un cours par ID--" );
            Console.Write("Id du cours : " );int id=int.Parse(Console.ReadLine());
            c=c.getCoursById(id);
            if(c.id!=0){
                Console.WriteLine("--Nouvelles infos--" );
                Console.Write("Nom : " );  string name_cours=Console.ReadLine();
                if(name_cours==""){
                    name_cours=c.name_cours;
                }
                Console.Write("Coef (mettre à 0 si pas de changement): ");  int coef_cours=int.Parse(Console.ReadLine());
                if(coef_cours==0){
                    coef_cours=c.coef_cours;
                }
                c = new Cours(name_cours,coef_cours);
                c.updateCoursById(id,name_cours,coef_cours);
            }
            else{
                Console.Write($"Aucun cours avec l'ID : {id}");
            }
        }
    }
}