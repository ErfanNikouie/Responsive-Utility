using UnityEngine;

namespace Mosaic.Utilities.Responsive
{
	[CreateAssetMenu(fileName = "Responsive Settings", menuName = "Mosaic Utilities/Responsive/Responsive Settings")]
	public class ResponsiveUtilitySettings : ScriptableObject
	{
		[SerializeField] private Vector2 referenceResolution = new Vector2(1080, 1920);

		public Vector2 ReferenceResolution => referenceResolution;
	}
}
