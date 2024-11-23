using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlMovingPlatform : UseTemplate
{

    [SerializeField]
    private Sprite yesSprite;
    [SerializeField]
    private Sprite noSprite;


    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private TextMeshProUGUI textUI;

    private bool isActive = false;

    public bool IsActive { get => isActive; }

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
      AudioManager.Instance.Play("Use");

        this.ControlPlatform();
       
    }
}
