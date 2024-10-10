
using MongoDB.Bson;
using MongoDB.Driver;

var client = new MongoClient("COSMOS_CONNECTION_STRING"); // connection string to the MongoDB server

var settings = client.Settings; // used to configure the client

Console.WriteLine(settings.Server.Host);

// client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").InsertOne(new BsonDocument() { { "name", "Surfboard" } });

var collections = client.GetDatabase("adventureworks").ListCollectionNames();
Console.WriteLine($"Collections in the database: {collections.ToList().Count}");

// var dbFindList = client.ListDatabaseNames().ToList();
// Console.WriteLine($"Databases in the server: {dbFindList.Count}");

// check if a database exist
// var dbFound = dbFindList.FirstOrDefault(x => x == "adventureworks");
// if (dbFound is not null)
// {
//     Console.WriteLine($"{dbFound} exists in the server");
// }
// else
// {
//     Console.WriteLine($"{dbFound} does not exist in the server");
// }

// // drop a database
// client.DropDatabase("adventureworks");
// Console.WriteLine("Database dropped successfully");





// CREATE COLLECTION

// var product = new BsonDocument
// {
//     { "name", "Sand Surfboard" },
//     { "category", "gear-surf-surfboards" },
//     { "count", 1 }
// };

// client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").InsertOne(product);




// CREATE MULTIPLE DOCUMENTS
// var products = new List<BsonDocument>()
// {
//     new BsonDocument
//     {
//        { "name", "Sand Surfboard" },
//         { "category", "gear-surf-surfboards" },
//         { "count", 1 } 
//     },

//     new BsonDocument
//     {
//       { "name", "Ocean Surfboard" },
//         { "category", "gear-surf-surfboards" },
//         { "count", 5 }  
//     }
// };

// client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").InsertMany(products);




// READ DOCUMENTS

// var documents = client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").Find(new BsonDocument()).ToList(); // returns a list of documents
// foreach (var doc in documents)
// {
//     Console.WriteLine(doc);
// }






// UPDATE DOCUMENTS

// var filter = Builders<BsonDocument>.Filter.Eq("name", "Sand Surfboard");
// var update = Builders<BsonDocument>.Update.Set("count", 25);
// client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").UpdateOne(filter, update);

// foreach (var doc in documents)
// {
//     Console.WriteLine(doc);
// }






// DELETE DOCUMENTS
// var deleteFilter = Builders<BsonDocument>.Filter.Eq("name", "Sand Surfboard");
// client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").DeleteOne(deleteFilter);
// Console.WriteLine("Document deleted successfully");
// var documents = client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").Find(new BsonDocument()).ToList(); // returns a list of documents

// foreach (var doc in documents)
// {
//     Console.WriteLine(doc);
// }


// // DELETE COLLECTION
// client.GetDatabase("adventureworks").DropCollection("products");
// Console.WriteLine("Collection dropped successfully");






// DELETE MULTIPLE DOCUMENTS
// delete - Ocean Surfboard and Sand Surfboard
var deleteFilter = Builders<BsonDocument>.Filter.In("name", ["Ocean Surfboard", "Sand Surfboard"]);

client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").DeleteMany(deleteFilter);
Console.WriteLine("Documents deleted successfully");

var documents = client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").Find(new BsonDocument()).ToList(); // returns a list of documents

foreach (var doc in documents)
{
    Console.WriteLine(doc);
}






// GET COLLLECTION INDEXES

// CREATE MULTIPLE DOCUMENTS
// var products = new List<BsonDocument>()
// {
//     new BsonDocument
//     {
//        { "name", "Sand Surfboard" },
//         { "category", "gear-surf-surfboards" },
//         { "count", 1 } 
//     },

//     new BsonDocument
//     {
//       { "name", "Ocean Surfboard" },
//         { "category", "gear-surf-surfboards" },
//         { "count", 5 }  
//     }
// };

// client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").InsertMany(products);


// // indexes are created automatically when a collection is created, and an index means that the database will be able to search for documents faster

// var indexes = client.GetDatabase("adventureworks").GetCollection<BsonDocument>("products").Indexes;

// var count = 0;
// using (var cursor = await indexes.ListAsync())
// {
//     while (await cursor.MoveNextAsync())
//     {
//         foreach (var index in cursor.Current)
//         {
//             Console.WriteLine(index);
//             count++;
//         }
//     }
// }
// Console.WriteLine($"Total indexes: {count}");



//--------------------
