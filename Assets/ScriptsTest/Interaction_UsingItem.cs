using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction_UsingItem : Interaction
{
    [SerializeField]
    private TextMeshProUGUI text;

    void Update()
    {
        if (SelectItem() == null)
        {
            ResetSelection();
        }


        else if (SelectItem().tag == "CanBeUsed")
        {
            canBeUsed = true;
                       

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
