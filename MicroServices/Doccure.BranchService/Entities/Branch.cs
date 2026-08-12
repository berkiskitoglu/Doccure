using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Branch : BaseEntity
{
 
    [BsonElement("branchName")]
    public string BranchName { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("imageUrl")]
    public string ImageUrl { get; set; }

    [BsonElement("status")]
    public bool Status { get; set; }

    public Branch(string branchName, string description, string imageUrl, bool status)
    {
        BranchName = branchName;
        Description = description;
        ImageUrl = imageUrl;
        Status = status;
    }


}

