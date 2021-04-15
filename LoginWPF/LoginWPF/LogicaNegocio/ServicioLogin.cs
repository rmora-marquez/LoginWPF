using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWPF.LogicaNegocio
{
    public class ServicioLogin
    {
        public bool Check(string username,string password)
        {
            if(username == "admin" && 
                password == "nimda")
            {
                return true;
            }
            return false;
        }

        public bool CheckAFile(string username, string password)
        {
            ///TODO CREAR EL METODO QUE LEA UN ARCHIVO
            ///AQUI YO REVISO UN ARCHIVO, Y VERFICO
            ///QUE USUARIO == USER DEL ARCHIVO
            ///PASS == PASS DEL ARCHIVO SI ES ASI TRUE,
            ///SINO MANDO FALSO
            return false;
        }

        public bool CheckBD(string username, string password)
        {
            string conString = ConfigurationManager
                .ConnectionStrings["miconexion"].ConnectionString;
            string sql = "SELECT * FROM dbo.usuarios " +
                "WHERE NombreUsuario = @username";
            bool login = false;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@username", username) );
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string pass = (string) dr["Password"];
                        if(pass == password)
                        {
                            login = true;
                        }                        
                    }
                }
            }
            return login;
        }
    }
}
