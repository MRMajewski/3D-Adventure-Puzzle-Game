using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespawnItems : UseTemplate
{

    public GameObject item;
    public Transform respawnPoint;

    public Sprite yesSprite;
    public Sprite noSprite;

    private bool canRespawn = true;
    public float cooldownTime = 10f;

    public float coolingTime;

    public SpriteRenderer spriteRenderer;

    public TextMeshProUGUI textUI;

    [ContextMenu("RespawnItem")]

    public void RespawnItem()
    {
        Debug.Log("Działa RespawnItem");

        Instantiate(item, respawnPoint.transform.position, Quaternion.identity);

    }

    public override void Use()
    {
        audio.Play("Use");
        RespawnItem();
    }

    private void Update()
    {
        if(coolingTime>0)
        {
            coolingTime -= Time.deltaTime;
        }
        else if( coolingTime <=0)
        {
            canRespawn = true;
            spriteRenderer.sprite = yesSprite;
            if (itemInteraction.CanBeUsed && canRespawn)
            {

                Debug.Log("Można użyć");
                if (Input.GetMouseButtonUp(0))
                {
                    Use();
                    canRespawn = false;
                    spriteRenderer.sprite = noSprite;
                    coolingTime = cooldownTime;
                }
            }
        }
    }

}

