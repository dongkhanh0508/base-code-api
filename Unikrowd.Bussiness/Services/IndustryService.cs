using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.DTOs.Requests;
using Unikrowd.Bussiness.MapperViewModels;
using Unikrowd.Bussiness.Utils;
using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;
using Unikrowd.Data.Repositories;

namespace Unikrowd.Bussiness.Services
{
    public interface IIndustryService
    {
        Task<PagedResults<IndustryViewModel>> GetIndustrys(PagingRequest request);

        Task<IndustryViewModel> GetIndustryById(int id);

        Task<IndustryViewModel> PostIndustry(IndustryRequest model, int userId);

        Task<IndustryViewModel> UpdateIndustry(int id, IndustryRequest model, int userId);

        Task<IndustryViewModel> DeleteIndustry(int id);

        void Save();

        Task SaveAsync();
    }

    public class IndustryService : IIndustryService
    {
        private readonly IIndustryRepository _industryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IndustryService(IIndustryRepository industryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IndustryViewModel> DeleteIndustry(int id)
        {
            var query = await _industryRepository.GetSingleByIdAsync(id);
            _industryRepository.Delete(query);
            return _mapper.Map<Industry, IndustryViewModel>(query);
        }

        public async Task<IndustryViewModel> GetIndustryById(int id)
        {
            var query = await _industryRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Industry, IndustryViewModel>(query);
        }

        public async Task<PagedResults<IndustryViewModel>> GetIndustrys(PagingRequest request)
        {
            var query = await _industryRepository.GetAllAsync(null);
            var rs = Paging<Industry>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<IndustryViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Industry>, IEnumerable<IndustryViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<IndustryViewModel> PostIndustry(IndustryRequest model, int userId)
        {
            var insert = _mapper.Map<IndustryRequest, Industry>(model);
            insert.CreatedBy = userId;
            await _industryRepository.AddAsync(insert);
            return _mapper.Map<Industry, IndustryViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<IndustryViewModel> UpdateIndustry(int id, IndustryRequest model, int userId)
        {
            var query = await _industryRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _industryRepository.Update(update);
            return _mapper.Map<Industry, IndustryViewModel>(update);
        }
    }
}