using UnityEngine;
using UnityEngine.UI;

namespace Mosaic.Utilities.Responsive
{

	[System.Serializable]
	public class GridLayoutGroupCellOperation
	{
		private enum ScaleMethod
		{
			ExpandByRatio,
			ExpandByCompoundRatio,
		}

		[SerializeField] private ScaleMethod scaleMethod = ScaleMethod.ExpandByRatio;
		[SerializeField] private RatioXY relativeXY = new RatioXY(0.5f, 0.5f);

		public void Apply(GridLayoutGroup grid)
		{
			if (grid == null)
				return;

			switch (scaleMethod)
			{
				case ScaleMethod.ExpandByRatio:
					grid.CellScaleToExpandByRatio(relativeXY);
					break;

				case ScaleMethod.ExpandByCompoundRatio:
					grid.CellScaleToExpandByCompoundRatio(relativeXY);
					break;

				default:
					break;
			}
		}
	}

	[System.Serializable]
	public class GridLayoutGroupSpacingOperation
	{
		private enum ScaleMethod
		{
			ExpandByRatio,
			ExpandByCompoundRatio,
		}

		[SerializeField] private ScaleMethod scaleMethod = ScaleMethod.ExpandByRatio;
		[SerializeField] private RatioXY relativeXY = new RatioXY(0.5f, 0.5f);

		public void Apply(GridLayoutGroup grid)
		{
			if (grid == null)
				return;

			switch (scaleMethod)
			{
				case ScaleMethod.ExpandByRatio:
					grid.SpacingScaleToExpandByRatio(relativeXY);
					break;

				case ScaleMethod.ExpandByCompoundRatio:
					grid.SpacingScaleToExpandByCompoundRatio(relativeXY);
					break;

				default:
					break;
			}
		}
	}
}