using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginWPF.Principal;

namespace LoginWPF.LogicaNegocio
{
    
    class UsuarioDAO
    {
     
        private readonly string conString;
 
        public UsuarioDAO()
        {
            conString = ConfigurationManager
                .ConnectionStrings["miconexion"].ConnectionString;
        }

        public int alta(Persona p)
        {
            int insertados = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "INSERT INTO USUARIOS(NOMBREUSUARIO, GENERO, EMAIL) " +
                    " VALUES ( @NOMBREUSUARIO, @GENERO, @EMAIL)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@NOMBREUSUARIO", p.Nombre));
                cmd.Parameters.Add(new SqlParameter("@GENERO", p.Genero));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", p.Email));
                con.Open();
                insertados = cmd.ExecuteNonQuery();                    
            }            
            return insertados;
        }

        public int actualizar(Persona p)
        {
            int actualizados = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "UPDATE USUARIOS SET NOMBREUSUARIO = @Nombre, " +
                    "GENERO = @Genero, EMAIL = @Email WHERE ID = @Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@Nombre", p.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Genero", p.Genero));
                cmd.Parameters.Add(new SqlParameter("@Email", p.Email));
                cmd.Parameters.Add(new SqlParameter("@Id", p.Id));
                con.Open();
                actualizados = cmd.ExecuteNonQuery();
            }
            return actualizados;
        }

        public int borrar(int id)
        {
            int borrados = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "DELETE FROM USUARIOS WHERE id = @Id ";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                con.Open();
                borrados = cmd.ExecuteNonQuery();
            }
            return borrados;
        }                  

        public ObservableCollection<Persona> listar()
        {
            ObservableCollection<Persona> lista =
                new ObservableCollection<Persona>();
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "SELECT * FROM USUARIOS";
                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.Parameters.Add(new SqlParameter("@username", username));
                con.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Persona p = new Persona()
                        {                           
                            Id = (int)dr["id"],
                            Nombre =  dr["NOMBREUSUARIO"] == DBNull.Value ? "": (string) dr["NOMBREUSUARIO"],
                            Email =   dr["EMAIL"] == DBNull.Value ? "": (string) dr["EMAIL"],
                            Genero =  dr["GENERO"] == DBNull.Value ? "" : (string)dr["GENERO"],
                            Password = dr["PASSWORD"] == DBNull.Value ? "" : (string)dr["PASSWORD"],
                            Activo =  dr["ACTIVO"] == DBNull.Value ? false : (bool) dr["ACTIVO"]
                        };                      
                        if (p.Genero == "Hombre")
                            {
                                p.ImagenGenero = "/LoginWPF;component/Imagenes/man.png";
                            }
                            else
                            {
                                p.ImagenGenero = "/LoginWPF;component/Imagenes/woman.png";
                            }                        
                        lista.Add(p);
                    }
                }                    
            }
            return lista;
        }


    }
}
