using UnityEngine;

namespace Mosaic.Utilities.Responsive
{
    public static class ResponsiveUtilityExtensions
    {
        public static void ScaleToMatchScreenSize(this RectTransform rectTransform, RatioXY ratio, bool useX = true, bool useY = true) => ResponsiveUtility.ScaleToMatchScreenSize(rectTransform, ratio, useX, useY);
		public static void ScaleToExpandByRatio(this RectTransform rectTransform, RatioXY ratio) => ResponsiveUtility.ScaleToExpandByRatio(rectTransform, ratio);
        public static void ScaleToExpandByCompoundRatio(this RectTransform rectTransform, RatioXY ratio) => ResponsiveUtility.ScaleToExpandByCompoundRatio(rectTransform, ratio);

        public static void Position(this RectTransform rectTransform, RatioXY anchor, Vector2 position) => ResponsiveUtility.Position(rectTransform, anchor, position);
	}
}
