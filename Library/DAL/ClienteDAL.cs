using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ClienteDAL
    {
        
            public static int Insert(Cliente c)
            {

                using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("INSERT INTO cadastro_cliente ");
                    sql.AppendLine("(id_cliente,nome_cliente,rg_cliente,cpf_cliente,endereco_cliente,telefone_cliente,email_cliente) ");
                    sql.AppendLine("VALUES (@id_cliente,@nome_cliente,@rg_cliente,@cpf_cliente,@endereco_cliente,@telefone_cliente,@email_cliente) ");
                    sql.AppendLine("SELECT SCOPE_IDENTITY(); ");//Linha Responsável por retornar id que foi Inserido

                    using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_cliente", c.Id_cliente);
                        cmd.Parameters.AddWithValue("@nome_cliente", c.Nome_cliente);
                        cmd.Parameters.AddWithValue("@rg_cliente", c.Rg_cliente);
                        cmd.Parameters.AddWithValue("@cpf_cliente", c.Cpf_cliente);
                        cmd.Parameters.AddWithValue("@endereco_cliente", c.Endereco_cliente);
                        cmd.Parameters.AddWithValue("@telefone_cliente", c.Telefone_cliente);
                        cmd.Parameters.AddWithValue("@email_cliente", c.Email_cliente);

                        con.Open();
                        c.Id_cliente = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return c.Id_cliente;
            }

            public static int Update(Cliente c)
            {
                int linhasAfetadas = 0;
                using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("UPDATE cadastro_cliente SET ");
                    sql.AppendLine("id_cliente = @id_cliente, ");
                    sql.AppendLine("nome_cliente = @nome_cliente, ");
                    sql.AppendLine("rg_cliente = @rg_cliente, ");
                    sql.AppendLine("cpf_cliente = @cpf_cliente, ");
                    sql.AppendLine("endereco_cliente = @endereco_cliente ");
                    sql.AppendLine("telefone_cliente = @telefone_cliente ");
                    sql.AppendLine("email_cliente = @email_cliente ");
                    sql.AppendLine("WHERE id_cliente = @id_cliente ");

                    using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_cliente", c.Id_cliente);
                        cmd.Parameters.AddWithValue("@nome_cliente", c.Nome_cliente);
                        cmd.Parameters.AddWithValue("@rg_cliente", c.Rg_cliente);
                        cmd.Parameters.AddWithValue("@cpf_cliente", c.Cpf_cliente);
                        cmd.Parameters.AddWithValue("@endereco_cliente", c.Endereco_cliente);
                        cmd.Parameters.AddWithValue("@telefone_cliente", c.Telefone_cliente);
                        cmd.Parameters.AddWithValue("@email_cliente", c.Email_cliente);
                        //cmd.Parameters.AddWithValue("@ID", c.Id_cliente);

                        con.Open();
                        linhasAfetadas = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return linhasAfetadas;
            }

            public static int Delete(int id)
            {
                int linhasAfetadas = 0;
                using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
                {
                    string sql = "DELETE FROM cadastro_cliente WHERE id_cliente = @id_cliente";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id_cliente", id);

                        con.Open();
                        linhasAfetadas = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    return linhasAfetadas;
                }
            }

            public static List<Cliente> GetAll()
            {
                List<Cliente> listaProjetos = new List<Cliente>();
                using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
                {
                    con.Open();

                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT a.id_cliente,a.nome_cliente,a.rg_cliente,a.cpf_cliente,a.endereco_cliente,a.telefone_cliente,a.email_cliente");
                    sql.AppendLine("FROM cadastro_cliente a ");
                    /*sql.AppendLine("WHERE a.FL_ATIVO = 1 ");*/
                    sql.AppendLine("ORDER BY a.nome_cliente ");

                    using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    Cliente c = new Cliente();//Instanciando o objeto da iteração
                                                              //Preenchimento das propriedades a partir do que retornou no banco.
                                    c.Id_cliente = Convert.ToInt32(dr["id_cliente"]);
                                    c.Nome_cliente = dr["nome_cliente"].ToString();
                                    c.Cpf_cliente = dr["cpf_Cliente"].ToString();
                                    c.Rg_cliente = dr["rg_cliente"].ToString();
                                    c.Endereco_cliente = dr["endereco_cliente"].ToString();
                                    c.Telefone_cliente = Convert.ToInt32(dr["telefone_cliente"]);
                                    c.Email_cliente = dr["email_cliente"].ToString();

                                    listaProjetos.Add(c);//Adicionando o objeto para a lista
                                }
                            }
                        }
                    }
                }
                return listaProjetos;
            }

            public static Cliente GetById(int id)
            {
                Cliente c = null;

                using (SqlConnection con = new SqlConnection(ConnectionFactory.GetStringConexao()))
                {
                    con.Open();

                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT a.id_cliente,a.nome_cliente,a.rg_cliente,a.cpf_cliente,a.endereco_cliente,a.telefone_cliente,a.email_cliente");
                    sql.AppendLine("FROM cadastro_cliente a ");
                    sql.AppendLine("WHERE a.id_cliente = @id_cliente ");
                    sql.AppendLine("ORDER BY a.nome_cliente ");


                    using (SqlCommand cmd = new SqlCommand(sql.ToString(), con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", id); //Passagem de parametro

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                if (dr.Read())
                                {
                                    c = new Cliente();//Instanciando o objeto da iteração
                                                      //Preenchimento das propriedades a partir do que retornou no banco.
                                    c.Id_cliente = Convert.ToInt32(dr["id_cliente"]);
                                    c.Nome_cliente = dr["nome_cliente"].ToString();
                                    c.Rg_cliente = dr["rg_cliente"].ToString();
                                    c.Cpf_cliente = dr["cpf_cliente"].ToString();
                                    c.Telefone_cliente = Convert.ToInt32(dr["telefone_cliente"]);
                                    c.Endereco_cliente = dr["endereco_cliente"].ToString();
                                    c.Email_cliente = dr["email_cliente"].ToString();

                                }
                            }
                        }
                    }
                }
                return c;
            }
        }
    }

