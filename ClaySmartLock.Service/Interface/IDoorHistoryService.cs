using ClaySmartLock.Model.DTO;
using ClaySmartLock.Model.Service.DoorHistory;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Interface
{
    public interface IDoorHistoryService
    {
        Task<GetDoorHistoryServiceResponse> GetDoorHistory(GetDoorHistoryServiceRequest request);
        Task<DoorHistoryDTO> InsertHistory(InsertDoorHistoryServiceRequest request);
    }
}
