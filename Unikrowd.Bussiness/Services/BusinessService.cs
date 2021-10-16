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
    public interface IBusinessService
    {
        Task<PagedResults<BusinessViewModel>> GetBusiness(PagingRequest request);

        Task<BusinessViewModel> GetBusinessById(int id);

        Task<BusinessViewModel> PostBusiness(PostBusinessRequest model, int userId);

        Task<BusinessViewModel> UpdateBusiness(int id, PutBusinessRequest model, int userId);

        Task<BusinessViewModel> DeleteBusiness(int id);

        void Save();

        Task SaveAsync();
    }

    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BusinessService(IBusinessRepository _BusinessRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _businessRepository = _BusinessRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BusinessViewModel> DeleteBusiness(int id)
        {
            var query = await _businessRepository.GetSingleByIdAsync(id);
            _businessRepository.Delete(query);
            return _mapper.Map<Business, BusinessViewModel>(query);
        }

        public async Task<BusinessViewModel> GetBusinessById(int id)
        {
            var query = await _businessRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Business, BusinessViewModel>(query);
        }

        public async Task<PagedResults<BusinessViewModel>> GetBusiness(PagingRequest request)
        {
            var query = await _businessRepository.GetAllAsync(null);
            var rs = Paging<Business>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<BusinessViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Business>, IEnumerable<BusinessViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<BusinessViewModel> PostBusiness(PostBusinessRequest model, int userId)
        {
            var insert = _mapper.Map<PostBusinessRequest, Business>(model);
            insert.CreatedBy = userId;
            await _businessRepository.AddAsync(insert);
            return _mapper.Map<Business, BusinessViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<BusinessViewModel> UpdateBusiness(int id, PutBusinessRequest model, int userId)
        {
            var query = await _businessRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _businessRepository.Update(update);
            return _mapper.Map<Business, BusinessViewModel>(update);
        }
    }
}