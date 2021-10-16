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
    public interface IInvestorService
    {
        Task<PagedResults<InvestorViewModel>> GetInvestors(PagingRequest request);

        Task<InvestorViewModel> GetInvestorById(int id);

        Task<InvestorViewModel> PostInvestor(PostInvestorRequest model, int userId);

        Task<InvestorViewModel> UpdateInvestor(int id, PutInvestorRequest model, int userId);

        Task<InvestorViewModel> DeleteInvestor(int id);

        void Save();

        Task SaveAsync();
    }

    public class InvestorService : IInvestorService
    {
        private readonly IInvestorRepository _investorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvestorService(IInvestorRepository _InvestorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _investorRepository = _InvestorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InvestorViewModel> DeleteInvestor(int id)
        {
            var query = await _investorRepository.GetSingleByIdAsync(id);
            _investorRepository.Delete(query);
            return _mapper.Map<Investor, InvestorViewModel>(query);
        }

        public async Task<InvestorViewModel> GetInvestorById(int id)
        {
            var query = await _investorRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Investor, InvestorViewModel>(query);
        }

        public async Task<PagedResults<InvestorViewModel>> GetInvestors(PagingRequest request)
        {
            var query = await _investorRepository.GetAllAsync(null);
            var rs = Paging<Investor>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<InvestorViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Investor>, IEnumerable<InvestorViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<InvestorViewModel> PostInvestor(PostInvestorRequest model, int userId)
        {
            var insert = _mapper.Map<PostInvestorRequest, Investor>(model);
            insert.CreatedBy = userId;
            await _investorRepository.AddAsync(insert);
            return _mapper.Map<Investor, InvestorViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<InvestorViewModel> UpdateInvestor(int id, PutInvestorRequest model, int userId)
        {
            var query = await _investorRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _investorRepository.Update(update);
            return _mapper.Map<Investor, InvestorViewModel>(update);
        }
    }
}