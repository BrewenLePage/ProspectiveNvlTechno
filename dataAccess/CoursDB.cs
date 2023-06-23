using System;
using modeles;
using MySql.Data.MySqlClient;
namespace dataAccess{
    public class CoursDB{
       MySqlConnection connection = DataBase.connection;
       public void saveCours(string name_cours, int coef_cours){
            //int etat = 0;
            try
            {
                string query = $"INSERT INTO cours (name_cours,coef_cours) VALUES (@name_cours,@coef_cours)";
                Dictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@name_cours",name_cours);
                parameters.Add("@coef_cours",coef_cours);
                MySqlCommand cmd = new MySqlCommand(query,connection);
                foreach(KeyValuePair<string,object> parameter in parameters){
                    cmd.Parameters.Add(new MySqlParameter(parameter.Key,parameter.Value));
                }
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
       public Cours getCoursById(int id){
        Cours c = new Cours();
            try
            {
                string query =$"SELECT * FROM cours WHERE id='{id}'"; 
                MySqlCommand cmd= new MySqlCommand(query,connection); 
                using MySqlDataReader lecteur = cmd.ExecuteReader();
                Console.WriteLine("--Cours par ID--");
                while(lecteur.Read()){
                    c.id = int.Parse(lecteur["id"].ToString());
                    c.name_cours = lecteur["name_cours"].ToString();
                    c.coef_cours = int.Parse(lecteur["coef_cours"].ToString());
                    Console.WriteLine($"ID : {c.id}");
                    Console.WriteLine($"Nom du cours : {c.name_cours}");
                    Console.WriteLine($"Coef du cours : {c.coef_cours}");
                }
                lecteur.Close();
            }
           catch (Exception ex)
            {
                Console.WriteLine("Error : "+ ex.Message);
            }
            return c;
       }
        public void deleteCoursById(int id){
            try
            {
                string query =$"DELETE FROM cours WHERE id=@id"; 
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
        public void updateCoursById(int id,string name_cours,int coef_cours){
            try
            {
                string query =$"UPDATE cours SET name_cours=@name_cours,coef_cours=@coef_cours WHERE id=@id";
                Dictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@id",id);
                parameters.Add("@name_cours",name_cours);
                parameters.Add("@coef_cours",coef_cours);
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