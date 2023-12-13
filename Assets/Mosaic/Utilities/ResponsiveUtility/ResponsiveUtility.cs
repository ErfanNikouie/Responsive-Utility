using System.Drawing;
using UnityEngine;
using GridLG = UnityEngine.UI.GridLayoutGroup;
using RT = UnityEngine.RectTransform;

namespace Mosaic.Utilities.Responsive
{
	public static class ResponsiveUtility
	{
		private static ResponsiveUtilitySettings settings = null;
		private static Vector2 actualResolution = Vector2.zero;
		private static Vector2 screenRatio = Vector2.zero; //actual to reference ratio

		private static bool initalized = false;

		private static bool CheckInitialized()
		{
			Initialize();
			return initalized;
		}

		private static float CalculateCompoundFactor(RatioXY ratio)
		{
			float xfactor = screenRatio.x * ratio.X;
			float yfactor = screenRatio.y * ratio.Y;
			float totalWeight = Mathf.Clamp(ratio.X + ratio.Y, 0.00001f, 2);
			float compound = (xfactor + yfactor) / totalWeight;

			return compound;
		}

		public static void Initialize()
		{
			if (initalized)
				return;

			settings = Resources.LoadAll<ResponsiveUtilitySettings>("MosaicScriptables")[0];

			if (settings == null)
			{
				//TODO: Log Error
				return;
			}

			actualResolution = new Vector2(Screen.width, Screen.height);
			screenRatio = actualResolution / settings.ReferenceResolution;

			initalized = true;
		}

		public static class Vector
		{ 
			public static void ScaleToExpandByRatio(ref Vector2 vector, RatioXY ratio)
			{
				vector.x += vector.x * ratio.X * (screenRatio.x - 1);
				vector.y += vector.y * ratio.Y * (screenRatio.y - 1);
			}

			public static void ScaleToExpandByCompoundRatio(ref Vector2 vector, RatioXY ratio)
			{
				float compound = CalculateCompoundFactor(ratio);
				vector *= compound;
			}
		}

		public static class RectTransform
		{
			public static void ScaleToMatchScreenSize(RT rectTransform, RatioXY ratio, bool useX = true, bool useY = true)
			{
				CheckInitialized();

				Vector2 size = rectTransform.sizeDelta;

				if (useX)
					size.x = actualResolution.x * ratio.X;
				if (useY)
					size.y = actualResolution.y * ratio.Y;

				rectTransform.sizeDelta = size;
			}

			public static void ScaleToExpandByRatio(RT rectTransform, RatioXY ratio)
			{
				CheckInitialized();

				Vector2 size = rectTransform.sizeDelta;
				Vector.ScaleToExpandByRatio(ref size, ratio);

				rectTransform.sizeDelta = size;
			}

			public static void ScaleToExpandByCompoundRatio(RT rectTransform, RatioXY ratio)
			{
				CheckInitialized();

				Vector2 size = rectTransform.sizeDelta;
				Vector.ScaleToExpandByCompoundRatio(ref size, ratio);

				rectTransform.sizeDelta = size;
			}

			public static void Position(RT rectTransform, RatioXY anchor, Vector2 position, bool local = false)
			{
				CheckInitialized();

				Vector2 pos = Vector2.zero;
				Vector2 center = new Vector2(anchor.X * actualResolution.x, anchor.Y * actualResolution.y);

				if (local)
				{
					RT parent = rectTransform.parent.GetComponent<RT>();
					Vector2 parentRect = parent.sizeDelta * parent.localScale;
					Vector2 bottomleftcorner = (Vector2)parent.position - (parentRect / 2);
					center = bottomleftcorner + new Vector2(anchor.X * parentRect.x, anchor.Y * parentRect.y);
				}

				pos.x += center.x + position.x * screenRatio.x;
				pos.y += center.y + position.y * screenRatio.y;

				rectTransform.position = pos;
			}
		}

		public static class GridLayoutGroup
		{
			public static void CellScaleToExpandByRatio(GridLG grid, RatioXY ratio)
			{
				CheckInitialized();

				Vector2 size = grid.cellSize;
				Vector.ScaleToExpandByRatio(ref size, ratio);

				grid.cellSize = size;
			}

			public static void CellScaleToExpandByCompoundRatio(GridLG grid, RatioXY ratio)
			{
				CheckInitialized();

				Vector2 size = grid.cellSize;
				Vector.ScaleToExpandByCompoundRatio(ref size, ratio);

				grid.cellSize = size;
			}

			public static void SpacingScaleToExpandByRatio(GridLG grid, RatioXY ratio)
			{
				CheckInitialized();

				Vector2 size = grid.spacing;
				Vector.ScaleToExpandByRatio(ref size, ratio);

				grid.spacing = size;
			}

			public static void SpacingScaleToExpandByCompoundRatio(GridLG grid, RatioXY ratio)
			{
				CheckInitialized();

				Vector2 size = grid.spacing;
				Vector.ScaleToExpandByCompoundRatio(ref size, ratio);

				grid.spacing = size;
			}
		}
	}
}
