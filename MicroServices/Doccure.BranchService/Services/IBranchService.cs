public interface IBranchService
{
    Task<List<ResultBranchDto>> GetAllAsync();
    Task<List<ResultBranchDto>> GetAllAsync(int page, int pageSize);
    Task<GetBranchByIdDto> GetByIdAsync(string id);
    Task CreateAsync(CreateBranchDto createBranchDto);
    Task UpdateAsync(UpdateBranchDto updateBranchDto);
    Task DeleteAsync(string id);
}

