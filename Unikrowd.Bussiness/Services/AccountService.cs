using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.DTOs.Requests;
using Unikrowd.Bussiness.Exceptions;
using Unikrowd.Bussiness.MapperViewModels;
using Unikrowd.Bussiness.Utils;
using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;
using Unikrowd.Data.Repositories;
using static Unikrowd.Bussiness.CommonModels.CommonEnums;

namespace Unikrowd.Bussiness.Services
{
    public interface IAccountService
    {
        Task<PagedResults<AccountViewModel>> GetAllPaging(PagingRequest request);
        Task<AccountViewModel> GetAccountById(int id);
        Task<AccountViewModel> PostAccount(PostAccountRequest model, int userId);
        Task<AccountViewModel> UpdateAccount(int id, PutAccountRequest model, int userId);
        Task<AccountViewModel> DeleteAccount(int id);
        void Save();
        Task SaveAsync();

    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository _accountRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._accountRepository = _accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountViewModel> DeleteAccount(int id)
        {
            var query = await _accountRepository.GetSingleByIdAsync(id);
            _accountRepository.Delete(query);
            return _mapper.Map<Account, AccountViewModel>(query);
        }

        public async Task<AccountViewModel> GetAccountById(int id)
        {
            var query = await _accountRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Account, AccountViewModel>(query);
        }

        public async Task<PagedResults<AccountViewModel>> GetAllPaging(PagingRequest request)
        {           
            var query = await _accountRepository.GetManyAsync(x => x.Status == (int)AccountStatus.Active, null);
            var rs = Paging<Account>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<AccountViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Account>, IEnumerable<AccountViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<AccountViewModel> PostAccount(PostAccountRequest model, int userId)
        {
            if (model.Role == (int)Role.Admin) throw new CustomException(HttpStatusCode.MethodNotAllowed, GeneralMessages.MethodNotAllowed, "");
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var insert = _mapper.Map<PostAccountRequest, Account>(model);
            insert.CreatedBy = userId;
            insert.Status = (int?)AccountStatus.Active;
            await _accountRepository.AddAsync(insert);
            return _mapper.Map<Account, AccountViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<AccountViewModel> UpdateAccount(int id, PutAccountRequest model, int userId)
        {
            var query = await _accountRepository.GetSingleByIdAsync(id);
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _accountRepository.Update(update);
            return _mapper.Map<Account, AccountViewModel>(update);
        }
    }
}
