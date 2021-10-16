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
    public interface IFeeService
    {
        Task<PagedResults<FeeViewModel>> GetFees(PagingRequest request);

        Task<FeeViewModel> GetFeeById(int id);

        Task<FeeViewModel> PostFee(FeeRequest model, int userId);

        Task<FeeViewModel> UpdateFee(int id, FeeRequest model, int userId);

        Task<FeeViewModel> DeleteFee(int id);

        void Save();

        Task SaveAsync();
    }

    public class FeeService : IFeeService
    {
        private readonly IFeeRepository _FeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeeService(IFeeRepository FeeRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _FeeRepository = FeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FeeViewModel> DeleteFee(int id)
        {
            var query = await _FeeRepository.GetSingleByIdAsync(id);
            _FeeRepository.Delete(query);
            return _mapper.Map<Fee, FeeViewModel>(query);
        }

        public async Task<FeeViewModel> GetFeeById(int id)
        {
            var query = await _FeeRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Fee, FeeViewModel>(query);
        }

        public async Task<PagedResults<FeeViewModel>> GetFees(PagingRequest request)
        {
            var query = await _FeeRepository.GetAllAsync(null);
            var rs = Paging<Fee>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<FeeViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Fee>, IEnumerable<FeeViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<FeeViewModel> PostFee(FeeRequest model, int userId)
        {
            var insert = _mapper.Map<FeeRequest, Fee>(model);
            insert.CreateBy = userId;
            await _FeeRepository.AddAsync(insert);
            return _mapper.Map<Fee, FeeViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<FeeViewModel> UpdateFee(int id, FeeRequest model, int userId)
        {
            var query = await _FeeRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdateBy = userId;
            _FeeRepository.Update(update);
            return _mapper.Map<Fee, FeeViewModel>(update);
        }
    }
}