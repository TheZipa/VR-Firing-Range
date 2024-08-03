using System.Collections.Generic;
using FiringRange.Code.Logic.Targets;
using UnityEngine;

namespace FiringRange.Code.Services.TargetsProvider
{
    public class TargetsProvider : ITargetsProvider
    {
        private readonly Dictionary<Transform, Target> _targets = new(12);

        public void AddTarget(Target target) => _targets.TryAdd(target.transform, target);

        public Target GetTarget(Transform targetTransform) =>
            _targets.ContainsKey(targetTransform) ? _targets[targetTransform] : null;

        public void Clear() => _targets.Clear();
    }
}