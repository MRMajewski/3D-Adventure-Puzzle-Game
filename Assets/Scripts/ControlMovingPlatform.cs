using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlMovingPlatform : UseTemplate
{

    public Sprite yesSprite;
    public Sprite noSprite;


    public SpriteRenderer spriteRenderer;

    public TextMeshProUGUI textUI;

    public bool isActive = false;

    public bool canTurnOffOn = false;

  //  private bool isActive = false;



    public void ControlPlatform()
    {
        if (isActive)
        {
            isActive = false;
            spriteRenderer.sprite = noSprite;
        } 
        else
        {
            spriteRenderer.sprite = yesSprite;
            isActive = true;
        }   
    }

    public void ControlPlatformTest()
    {
        if (isActive)
        {
            isActive = false;
            spriteRenderer.sprite = noSprite;
        }
        else
        {
            spriteRenderer.sprite = yesSprite;
            isActive = true;
        }
    }


    public override void Use()
    {
        //    Debug.Log(objectUsed.name);
       // this.objectUsed.GetComponent<ControlMovingPlatform>().ControlPlatform();
       this.ControlPlatform();
       
    }



    private void Update()
    {


            if (itemInteraction.CanBeUsed)
            {
                if (Input.GetMouseButtonUp(0))
                {    
                    Use();
                }
            }
        
    }

    private void OnMouseEnter()
    {
        objectUsed = itemInteraction.selectionObject;
        objectUsed.GetComponent<ControlMovingPlatform>().canTurnOffOn = true;

        textUI.text = "Control platform";
    }

    private void OnMouseExit()
    {
    
        objectUsed = itemInteraction.selectionObject;
       

    }

}
