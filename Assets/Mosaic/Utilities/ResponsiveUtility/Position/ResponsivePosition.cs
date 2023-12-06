using UnityEngine;

namespace Mosaic.Utilities.Responsive
{
    public class ResponsivePosition : MonoBehaviour
    {
        [SerializeField] private RatioXY anchor;
        [SerializeField] private Vector2 position;

		private RectTransform rectTransform = null;
		private Vector2 originalPosition = Vector2.zero;

		private bool initialized = false;

		private void Awake()
		{
			if (initialized)
				return;

			rectTransform = transform as RectTransform;
			originalPosition = rectTransform.position;

			Position();
		}

		public void Position()
		{
			rectTransform?.Position(anchor, position);
			initialized = true;
		}
	}
}
