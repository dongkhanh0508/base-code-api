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
    public interface IPaymentService
    {
        Task<PagedResults<PaymentViewModel>> GetPayments(PagingRequest request);

        Task<PaymentViewModel> GetPaymentById(int id);

        Task<PaymentViewModel> PostPayment(PaymentRequest model, int userId);

        Task<PaymentViewModel> UpdatePayment(int id, PaymentRequest model, int userId);

        Task<PaymentViewModel> DeletePayment(int id);

        void Save();

        Task SaveAsync();
    }

    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaymentViewModel> DeletePayment(int id)
        {
            var query = await _paymentRepository.GetSingleByIdAsync(id);
            _paymentRepository.Delete(query);
            return _mapper.Map<Payment, PaymentViewModel>(query);
        }

        public async Task<PaymentViewModel> GetPaymentById(int id)
        {
            var query = await _paymentRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Payment, PaymentViewModel>(query);
        }

        public async Task<PagedResults<PaymentViewModel>> GetPayments(PagingRequest request)
        {
            var query = await _paymentRepository.GetAllAsync(null);
            var rs = Paging<Payment>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<PaymentViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<PaymentViewModel> PostPayment(PaymentRequest model, int userId)
        {
            var insert = _mapper.Map<PaymentRequest, Payment>(model);
            insert.CreatedBy = userId;
            await _paymentRepository.AddAsync(insert);
            return _mapper.Map<Payment, PaymentViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<PaymentViewModel> UpdatePayment(int id, PaymentRequest model, int userId)
        {
            var query = await _paymentRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _paymentRepository.Update(update);
            return _mapper.Map<Payment, PaymentViewModel>(update);
        }
    }
}