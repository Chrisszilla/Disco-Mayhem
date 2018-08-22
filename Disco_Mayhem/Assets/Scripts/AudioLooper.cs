using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioLooper : MonoBehaviour {

        public MusicAsset musicAsset;
        public bool manualPlay;

        private AudioSource source;

        private void Start()
        {
            source = GetComponent<AudioSource>();
            if (source.clip != musicAsset.clip)
            {
                source.clip = musicAsset.clip;
            }
            source.Play();
        }

        private void Update()
        {
            if (manualPlay)
            {
                manualPlay = false;
                source.timeSamples = musicAsset.PCMLoopPoint;
            }
            if (!musicAsset.useLoopPoints)
            {
                return;
            }
            if (source.timeSamples >= musicAsset.PCMEndPoint)
            {
                source.timeSamples = musicAsset.PCMLoopPoint;
            }
        }

        public void Initialize()
        {
            source.timeSamples = 0;
            source.clip = musicAsset.clip;
            source.Stop();
            source.Play();
        }

    }
}