using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class TransitionToLoop : MonoBehaviour
    {

        [SerializeField] AudioSource loopAudio;
        // Update is called once per frame
        void Update()
        {
            if (!this.GetComponent<AudioSource>().isPlaying)
            {
                loopAudio.Play();
                Destroy(this.gameObject);
            }
        }
    }
}
