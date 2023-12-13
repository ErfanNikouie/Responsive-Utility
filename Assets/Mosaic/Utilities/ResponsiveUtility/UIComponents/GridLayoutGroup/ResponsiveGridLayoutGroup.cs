using UnityEngine;
using UnityEngine.UI;

namespace Mosaic.Utilities.Responsive
{
    public class ResponsiveGridLayoutGroup : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroupCellOperation[] cellOperations = null;
        [SerializeField] private GridLayoutGroupSpacingOperation[] spacingOperations = null;
		
		private GridLayoutGroup grid = null;

		private bool initialized = false;

		private void Awake()
		{
			if (initialized)
				return;

			grid = GetComponent<GridLayoutGroup>();
			Apply();
		}

		public void Apply()
		{
			foreach (var cellOperation in cellOperations)
				cellOperation.Apply(grid);

			foreach (var spacingOperation in spacingOperations)
				spacingOperation.Apply(grid);

			initialized = true;
		}
	}
}
