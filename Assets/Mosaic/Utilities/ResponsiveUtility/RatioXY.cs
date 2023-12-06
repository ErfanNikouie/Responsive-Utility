using UnityEngine;

namespace Mosaic.Utilities.Responsive
{
    [System.Serializable]
    public struct RatioXY
    {
        [SerializeField][Range(0, 1)] private float x;
        [SerializeField][Range(0, 1)] private float y;

        public float X => x;
        public float Y => y;

        public RatioXY(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
