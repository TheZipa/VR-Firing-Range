using FiringRange.Code.Logic.Targets;
using UnityEngine;

namespace FiringRange.Code.Services.TargetsProvider
{
    public interface ITargetsProvider : IGlobalService
    {
        void AddTarget(Target target);
        Target GetTarget(Transform targetTransform);
        void Clear();
    }
}