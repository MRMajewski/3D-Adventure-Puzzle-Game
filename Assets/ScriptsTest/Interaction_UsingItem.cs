using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction_UsingItem : Interaction
{

    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        if (SelectItem() == null)
        {
            ResetSelection();
        }


        else if (SelectItem().tag == "CanBeUsed")
        {
            CanBeUsed = true;
            
            

            if (SelectItem().GetComponent<ControlMovingPlatform>() != null)
            {

                text.text = "<SIZE=%45>MOVE PLATFORM </SIZE=%45> ";
            }

            if(SelectItem().GetComponent<RespawnItems>() !=null )
            {
                text.text = "<SIZE=%45>RESPAWN ITEM </SIZE=%45>";
            }

            usePanel.SetActive(true);
            return;
        }
    }    
    
}
