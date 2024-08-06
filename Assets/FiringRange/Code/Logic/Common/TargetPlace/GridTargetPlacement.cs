using System.Collections.Generic;
using System.Linq;
using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Logic.Targets;
using UnityEngine;

namespace FiringRange.Code.Logic.Common.TargetPlace
{
    public class GridTargetPlacement : TargetPlacement
    {
        private readonly Vector3[] _gridPositions;
        private readonly Dictionary<Target, Vector3> _usedPosition;

        public GridTargetPlacement(Target[] targets, GridTargetConfig gridTargetConfig, Vector3 gridCenterPosition) : base(targets)
        {
            _gridPositions = new Vector3[gridTargetConfig.GridSize * gridTargetConfig.GridSize];
            _usedPosition = targets.ToDictionary(x => x, p => Vector3.zero);
            CreateGrid(GetGridCenterPosition(gridTargetConfig, gridCenterPosition), gridTargetConfig.GridSize, gridTargetConfig.GridOffset);
        }

        protected override void Replace(Target target)
        {
            Vector3 position;
            do position = _gridPositions[Random.Range(0, _gridPositions.Length)];
            while (_usedPosition.ContainsValue(position));
            target.transform.position = _usedPosition[target] = position;
        }

        private void CreateGrid(Vector3 gridCenterPosition, int size, float offset)
        {
            int halfSize = size / 2;
            int iterator = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _gridPositions[iterator++] = gridCenterPosition + new Vector3(0, j - halfSize, i - halfSize) * offset;
                }
            }
        }

        private static Vector3 GetGridCenterPosition(GridTargetConfig gridTargetConfig, Vector3 gridCenterPosition) =>
            new(gridCenterPosition.x + gridTargetConfig.DistanceOffset, gridCenterPosition.y, gridCenterPosition.z);
    }
}