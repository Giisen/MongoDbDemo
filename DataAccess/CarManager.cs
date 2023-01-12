using DataAccess;
using DataAccess.Models;
using MongoDB.Driver;

namespace DataAccess;

public class CarManager : IRepositoryCar<Car>
{
    private readonly IMongoCollection<Car> _collection;
    public CarManager()
    {
        var hostname = "localhost";
        var databaseName = "demo";
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<Car>("cars", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public void Add(Car item)
    {
        _collection.InsertOne(item);
    }

    public IEnumerable<Car> GetAll()
    {
        return _collection.Find(_ => true).ToEnumerable();
    }

    public IEnumerable<Car> GetByMakeAndModel(string make, string model)
    {
        return _collection
            .Find(p =>
                (!string.IsNullOrEmpty(make) && p.Make == make)
                && (!string.IsNullOrEmpty(model) && p.Model == model))
            .ToEnumerable();
    }

    public void UpdateMake(object id, string make)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Make", make);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void UpdateModel(object id, string model)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Model", model);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void UpdateColor(object id, string color)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("Color", color);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }


    public void UpdateHorsePower(object id, int horsepower)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("HorsePower", horsepower);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }

    public void Replace(object id, Car item)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        var update = Builders<Car>
            .Update
            .Set("HorsePower", item.HorsePower)
            .Set("Color", item.Color)
            .Set("Make", item.Make)
            .Set("Model", item.Model);

        _collection
            .FindOneAndUpdate(
                filter,
                update,
                new FindOneAndUpdateOptions<Car, Car>
                {
                    IsUpsert = true
                }
            );
    }
    public void Delete(object id)
    {
        var filter = Builders<Car>.Filter.Eq("Id", id);
        _collection.FindOneAndDelete(filter);
    }
}