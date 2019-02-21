using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class HPBar : MonoBehaviour
    {

        [SerializeField] Character.Player.Player player;
        [SerializeField] UnityEngine.UI.Slider slider;
        [SerializeField] UnityEngine.UI.Text text;

        
        

        // Update is called once per frame
        void Update()
        {
            slider.value =  (float)player.hp / (float)player.status.Health;
            text.text = string.Format("{0}/{1}", player.hp, player.status.Health);
        }
    }
}