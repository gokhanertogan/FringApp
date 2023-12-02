using FringApp.API.Dtos;
using FringApp.API.Repositories.Store;
using FringApp.API.Repositories.StoreAttribute;
using FringApp.API.Repositories.StoreAttributeDefinition;

namespace FringApp.API.Services.Store;

public class StoreService : IStoreService
{
    private readonly IStoreReadRepository _storeReadRepository;
    private readonly IStoreAttributeReadRepository _storeAttributeReadRepository;
    private readonly IStoreAttributeDefinitionReadRepository _storeAttributeDefinitionReadRepository;

    public StoreService(IStoreReadRepository storeReadRepository, IStoreAttributeReadRepository storeAttributeReadRepository, IStoreAttributeDefinitionReadRepository storeAttributeDefinitionReadRepository)
    {
        _storeReadRepository = storeReadRepository;
        _storeAttributeReadRepository = storeAttributeReadRepository;
        _storeAttributeDefinitionReadRepository = storeAttributeDefinitionReadRepository;
    }

    public async Task<Entities.Store> GetStore(string Id)
    {
        return await _storeReadRepository.GetByIdAsync(Id);
    }

    public Task<List<Entities.Store>> GetStores()
    {
        var data = _storeReadRepository.GetAll().ToList();
        return Task.FromResult(data);
    }

    public Task<List<Entities.Store>> GetFilteredStores(StoreFilterDTO storeFilterDTO)
    {
        var allData = _storeReadRepository.GetAll();
        var currentDate = DateTime.UtcNow;
        var carParkAttributeName = "Car Park";
        var terraceAttributeName = "Terrace";
        var wifiAttributeName = "Wifi";

        if (storeFilterDTO.IsOpen)
            allData = allData.Where(x => x.WorkingStartTime <= currentDate && x.WorkingEndTime >= currentDate);

        if (storeFilterDTO.HasCarPark)
        {
            var carParkAttributeId = _storeAttributeDefinitionReadRepository.GetWhere(x => x.Name == carParkAttributeName).FirstOrDefault()?.Id;

            if (carParkAttributeId is not null)
            {
                var storeIds = _storeAttributeReadRepository.GetAll().Where(x => x.Id == carParkAttributeId).Select(x => x.StoreId);
                allData = allData.Where(x => storeIds.Contains(x.Id));
            }
        }

        if (storeFilterDTO.HasTerrace)
        {
            var terraceAttributeId = _storeAttributeDefinitionReadRepository.GetWhere(x => x.Name == terraceAttributeName).FirstOrDefault()?.Id;

            if (terraceAttributeId is not null)
            {
                var storeIds = _storeAttributeReadRepository.GetAll().Where(x => x.Id == terraceAttributeId).Select(x => x.StoreId);
                allData = allData.Where(x => storeIds.Contains(x.Id));
            }
        }

        if (storeFilterDTO.HasWifi)
        {
            var wifiAttributeId = _storeAttributeDefinitionReadRepository.GetWhere(x => x.Name == wifiAttributeName).FirstOrDefault()?.Id;

            if (wifiAttributeId is not null)
            {
                var storeIds = _storeAttributeReadRepository.GetAll().Where(x => x.Id == wifiAttributeId).Select(x => x.StoreId);
                allData = allData.Where(x => storeIds.Contains(x.Id));
            }
        }

        return Task.FromResult(allData.ToList());
    }
}
