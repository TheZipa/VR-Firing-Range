using System;
using FiringRange.Code.Logic.Targets;
using FiringRange.Code.Services.EntityContainer;

namespace FiringRange.Code.Logic.Common.TargetPlace
{
    public abstract class TargetPlacement : IFactoryEntity
    {
        public event Action OnTargetHit;
        protected readonly Target[] _targets;

        protected TargetPlacement(Target[] targets)
        {
            _targets = targets;
            foreach (Target target in targets)
            {
                target.OnHit += hitTarget =>
                {
                    Replace(hitTarget);
                    OnTargetHit?.Invoke();
                };
            }
        }

        public abstract void PlaceAll();

        public virtual void Disable()
        {
            foreach (Target target in _targets) target.Disable();
        }

        protected abstract void Replace(Target target);
    }
}