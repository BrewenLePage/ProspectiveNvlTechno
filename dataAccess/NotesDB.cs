using System;
using modeles;
using MySql.Data.MySqlClient;
namespace dataAccess{
    public class NotesDB{
         MySqlConnection connection = DataBase.connection;
          public void saveNotes(int idEleve, int idCours, int year, int session, int grade){
            //int etat = 0;
            try
            {
                string query = $"INSERT INTO notes (idEleve,idCours,year,session,grade) VALUES (@idEleve,@idCours,@year,@session,@grade)";
                Dictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@idEleve",idEleve);
                parameters.Add("@idCours",idCours);
                parameters.Add("@year",year);
                parameters.Add("@session",session);
                parameters.Add("@grade",grade);
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
        public Notes getNotesByIdEleve(int idEleve){
            Notes n = new Notes();
            try
            {
                string query =$"SELECT * FROM notes WHERE idEleve='{idEleve}'"; 
                MySqlCommand cmd= new MySqlCommand(query,connection); 
                using MySqlDataReader lecteur = cmd.ExecuteReader();
                Console.WriteLine("--Notes par ID d'élève--");
                while(lecteur.Read()){
                    n.idEleve = int.Parse(lecteur["idEleve"].ToString());
                    n.idCours = int.Parse(lecteur["idCours"].ToString());
                    n.year = int.Parse(lecteur["year"].ToString());
                    n.session = int.Parse(lecteur["session"].ToString());
                    n.grade = int.Parse(lecteur["grade"].ToString());
                    Console.WriteLine($"ID de l'élève : {n.idEleve}");
                    Console.WriteLine($"ID du cours : {n.idCours}");
                    Console.WriteLine($"Année : {n.year}");
                    Console.WriteLine($"Session : {n.session}");
                    Console.WriteLine($"Notes : {n.grade}");
                }
                lecteur.Close();
            }
           catch (Exception ex)
            {
                Console.WriteLine("Error : "+ ex.Message);
            }
            return n;
        }
        public Notes getNotesByIdCours(int idCours){
            Notes n = new Notes();
            try
            {
                string query =$"SELECT * FROM notes WHERE idCours='{idCours}'"; 
                MySqlCommand cmd= new MySqlCommand(query,connection); 
                using MySqlDataReader lecteur = cmd.ExecuteReader();
                Console.WriteLine("--Notes par ID du cours--");
                while(lecteur.Read()){
                    n.idEleve = int.Parse(lecteur["idEleve"].ToString());
                    n.idCours = int.Parse(lecteur["idCours"].ToString());
                    n.year = int.Parse(lecteur["year"].ToString());
                    n.session = int.Parse(lecteur["session"].ToString());
                    n.grade = int.Parse(lecteur["grade"].ToString());
                    Console.WriteLine($"ID de l'élève : {n.idEleve}");
                    Console.WriteLine($"ID du cours : {n.idCours}");
                    Console.WriteLine($"Année : {n.year}");
                    Console.WriteLine($"Session : {n.session}");
                    Console.WriteLine($"Notes : {n.grade}");
                }
                lecteur.Close();
            }
           catch (Exception ex)
            {
                Console.WriteLine("Error : "+ ex.Message);
            }
            return n;
        }
        public void updateNotesEleve(int idEleve, int idCours, int year, int session, int grade){
            try
            {
                string query =$"UPDATE notes SET grade=@grade WHERE idEleve=@idEleve AND idCours=@idCours AND year=@year AND session=@session ";
                Dictionary<string,object> parameters = new Dictionary<string, object>();
                parameters.Add("@idEleve",idEleve);
                parameters.Add("@idCours",idCours);
                parameters.Add("@year",year);
                parameters.Add("@session",session);
                parameters.Add("@grade",grade);
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
        public void deleteNoteEleve(int idEleve, int idCours, int year, int session){
            try
            {
                string query =$"DELETE FROM notes WHERE idEleve={idEleve} AND idCours={idCours} AND year={year} AND session={session}"; 
                MySqlCommand cmd= new MySqlCommand(query,connection); 
                cmd.ExecuteReader();
                Console.WriteLine("--Suppression réussie !--");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : "+ e.Message);
            }
        }
    }
}