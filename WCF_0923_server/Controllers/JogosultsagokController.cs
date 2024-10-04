using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF_0923_server.DatabaseManager;
using WCF_0923_server.Models;

namespace WCF_0923_server.Controllers
{
    public class JogosultsagokController : BaseDatabaseManager, ISQL
    {
        public string Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM Jogosultsagok WHERE Id = @Id;",
                Connection = Connection
            };
            cmd.Parameters.Add(new MySqlParameter("@Id", id));

            try
            {
                cmd.Connection.Open();
                int toroltRekordok = cmd.ExecuteNonQuery();
                if (toroltRekordok == 0)
                    return $"Nem találtam ilyen azonosítót {id}";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba!" + ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            cmd.Parameters.Clear();
            return $"Sikeres törlés {id}";
        }

        public string Insert(Record record)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO Jogosultsagok (Szint, Nev, Leiras) VALUES (@Szint, @Nev, @Leiras)",
                Connection = Connection
            };
            Jogosultsagok ujJogosultsag = record as Jogosultsagok;
            cmd.Parameters.Add(new MySqlParameter("@Szint", ujJogosultsag.Szint));
            cmd.Parameters.Add(new MySqlParameter("@Nev", ujJogosultsag.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Leiras", ujJogosultsag.Leiras));

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return $"Nem sikerült rögzítenem a felhasználót! {ujJogosultsag.Nev}";
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Hiba történt a rögzítés során\n{ex.Message}");
            }
            finally
            {
                Connection.Close();
            }
            return "Sikeres rögzítés!";
        }

        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand() {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM Jogosultsagok;"
            };

            try
            {
                MySqlConnection conn = BaseDatabaseManager.Connection;
                conn.Open();
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Jogosultsagok ujJogosultsag = new Jogosultsagok(){
                        Id = reader.GetInt32("id"),
                        Szint = reader.GetInt32("Szint"),
                        Nev = reader.GetString("Nev"),
                        Leiras = reader.GetString("Leiras")
                    };
                    list.Add(ujJogosultsag);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt a beolvasáskor!\n{ex.Message}");
            }
            finally
            {
                BaseDatabaseManager.Connection.Close();
            }
            return list;
        }

        public string Update(Record record)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE Jogosultsagok SET Szint = @Szint, Nev = @Nev, Leiras = @Leiras WHERE Id = @Id",
                Connection = Connection
            };
            Jogosultsagok Jogosultsag = record as Jogosultsagok;
            cmd.Parameters.Add(new MySqlParameter("@Id", Jogosultsag.Id));
            cmd.Parameters.Add(new MySqlParameter("@Szint", Jogosultsag.Szint));
            cmd.Parameters.Add(new MySqlParameter("@Nev", Jogosultsag.Nev));
            cmd.Parameters.Add(new MySqlParameter("@Leiras", Jogosultsag.Leiras));

            try
            {
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return $"Nem sikerült frissíteni a felhasználót! {Jogosultsag.Nev}";
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Hiba történt a frissítés során\n{ex.Message}");
            }
            finally
            {
                Connection.Close();
            }
            return "Sikeres frissítés!";
        }
    }
}