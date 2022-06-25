using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMusic.Extensions;
using WebAppMusic.Models;

namespace WebAppMusic.Client
{
    public class DynamoDbClient : IDynamoDbClient, IDisposable
    {

        public string _tableName;
        private readonly IAmazonDynamoDB _dynamoDB;

        public DynamoDbClient(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDB = dynamoDB;
            _tableName = Constants.TableName;
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDbRepository> GetDataByID(string Tid)
        {


            var item = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"Tid", new AttributeValue{S = Tid}}
                    }
            };

            var responce = await _dynamoDB.GetItemAsync(item);

            if (responce.Item == null || !responce.IsItemSet)
                return null;

            var result = responce.Item.ToClass<UserDbRepository>();

            return result;
        }

        public async Task<bool> PostDataToOb(UserDbRepository data)
        {
            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"Tid", new AttributeValue{S = data.Tid} },
                    {"ArtistName", new AttributeValue{S = data.ArtistName} },
                    {"SongName", new AttributeValue{S = data.SongName} },
                    {"SpotUrl", new AttributeValue{S = data.SpotUrl} }
                }
            };

            try
            {
                var responce = await _dynamoDB.PutItemAsync(request);
                return responce.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }

            catch(Exception e)
            {
                Console.WriteLine("Incorrect input \n " + e);
                return false;
            }
        }


        public Task UpdateDataIntoDb()
        {
            throw new NotImplementedException();
        }

        public async Task <List<UserDbRepository>> GetAll()
        {
            var result = new List<UserDbRepository>();

            var request = new ScanRequest
            {
                TableName = _tableName,
            };

            var responce = await _dynamoDB.ScanAsync(request);
            if (responce.Items == null || responce.Items.Count == 0)
                return null;

            foreach (Dictionary<string, AttributeValue> item in responce.Items)
            {
                result.Add(item.ToClass<UserDbRepository>());
            }
            return result;
        }

        public void Dispose()
        {
            _dynamoDB.Dispose();
        }
    }
}
