using Hangman_.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_.DAL
{
    public class DbRepository
    {
        private readonly string _connectionString;

        public DbRepository()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<DbRepository>().Build();
            _connectionString = config.GetConnectionString("develop");
        }

        public async Task<IEnumerable<string>> GetListFromChosenTheme(string theme)
        {
            List<string> wordsByTheme = new List<string>();

            string stmt = $"select {theme} from list_of_words";
            await using var dataSource = NpgsqlDataSource.Create(_connectionString);
            await using var command = dataSource.CreateCommand(stmt);
            await using var reader = await command.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                if (!reader.IsDBNull(0))
                {
                    wordsByTheme.Add(reader.GetString(0));
                }
            }
            return wordsByTheme;
        }
    }
}
