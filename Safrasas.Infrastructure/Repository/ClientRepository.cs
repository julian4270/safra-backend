using Safrasas.Application.Interfaces;
using Safrasas.Core.Entities;
using Safrasas.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Safrasas.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration configuration;

        #endregion

        #region ===[ Constructor ]=================================================================

        public ClientRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region ===[ IClientRepository Methods ]==================================================

        public async Task<IReadOnlyList<Clients>> GetAllAsync()
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Clients>(ClientsQuery.AllClient);
                return result.ToList();
            }
        }

        public async Task<Clients> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Clients>(ClientsQuery.ClientById, new { ClientId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Clients entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ClientsQuery.AddClient, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(Clients entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ClientsQuery.UpdateClient, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(ClientsQuery.DeleteClient, new { ClientId = id });
                return result.ToString();
            }
        }

        #endregion
    }
}
