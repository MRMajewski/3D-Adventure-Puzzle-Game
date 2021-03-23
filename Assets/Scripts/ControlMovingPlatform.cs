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



    //private void Update()
    //{


    //        if (this.itemInteraction.CanBeUsed&&this.canTurnOffOn)
    //        {
    //            if (Input.GetMouseButtonUp(0))
    //            {    
    //                this.Use();
    //            }
    //        }
        
    //}

    //private void OnMouseEnter()
    //{
    //    objectUsed = itemInteraction.selectionObject;

    
    //    this.isUsed = true;
    // //   objectUsed.GetComponent<ControlMovingPlatform>().canTurnOffOn = true;

    //    textUI.text = "Control platform";
    //}

    //private void OnMouseExit()
    //{
    //    this.isUsed = false;
    //    objectUsed = itemInteraction.selectionObject;
       

    //}

}
