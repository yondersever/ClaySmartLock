using ClaySmartLock.Model.Service.DoorHistory;

namespace ClaySmartLock.Service.Interface
{
    public interface IDoorHistoryService
    {
        GetDoorHistoryServiceResponse GetDoorHistory(GetDoorHistoryServiceRequest request);
        void InsertHistory(InsertDoorHistoryServiceRequest request);
    }
}
