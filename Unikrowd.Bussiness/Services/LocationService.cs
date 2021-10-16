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
    public interface ILocationService
    {
        Task<PagedResults<LocationViewModel>> GetLocations(PagingRequest request);

        Task<LocationViewModel> GetLocationById(int id);

        Task<LocationViewModel> PostLocation(LocationRequest model, int userId);

        Task<LocationViewModel> UpdateLocation(int id, LocationRequest model, int userId);

        Task<LocationViewModel> DeleteLocation(int id);

        void Save();

        Task SaveAsync();
    }

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LocationViewModel> DeleteLocation(int id)
        {
            var query = await _locationRepository.GetSingleByIdAsync(id);
            _locationRepository.Delete(query);
            return _mapper.Map<Location, LocationViewModel>(query);
        }

        public async Task<LocationViewModel> GetLocationById(int id)
        {
            var query = await _locationRepository.GetSingleByIdAsync(id);
            return _mapper.Map<Location, LocationViewModel>(query);
        }

        public async Task<PagedResults<LocationViewModel>> GetLocations(PagingRequest request)
        {
            var query = await _locationRepository.GetAllAsync(null);
            var rs = Paging<Location>.PagingAndSorting(query, request.SortType, request.ColName, request.Page, request.PageSize);
            var rsViewModel = new PagedResults<LocationViewModel>
            {
                PageSize = rs.PageSize,
                Results = _mapper.Map<IEnumerable<Location>, IEnumerable<LocationViewModel>>(rs.Results),
                PageNumber = rs.PageNumber,
                TotalNumberOfPages = rs.TotalNumberOfPages,
                TotalNumberOfRecords = rs.TotalNumberOfRecords
            };
            return rsViewModel;
        }

        public async Task<LocationViewModel> PostLocation(LocationRequest model, int userId)
        {
            var insert = _mapper.Map<LocationRequest, Location>(model);
            insert.CreatedBy = userId;
            await _locationRepository.AddAsync(insert);
            return _mapper.Map<Location, LocationViewModel>(insert);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public async Task SaveAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task<LocationViewModel> UpdateLocation(int id, LocationRequest model, int userId)
        {
            var query = await _locationRepository.GetSingleByIdAsync(id);
            var update = _mapper.Map(model, query);
            update.UpdatedBy = userId;
            _locationRepository.Update(update);
            return _mapper.Map<Location, LocationViewModel>(update);
        }
    }
}