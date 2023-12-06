using UnityEngine;

namespace Mosaic.Utilities.Responsive
{
	public class ResponsiveScale : MonoBehaviour
    {
		[SerializeField] private ScaleOperation[] scaleOperations;

		private RectTransform rectTransform = null;
		private Vector2 originalSize = Vector2.zero;

		private bool initialized = false;

		private void Awake()
		{
			if (initialized)
				return;

			rectTransform = transform as RectTransform;
			originalSize = rectTransform.sizeDelta;

			Scale();
		}

		public void Scale()
		{
			foreach (ScaleOperation operation in scaleOperations)
				operation.Apply(rectTransform);

			initialized = true;
		}
	}
}
