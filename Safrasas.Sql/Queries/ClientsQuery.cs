using System.Diagnostics.CodeAnalysis;

namespace Safrasas.Sql.Queries
{
    [ExcludeFromCodeCoverage]
	public static class ClientsQuery
	{
		public static string AllClient => "SELECT * FROM [Clients] (NOLOCK)";

		public static string ClientById => "SELECT * FROM [Clients] (NOLOCK) WHERE [ClientId] = @ClientId";

		public static string AddClient =>
            @"INSERT INTO [Clients] ([FirstName], [LastName], [Email], [Document]) 
				VALUES (@FirstName, @LastName, @Email, @Document)";

		public static string UpdateClient =>
			@"UPDATE [Clients] 
            SET [FirstName] = @FirstName, 
				[LastName] = @LastName, 
				[Email] = @Email, 
				[Document] = @Document
            WHERE [ClientId] = @ClientId";

		public static string DeleteClient => "DELETE FROM [Clients] WHERE [ClientId] = @ClientId";
	}
}
