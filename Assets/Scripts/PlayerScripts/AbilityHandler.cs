using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCompany.BFE
{
    public class AbilityHandler : MonoBehaviour
    {

        private GameObject abilityButton;
        void Start()
        {
            abilityButton = GameObject.Find("ButtonAbility1");
            Button button = abilityButton.GetComponent<Button>();
            BlinkAbility blink = GetComponent<BlinkAbility>();
            button.onClick.AddListener(blink.Blink);
        }
    }
}
