using System;
using modeles;
namespace vues{
    public class EleveVue{
        Eleve e = new Eleve();
        public void save(){
            Console.WriteLine("--Enregistrement d'un éléve--");

            Console.Write("Nom : " );  string name=Console.ReadLine();
            Console.Write("Adresse : ");  string address=Console.ReadLine();
            Console.Write("Tel : ");  string telephone=Console.ReadLine();
            Eleve e = new Eleve(name,address,telephone);
            e.save(name,address,telephone);
        }
        public void getListEleve(){
            e.getListEleve();
        }
        
        public void getEleveById(){
            Console.Write("Id de l'élève : " );
            int id=int.Parse(Console.ReadLine());
            e.getEleveById(id);
        }
          public void deleteEleveById(){
            Console.Write("Id de l'élève : " );
            int id=int.Parse(Console.ReadLine());
            e.deleteEleveById(id);
        }
         public void updateEleveById(){
             Console.WriteLine("--Modification d'un élève par ID--" );
            Console.Write("Id de l'élève : " );int id=int.Parse(Console.ReadLine());
            e=e.getEleveById(id);
            if(e.id!=0){
                Console.WriteLine("--Nouvelles infos--" );
                Console.Write("Nom : " );  string name=Console.ReadLine();
                if(name==""){
                    name=e.name;
                }
                Console.Write("Adresse : ");  string address=Console.ReadLine();
                if(address==""){
                    address=e.address;
                }
                Console.Write("Tel : ");  string telephone=Console.ReadLine();
                if(telephone==""){
                    telephone=e.telephone;
                }
                e = new Eleve(name,address,telephone);
                e.updateEleveById(id,name,address,telephone);
            }
            else{
                Console.Write($"Aucun élève avec l'ID : {id}");
            }
        }
    }
}