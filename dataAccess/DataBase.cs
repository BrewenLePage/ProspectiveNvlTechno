using System;
using MySql.Data.MySqlClient;
namespace dataAccess
{
    public class DataBase{
        public static string cs = "server=localhost;port=3306;userid=root;password=;database=ecole";
        public static MySqlConnection connection = new MySqlConnection(cs);
        public static void connecter(){
            try{
            Console.WriteLine("ouverture de la connexion...");
            connection.Open();
            Console.WriteLine("Connexion réussie!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error : "+ e.Message);
            }
        }
        public static void getDBVersion(){
            Console.WriteLine($"MySql Version :  {connection.ServerVersion}");
        }
        public static void deconnecter(){
            connection.Close();
            Console.WriteLine("Déconnexion réussie!");
        }
    }
}