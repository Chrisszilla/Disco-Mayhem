using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "Music Asset", order = 4)]
    public class MusicAsset : ScriptableObject
    {
        public AudioClip clip;
        public bool useLoopPoints;
        public int PCMLoopPoint;
        public int PCMEndPoint;
    }
}