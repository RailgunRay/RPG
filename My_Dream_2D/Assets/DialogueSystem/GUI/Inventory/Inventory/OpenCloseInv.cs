using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInv : MonoBehaviour {

    public GameObject panel;
    public bool ActivePanel = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (ActivePanel == true)
            {
                panel.SetActive(false);
                ActivePanel = false;
            }
            else
            {
                panel.SetActive(true);
                ActivePanel = true;
            }
        }
    }



}
