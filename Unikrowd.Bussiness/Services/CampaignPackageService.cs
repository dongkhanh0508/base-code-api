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
    public interface ICampaignPackageService
    {
        Task<PagedResults<CampaignPackageViewModel>> GetCampaignPackages(PagingRequest request);

        Task<CampaignPackageViewModel> GetCampaignPackageById(int id);

        Task<CampaignPackageViewModel> PostCampaignPackage(PostCampaignPackageRequest model, int userId);

        Task<CampaignPackageViewModel> UpdateCampaignPackage(int id, PutCampaignPackageRequest model, int userId);

        Task<CampaignPackageViewModel> DeleteCampaignPackage(int id);

        void Save();

        Task SaveAsync();
    }

    public class CampaignPackageService : ICampaignPackageService
    {
        private readonly ICampaignPackageRepository _CampaignPackageRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CampaignPackageService(ICampaignPackageRepository CampaignPackageRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _CampaignPackageRepository = CampaignPackageRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CampaignPackageViewModel> DeleteCampaignPackage(int id)
        {
            var query = await _CampaignPackageRepository.GetSingleByIdAsync(id);
            _CampaignPackageRepository.Delete(query);
            return _mapper.Map<CampaignPackage, CampaignPackageViewModel>(query);
        }

        public async Task<CampaignPackageViewModel> GetCampaignPackageById(int id)
        {
            var query = await _CampaignPackageRepository.GetSingleByIdAsync(id);
            return _mapper.Map<CampaignPackage, CampaignPackageViewModel>(query);
        }

        public async Task<PagedResults<CampaignPackageViewModel>> GetCampaignPackages(PagingRequest request)
        {
            var query = await _CampaignPackageRepository.GetAllAsync(null);
            var rs = Paging<CampaignPackage>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<CampaignPackageViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<CampaignPackage>, IEnumerable<CampaignPackageViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<CampaignPackageViewModel> PostCampaignPackage(PostCampaignPackageRequest model, int userId)
        {
            var insert = _mapper.Map<PostCampaignPackageRequest, CampaignPackage>(model);
            // insert.CreatedBy = userId;
            await _CampaignPackageRepository.AddAsync(insert);
            return _mapper.Map<CampaignPackage, CampaignPackageViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<CampaignPackageViewModel> UpdateCampaignPackage(int id, PutCampaignPackageRequest model, int userId)
        {
            var query = await _CampaignPackageRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            // update.UpdatedBy = userId;
            _CampaignPackageRepository.Update(update);
            return _mapper.Map<CampaignPackage, CampaignPackageViewModel>(update);
        }
    }
}