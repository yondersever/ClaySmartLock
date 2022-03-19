using ClaySmartLock.Model.Service.Door;
using System.Threading.Tasks;

namespace ClaySmartLock.Service.Interface
{
    public interface IDoorService
    {
        Task<DoorUnlockServiceResponse> UnLockDoor(DoorUnlockServiceRequest request);
        Task<DoorLockServiceResponse> LockDoor(DoorLockServiceRequest request);
    }
}
