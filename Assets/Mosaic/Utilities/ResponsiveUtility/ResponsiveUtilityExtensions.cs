using UnityEngine;
using UnityEngine.UI;

namespace Mosaic.Utilities.Responsive
{
    public static class ResponsiveUtilityExtensions
    {
        //Rect Transform
        public static void ScaleToMatchScreenSize(this RectTransform rectTransform, RatioXY ratio, bool useX = true, bool useY = true) => ResponsiveUtility.RectTransform.ScaleToMatchScreenSize(rectTransform, ratio, useX, useY);
		public static void ScaleToExpandByRatio(this RectTransform rectTransform, RatioXY ratio) => ResponsiveUtility.RectTransform.ScaleToExpandByRatio(rectTransform, ratio);
        public static void ScaleToExpandByCompoundRatio(this RectTransform rectTransform, RatioXY ratio) => ResponsiveUtility.RectTransform.ScaleToExpandByCompoundRatio(rectTransform, ratio);

        public static void Position(this RectTransform rectTransform, RatioXY anchor, Vector2 position, bool local = false) => ResponsiveUtility.RectTransform.Position(rectTransform, anchor, position, local);

        //Transform
        public static void SetResponsivePosition(this Transform transform, Vector2 position)
        {
            ResponsivePosition responsivePosition = transform.GetComponent<ResponsivePosition>();
            responsivePosition?.Position(position);
        }

        //Grid Layout Group
        public static void CellScaleToExpandByRatio(this GridLayoutGroup grid, RatioXY ratio) => ResponsiveUtility.GridLayoutGroup.CellScaleToExpandByRatio(grid, ratio);
        public static void CellScaleToExpandByCompoundRatio(this GridLayoutGroup grid, RatioXY ratio) => ResponsiveUtility.GridLayoutGroup.CellScaleToExpandByCompoundRatio(grid, ratio);
		public static void SpacingScaleToExpandByRatio(this GridLayoutGroup grid, RatioXY ratio) => ResponsiveUtility.GridLayoutGroup.SpacingScaleToExpandByRatio(grid, ratio);
		public static void SpacingScaleToExpandByCompoundRatio(this GridLayoutGroup grid, RatioXY ratio) => ResponsiveUtility.GridLayoutGroup.SpacingScaleToExpandByCompoundRatio(grid, ratio);
	}
}
