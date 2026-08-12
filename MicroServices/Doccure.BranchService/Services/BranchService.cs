using AutoMapper;
using MongoDB.Driver;

public class BranchService : IBranchService
{

    private readonly IMongoCollection<Branch> _branchCollection;
    private readonly IMapper _mapper;

    public BranchService(IMongoDatabase mongoDatabase , IDatabaseSettings settings , IMapper mapper)
    {
        _branchCollection = mongoDatabase.GetCollection<Branch>(settings.BranchCollection);
        _mapper = mapper;  
    }

    public async Task CreateAsync(CreateBranchDto createBranchDto)
    {
        var value = _mapper.Map<Branch>(createBranchDto);
        await _branchCollection.InsertOneAsync(value);
    }

    public async Task DeleteAsync(string id) => await _branchCollection.DeleteOneAsync(x => x.Id == id);
    

    public async Task<List<ResultBranchDto>> GetAllAsync(int page, int pageSize)
    {
        var values = await _branchCollection
            .Find(_ => true)
            .Skip((page - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        return _mapper.Map<List<ResultBranchDto>>(values);
    }

    public async Task<List<ResultBranchDto>> GetAllAsync()
    {
        var values = await _branchCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultBranchDto>>(values);
    }

    public async Task<GetBranchByIdDto> GetByIdAsync(string id)
    {
        var value = await _branchCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetBranchByIdDto>(value);
    }

    public async Task UpdateAsync(UpdateBranchDto updateBranchDto)
    {
        var value = _mapper.Map<Branch>(updateBranchDto);
        await _branchCollection.FindOneAndReplaceAsync(x => x.Id == updateBranchDto.Id, value);
    }
}

