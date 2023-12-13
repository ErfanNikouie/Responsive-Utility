using UnityEngine;
using UnityEngine.SocialPlatforms;

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

		public static void ScaleToMatchScreenSize(RectTransform rectTransform, RatioXY ratio, bool useX = true, bool useY = true)
		{
			CheckInitialized();

			Vector2 size = rectTransform.sizeDelta;

			if (useX)
				size.x = actualResolution.x * ratio.X;
			if (useY)
				size.y = actualResolution.y * ratio.Y;

			rectTransform.sizeDelta = size;
		}

		public static void ScaleToExpandByRatio(RectTransform rectTransform, RatioXY ratio)
		{
			CheckInitialized();

			Vector2 size = rectTransform.sizeDelta;
			size.x += size.x * ratio.X * (screenRatio.x  - 1);
			size.y += size.y * ratio.Y * (screenRatio.y  - 1);

			rectTransform.sizeDelta = size;
		}

		public static void ScaleToExpandByCompoundRatio(RectTransform rectTransform, RatioXY ratio)
		{
			CheckInitialized();
						
			float xfactor = screenRatio.x * ratio.X;
			float yfactor = screenRatio.y * ratio.Y;
			float compound = xfactor + yfactor;

			Vector2 size = rectTransform.sizeDelta;
			size *= compound;

			rectTransform.sizeDelta = size;
		}

		public static void Position(RectTransform rectTransform, RatioXY anchor, Vector2 position, bool local = false)
		{
			CheckInitialized();

			Vector2 pos = Vector2.zero;
			Vector2 center = new Vector2(anchor.X * actualResolution.x, anchor.Y * actualResolution.y);

			if (local)
			{
				RectTransform parent = rectTransform.parent.GetComponent<RectTransform>();
				Vector2 parentRect = parent.sizeDelta * parent.localScale;
				Vector2 bottomleftcorner = (Vector2)parent.position - (parentRect / 2);
				center = bottomleftcorner + new Vector2(anchor.X * parentRect.x, anchor.Y * parentRect.y);
			}

			pos.x += center.x + position.x * screenRatio.x;
			pos.y += center.y + position.y * screenRatio.y;

			rectTransform.position = pos;
		}
	}
}
