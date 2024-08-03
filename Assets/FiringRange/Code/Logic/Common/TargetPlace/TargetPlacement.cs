using FiringRange.Code.Logic.Targets;
using FiringRange.Code.Services.EntityContainer;

namespace FiringRange.Code.Logic.Common
{
    public abstract class TargetPlacement : IFactoryEntity
    {
        protected readonly Target[] _targets;

        protected TargetPlacement(Target[] targets)
        {
            _targets = targets;
        }

        public abstract void Replace(Target target);

        public abstract void PlaceAll();

        public virtual void Disable()
        {
            foreach (Target target in _targets) target.Disable();
        }
    }
}