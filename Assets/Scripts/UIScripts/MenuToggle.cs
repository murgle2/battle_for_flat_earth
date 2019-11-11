using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameCompany.BFE
{
    public class MenuToggle : MonoBehaviour
    {
        public GameObject Panel;

        public void PanelToggle()
        {
            if (Panel != null)
            {
                Panel.SetActive(!Panel.activeSelf);

            }
        }
    }
}
