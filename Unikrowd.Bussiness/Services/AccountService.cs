using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unikrowd.Bussiness.CommonModels;
using Unikrowd.Bussiness.Utils;
using Unikrowd.Data.Entity;
using Unikrowd.Data.Infrastructure;
using Unikrowd.Data.Repositories;

namespace Unikrowd.Bussiness.Services
{
    public interface IAccountService
    {
        Task<PagedResults<Account>> GetAllPaging(PagingRequest request);
    }
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository _accountRepository, IUnitOfWork unitOfWork)
        {
            this._accountRepository = _accountRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<PagedResults<Account>> GetAllPaging(PagingRequest request)
        {
            // var a = _accountRepository.GetAll();
            var cc = Security.HashPassword("123456");
            var query = await _accountRepository.GetManyAsync(x => x.Status == "Active", null);
            var rs = Paging<Account>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            return rs;
        }
    }
}
