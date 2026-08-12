using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = ObjectId.GenerateNewId().ToString();
}

