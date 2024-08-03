using FiringRange.Code.Logic.Targets;

namespace FiringRange.Code.Logic.Common
{
    public class RandomTargetPlacement : TargetPlacement
    {
        private readonly RandomTargetPlacement _rangeConfig;

        public RandomTargetPlacement(Target[] targets, RandomTargetPlacement rangeConfig) : base(targets)
        {
            _rangeConfig = rangeConfig;
        }

        public override void Replace(Target target)
        {
            
        }

        public override void PlaceAll()
        {
            
        }

        private void PlaceTarget(Target target)
        {
            
        }
    }
}