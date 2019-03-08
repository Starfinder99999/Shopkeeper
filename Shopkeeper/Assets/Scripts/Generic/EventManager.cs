using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Generic
{
    public class EventManager : MonoBehaviour
    {
        public delegate void ShowDetails();
        public delegate void HideDetails();
        public static event ShowDetails OnShowDetails;
        public static event HideDetails OnHideDetails;

        [SerializeField] private bool showing = false;


        void Update()
        {
            if (Input.GetAxis("ShowDetails") > 0)
            {
                OnShowDetails?.Invoke();
                showing = true;
            }
            else if (showing)
            {
                OnHideDetails?.Invoke();
                showing = false;
            }
        }
    }
}