using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class HPBar : MonoBehaviour
    {

        [SerializeField] Character.Character character;
        [SerializeField] UnityEngine.UI.Slider slider;
        [SerializeField] UnityEngine.UI.Text text;

        
        

        // Update is called once per frame
        void Update()
        {
            slider.value =  (float)character.hp / (float)character.status.Health;
            text.text = string.Format("{0}/{1}", character.hp, character.status.Health);
        }
    }
}