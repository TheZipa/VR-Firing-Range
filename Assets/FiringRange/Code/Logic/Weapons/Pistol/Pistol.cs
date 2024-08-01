using FiringRange.Code.Services.EntityContainer;

namespace FiringRange.Code.Logic.Weapons.Pistol
{
    public class Pistol : Weapon, IFactoryEntity
    {
        private void Awake() => _grabInteractable.activated.AddListener(_ => _weaponAnimator.StartShoot());

        private void OnDestroy() => _grabInteractable.activated.RemoveAllListeners();
    }
}