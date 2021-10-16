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
    public interface IDocumentService
    {
        Task<PagedResults<DocumentViewModel>> GetDocuments(PagingRequest request);

        Task<DocumentViewModel> GetDocumentById(int id);

        Task<DocumentViewModel> PostDocument(PostDocumentRequest model, int userId);

        Task<DocumentViewModel> UpdateDocument(int id, PutDocumentRequest model, int userId);

        Task<DocumentViewModel> DeleteDocument(int id);

        void Save();

        Task SaveAsync();
    }

    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DocumentService(IDocumentRepository documentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DocumentViewModel> DeleteDocument(int id)
        {
            var query = await _documentRepository.GetSingleByIdAsync(id);
            _documentRepository.Delete(query);
            return _mapper.Map<Document, DocumentViewModel>(query);
        }

        public async Task<DocumentViewModel> GetDocumentById(int id)
        {
            var query = await _documentRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Document, DocumentViewModel>(query);
        }

        public async Task<PagedResults<DocumentViewModel>> GetDocuments(PagingRequest request)
        {
            var query = await _documentRepository.GetAllAsync(null);
            var rs = Paging<Document>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<DocumentViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Document>, IEnumerable<DocumentViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<DocumentViewModel> PostDocument(PostDocumentRequest model, int userId)
        {
            var insert = _mapper.Map<PostDocumentRequest, Document>(model);
            insert.CreatedBy = userId;
            await _documentRepository.AddAsync(insert);
            return _mapper.Map<Document, DocumentViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<DocumentViewModel> UpdateDocument(int id, PutDocumentRequest model, int userId)
        {
            var query = await _documentRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _documentRepository.Update(update);
            return _mapper.Map<Document, DocumentViewModel>(update);
        }
    }
}