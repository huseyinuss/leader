using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using System.Reflection.Metadata;

public class UserRepository : IUserRepository
{
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly string _tableName = "User"; // Replace with your actual table name

    public UserRepository(IAmazonDynamoDB dynamoDb)
    {
        _dynamoDb = dynamoDb;
    }

    public async Task<User> CreateUserAsync(string username)
    {
        var user = new User { Id = Guid.NewGuid().ToString(), Username = username };
        var document = new Amazon.DynamoDBv2.DocumentModel.Document
        {
            ["Id"] = user.Id,
            ["Username"] = user.Username
        };
        
        var table = Table.LoadTable(_dynamoDb, _tableName);
        await table.PutItemAsync(document);

        return user;
    }

    public async Task<User> UpdateProgressAsync(string userId, int levels)
    {
        // Load the user from DynamoDB
        var table = Table.LoadTable(_dynamoDb, _tableName);
        var document = await table.GetItemAsync(userId);

        if (document == null)
        {
            throw new Exception("User not found.");
        }

        int currentLevel = document["Level"].AsInt();
        int currentCoins = document["Coins"].AsInt();

        var updatedUser = new User
        {
            Id = document["Id"],
            Username = document["Username"],
            Level = currentLevel + levels,
            Coins = currentCoins + (levels * 100)
        };

        var updatedDocument = new Amazon.DynamoDBv2.DocumentModel.Document
        {
            ["Id"] = updatedUser.Id,
            ["Username"] = updatedUser.Username,
            ["Level"] = updatedUser.Level,
            ["Coins"] = updatedUser.Coins
        };

        await table.PutItemAsync(updatedDocument);

        return updatedUser;
    }

    public async Task<User> GetUserAsync(string userId)
    {
        var table = Table.LoadTable(_dynamoDb, _tableName);
        var document = await table.GetItemAsync(userId);

        if (document == null)
        {
            return null; // User not found
        }

        // Create a User object from the document
        var user = new User
        {
            Id = document["Id"],
            Username = document["Username"],
            Level = document["Level"].AsInt(),
            Coins = document["Coins"].AsInt()
        };

        return user;
    }
}