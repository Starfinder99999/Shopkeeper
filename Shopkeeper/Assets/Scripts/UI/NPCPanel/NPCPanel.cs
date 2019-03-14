using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI.Worldspace
{
    public class NPCPanel : MonoBehaviour
    {
        [SerializeField] public GameObject speechPanel;
        [SerializeField] public GameObject choicePanel;

        [SerializeField] public string InteractPanel;


        private bool interacting = false; 

        public void Interact()
        {
            if (!interacting)
            {
                interacting = true;
                switch (InteractPanel)
                {
                    case "SpeechPanel":
                        speechPanel.SetActive(true);
                        break;

                    case "ChoicePanel":
                        choicePanel.SetActive(true);
                        break;



                }
            }
        }

        public void ExitInteraction()
        {
            speechPanel.GetComponent<SpeechPanel>().Reset();
            speechPanel.SetActive(false);
            choicePanel.SetActive(false);
            interacting = false;
        }


    }
}