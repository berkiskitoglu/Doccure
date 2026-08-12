using AutoMapper;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Branch, ResultBranchDto>().ReverseMap();
        CreateMap<Branch, CreateBranchDto>().ReverseMap();
        CreateMap<Branch, UpdateBranchDto>().ReverseMap();
        CreateMap<Branch, GetByIdBranchDto>().ReverseMap();
    }
}

