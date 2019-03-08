using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.NPC
{
    public class NPC : Character
    {
        [SerializeField] public GameObject npcHUD;

        private void Awake()
        {
            base.Awake();
            hideHUD();
        }

        private void OnEnable()
        {
            Generic.EventManager.OnShowDetails += showHUD;
            Generic.EventManager.OnHideDetails += hideHUD;
        }

        private void OnDisable()
        {
            Generic.EventManager.OnShowDetails -= showHUD;
            Generic.EventManager.OnHideDetails -= hideHUD;
        }

        void hideHUD()
        {
            npcHUD.SetActive(false);

        }

        void showHUD()
        {
            npcHUD.SetActive(true);
        }
    }
}