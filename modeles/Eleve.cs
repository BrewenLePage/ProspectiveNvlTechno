using System;
using dataAccess;
namespace modeles{
    public class Eleve{
        public int id{set;get;}
        public string? name{set;get;}
        public string? address{set;get;}
        public string? telephone{set;get;}

        EleveDB edb = new EleveDB();
        public Eleve(){
            this.id = 0;
            this.name = "";
            this.address = "";
            this.telephone = "";
        }
        public Eleve(int id, string? name, string? address, string? telephone)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.telephone = telephone;
        }
        public Eleve(string? name, string? address, string? telephone)
        {
            this.name = name;
            this.address = address;
            this.telephone = telephone;
        }

        public void afficher(){
            Console.WriteLine("--Information sur l'éléve--");
            Console.WriteLine($"Id: {id} \n Nom: {name} \n"+
            $"Adresse: {address} \n Tel: {telephone}");
        }
        public void getListEleve(){
            edb.getListEleve();
        }
        public void save(string name, string address, string telephone){
            edb.save(name,address,telephone);
        }
        public Eleve getEleveById(int id){
            return edb.getEleveById(id);
        }
        public void deleteEleveById(int id){
            edb.deleteEleveById(id);
        }
        public void updateEleveById(int id,string name,string address,string telephone){
            edb.updateEleveById(id,name,address,telephone);
        }
    }
}