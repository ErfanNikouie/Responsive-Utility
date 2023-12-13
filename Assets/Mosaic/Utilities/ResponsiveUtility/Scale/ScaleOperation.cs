using UnityEngine;

namespace Mosaic.Utilities.Responsive
{

	[System.Serializable]
	public class ScaleOperation
	{
		private enum ScaleMethod
		{
			MatchScreenSizeX,
			MatchScreenSizeY,
			MatchScreenSizeBoth,
			ExpandByRatio,
			ExpandByCompoundRatio,
		}

		[SerializeField] private ScaleMethod scaleMethod = ScaleMethod.ExpandByRatio;
		[SerializeField] private RatioXY relativeXY = new RatioXY(0.5f, 0.5f);

		public void Apply(RectTransform rectTransform)
		{
			if (rectTransform == null)
				return;

			switch (scaleMethod)
			{
				case ScaleMethod.MatchScreenSizeX:
					rectTransform.ScaleToMatchScreenSize(relativeXY, useY: false);
					break;

				case ScaleMethod.MatchScreenSizeY:
					rectTransform.ScaleToMatchScreenSize(relativeXY, useX: false);
					break;

				case ScaleMethod.MatchScreenSizeBoth:
					rectTransform.ScaleToMatchScreenSize(relativeXY);
					break;

				case ScaleMethod.ExpandByRatio:
					rectTransform.ScaleToExpandByRatio(relativeXY);
					break;

				case ScaleMethod.ExpandByCompoundRatio:
					rectTransform.ScaleToExpandByCompoundRatio(relativeXY);
					break;

				default:
					break;
			}
		}
	}
}
