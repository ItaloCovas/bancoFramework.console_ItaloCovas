using Dapper;
using Domain.Model;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private IDbConnection _db;

        public ClienteRepository()
        {
            _db = new SqlConnection(@"Server=localhost;Database=BancoFramework;User Id=SA;Password=BancoFramework123#;");
        }


        public Cliente Get(int id)
        {
            return _db.QuerySingleOrDefault<Cliente>("SELECT * FROM Cliente WHERE Id = @Id", new { Id = id });
        }

        public void Insert(Cliente cliente)
        {
            string sql = "INSERT INTO Cliente(Id, Nome, Cpf, Saldo) VALUES (@Id, @Nome, @Cpf, @Saldo)";
            _db.Execute(sql, cliente);
        }

        public void Update(Cliente cliente)
        {
            string sql = "UPDATE Cliente SET Id = @Id, Nome = @Nome, Cpf = @CPF, Saldo = @Saldo WHERE Id = @Id";
            _db.Execute(sql, cliente);
        }
    }
}
