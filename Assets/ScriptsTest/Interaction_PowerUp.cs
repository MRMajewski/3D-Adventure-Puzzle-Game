using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction_PowerUp : Interaction
{

    public TextMeshProUGUI text;


    // Update is called once per frame
    void Update()
    {
        if (SelectItem() == null)
        {
            ResetSelection();
        }

        else if (SelectItem().GetComponent<PowerUpScript>() != null)
        {
            IsPowerUp = true;

            var PickUpScript = SelectItem().GetComponent<PowerUpScript>();
            CanBePicked = false;


            switch (PickUpScript.powerUpType)
            {
                case PowerUpScript.PowerUpType.Throw:
                    text.text = "<SIZE=%35>STRENGH UP! </SIZE=%35> click LMP button to PICK UP";
                    break;

                case PowerUpScript.PowerUpType.Jump:

                    text.text ="<SIZE=%50>JUMP UP! </SIZE=%50> click LMP button to PICK UP";
                    break;

                case PowerUpScript.PowerUpType.Run:

                    text.text = "<SIZE=%45>SPEED UP! </SIZE=%45> click LMP button to PICK UP";
                    break;
            }

            powerUpPanel.SetActive(true);
        }
    }
}
