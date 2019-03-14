using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI.Worldspace
{
    public class Choice : MonoBehaviour
    {

        [SerializeField] public string text;
        [SerializeField] public string[] buttonActions;
        [SerializeField] public string[] buttonTexts;
        [SerializeField] public int[] actionValues;
    }
}