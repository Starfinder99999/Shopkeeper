using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TEST : MonoBehaviour {
    public Generic.CoroutineTracker tracker;

    private void Awake()
    {
        tracker = gameObject.AddComponent<Generic.CoroutineTracker>();

    }

}
