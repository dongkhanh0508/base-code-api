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
    public interface ICampaignService
    {
        Task<PagedResults<CampaignViewModel>> GetCampaigns(PagingRequest request);

        Task<CampaignViewModel> GetCampaignById(int id);

        Task<CampaignViewModel> PostCampaign(PostCampaignRequest model, int userId);

        Task<CampaignViewModel> UpdateCampaign(int id, PutCampaignRequest model, int userId);

        Task<CampaignViewModel> DeleteCampaign(int id);

        void Save();

        Task SaveAsync();
    }

    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CampaignService(ICampaignRepository campaignRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CampaignViewModel> DeleteCampaign(int id)
        {
            var query = await _campaignRepository.GetSingleByIdAsync(id);
            _campaignRepository.Delete(query);
            return _mapper.Map<Campaign, CampaignViewModel>(query);
        }

        public async Task<CampaignViewModel> GetCampaignById(int id)
        {
            var query = await _campaignRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Campaign, CampaignViewModel>(query);
        }

        public async Task<PagedResults<CampaignViewModel>> GetCampaigns(PagingRequest request)
        {
            var query = await _campaignRepository.GetAllAsync(null);
            var rs = Paging<Campaign>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<CampaignViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Campaign>, IEnumerable<CampaignViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<CampaignViewModel> PostCampaign(PostCampaignRequest model, int userId)
        {
            var insert = _mapper.Map<PostCampaignRequest, Campaign>(model);
            insert.CreatedBy = userId;
            await _campaignRepository.AddAsync(insert);
            return _mapper.Map<Campaign, CampaignViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<CampaignViewModel> UpdateCampaign(int id, PutCampaignRequest model, int userId)
        {
            var query = await _campaignRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _campaignRepository.Update(update);
            return _mapper.Map<Campaign, CampaignViewModel>(update);
        }
    }
}