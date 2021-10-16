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
    public interface INewsService
    {
        Task<PagedResults<NewsViewModel>> GetAllNews(PagingRequest request);

        Task<NewsViewModel> GetNewsById(int id);

        Task<NewsViewModel> PostNews(NewsRequest model, int userId);

        Task<NewsViewModel> UpdateNews(int id, NewsRequest model, int userId);

        Task<NewsViewModel> DeleteNews(int id);

        void Save();

        Task SaveAsync();
    }

    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NewsViewModel> DeleteNews(int id)
        {
            var query = await _newsRepository.GetSingleByIdAsync(id);
            _newsRepository.Delete(query);
            return _mapper.Map<News, NewsViewModel>(query);
        }

        public async Task<NewsViewModel> GetNewsById(int id)
        {
            var query = await _newsRepository.GetSingleByIdAsync(id);
            return _mapper.Map<News, NewsViewModel>(query);
        }

        public async Task<PagedResults<NewsViewModel>> GetAllNews(PagingRequest request)
        {
            var query = await _newsRepository.GetAllAsync(null);
            var rs = Paging<News>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<NewsViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<NewsViewModel> PostNews(NewsRequest model, int userId)
        {
            var insert = _mapper.Map<NewsRequest, News>(model);
            insert.CreatedBy = userId;
            await _newsRepository.AddAsync(insert);
            return _mapper.Map<News, NewsViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<NewsViewModel> UpdateNews(int id, NewsRequest model, int userId)
        {
            var query = await _newsRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _newsRepository.Update(update);
            return _mapper.Map<News, NewsViewModel>(update);
        }
    }
}