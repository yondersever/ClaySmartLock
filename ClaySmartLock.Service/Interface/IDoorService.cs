using ClaySmartLock.Model.Service.Door;

namespace ClaySmartLock.Service.Interface
{
    public interface IDoorService
    {
        DoorUnlockServiceResponse UnLockDoor(DoorUnlockServiceRequest request);
        DoorLockServiceResponse LockDoor(DoorLockServiceRequest request);
    }
}
