using UnityEngine;

namespace Mosaic.Utilities.Responsive
{
	public class ResponsiveScale : MonoBehaviour
    {

		[SerializeField] private ScaleOperation[] scaleOperations;

		RectTransform rectTransform = null;
		private Vector2 originalSize = Vector2.zero;

		private bool scaled = false;

		private void OnEnable()
		{
			if (scaled)
				return;

			rectTransform = transform as RectTransform;
			originalSize = rectTransform.sizeDelta;

			Scale();
		}

		private void Update()
		{
			rectTransform.sizeDelta = originalSize;
			Scale();
		}

		private void Scale()
		{
			foreach (ScaleOperation operation in scaleOperations)
				operation.Apply(rectTransform);

			scaled = true;
		}
	}
}
