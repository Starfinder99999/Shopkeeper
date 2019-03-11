using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI {
    public class MPBar : MonoBehaviour

    {

        [SerializeField] Character.Character character;
        [SerializeField] UnityEngine.UI.Slider slider;
        [SerializeField] UnityEngine.UI.Text text;




        // Update is called once per frame
        void Update()
        {
            slider.value = (float)character.energy / (float)character.status.Energy;
            text.text = string.Format("{0}/{1}", character.energy, character.status.Energy);
        }
    }
}
