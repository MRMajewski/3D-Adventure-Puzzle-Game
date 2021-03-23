using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_PickUp : Interaction
{

    private void Update()
    {
        if(SelectItem()==null)
        {
            ResetSelection();
        }


        else if (SelectItem().GetComponent<PickUpScript>() != null)
        {
            CanBePicked = true;
            IsPowerUp = false;
            pickUpPanel.SetActive(true);
            return;
        }
    }
}
