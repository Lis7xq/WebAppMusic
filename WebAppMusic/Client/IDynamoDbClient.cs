using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{
    public interface IDynamoDbClient
    {
        public Task<UserDbRepository> GetDataByID(string Tid);
        public Task<bool> PostDataToOb(UserDbRepository data);

        public Task UpdateDataIntoDb();

        public Task Delete();

        public Task<List<UserDbRepository>> GetAll();
    }
}
