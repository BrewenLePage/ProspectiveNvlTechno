using System;
using System.Collections.Generic;
using modeles;
using MySql.Data.MySqlClient;
namespace dataAccess{
    public class EleveDB{
        MySqlConnection connection = DataBase.connection;
        //public List<Eleve> getEleves()
        public void getListEleve(){
            try{
                string query ="SELECT * FROM eleve";
                MySqlCommand cmd= new MySqlCommand(query,connection);
                using MySqlDataReader lecteur = cmd.ExecuteReader();
                Console.WriteLine("--Liste des élèves--");
                while(lecteur.Read())
                {  
                    string id = lecteur["id"].ToString();
                    string name = lecteur["name"].ToString();
                    string address = lecteur["address"].ToString(); 
                    string telephone = lecteur["telephone"].ToString();
                    Console.WriteLine($"ID : {id}");
                    Console.WriteLine($"Name : {name}");
                    Console.WriteLine($"Adresse : {address}");
                    Console.WriteLine($"Téléphone : {telephone}");
                }
                lecteur.Close();
            }
            catch(Exception e){
                 Console.WriteLine("Error : "+ e.Message);
            }
        }
        // public void save(string name, string address, string telephone){
        //     //int etat = 0;
        //     try
        //     {
        //         string query = $"INSERT INTO eleve (name,address,telephone) VALUES ('{name}','{address}','{telephone}')";
        //         MySqlCommand cmd = new MySqlCommand(query,connection);
        //         cmd.ExecuteNonQuery();
        //         Console.WriteLine("------------------------");
        //         Console.WriteLine("Enregistrement réussi...");
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine("Error : "+ e.Message);
        //         //etat =  1;
        //     }
        //     //return etat;
        // }
        public void save(string name, string address, string telephone){
            //int etat = 0;
            try
            {
                string query = $"INSERT INTO eleve (name,address,telephone) VALUES (@name,@address,@telephone)";
                Dictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@name",name);
                parameters.Add("@address",address);
                parameters.Add("@telephone",telephone);
                MySqlCommand cmd = new MySqlCommand(query,connection);
                foreach(KeyValuePair<string,object> parameter in parameters){
                    cmd.Parameters.Add(new MySqlParameter(parameter.Key,parameter.Value));
                }
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                Console.WriteLine("------------------------");
                Console.WriteLine("Enregistrement réussi...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : "+ e.Message);
                //etat =  1;
            }
            //return etat;
        }
        public Eleve getEleveById(int id){
            Eleve e = new Eleve();
            try
            {
                string query =$"SELECT * FROM eleve WHERE id='{id}'"; 
                MySqlCommand cmd= new MySqlCommand(query,connection); 
                using MySqlDataReader lecteur = cmd.ExecuteReader();
                Console.WriteLine("--Eleve par ID--");
                while(lecteur.Read()){
                    e.id = int.Parse(lecteur["id"].ToString());
                    e.name = lecteur["name"].ToString();
                    e.address = lecteur["address"].ToString(); 
                    e.telephone = lecteur["telephone"].ToString();
                    Console.WriteLine($"ID : {e.id}");
                    Console.WriteLine($"Name : {e.name}");
                    Console.WriteLine($"Adresse : {e.address}");
                    Console.WriteLine($"Téléphone : {e.telephone}");
                }
                lecteur.Close();
            }
           catch (Exception ex)
            {
                Console.WriteLine("Error : "+ ex.Message);
            }
            return e;
        }
        public void deleteEleveById(int id){
            try
            {
                string query =$"DELETE FROM eleve WHERE id=@id";
                Dictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@id",id);
                MySqlCommand cmd= new MySqlCommand(query,connection);
                foreach(KeyValuePair<string,object> parameter in parameters){
                    cmd.Parameters.Add(new MySqlParameter(parameter.Key,parameter.Value));
                }
                cmd.ExecuteReader();
                Console.WriteLine("--Suppression réussie !--");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : "+ e.Message);
            }
        }
        public void updateEleveById(int id,string name,string address,string telephone){
            try
            {
                string query =$"UPDATE eleve SET name=@name,address=@address,telephone=@telephone WHERE id=@id"; 
                Dictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@id",id);
                parameters.Add("@name",name);
                parameters.Add("@address",address);
                parameters.Add("@telephone",telephone);
                MySqlCommand cmd= new MySqlCommand(query,connection);
                foreach(KeyValuePair<string,object> parameter in parameters){
                    cmd.Parameters.Add(new MySqlParameter(parameter.Key,parameter.Value));
                }
                cmd.ExecuteNonQuery();
                Console.WriteLine("--Modification ok--");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : "+ e.Message);
            }
        }
    }
}