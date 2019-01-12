using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class ResumeButton : MonoBehaviour
    {

        // Use this for initialization
        void Awake()
        {
            this.GetComponent<Button>().interactable = false;
        }
    }
}