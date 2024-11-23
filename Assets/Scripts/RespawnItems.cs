using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RespawnItems : UseTemplate
{
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private Transform respawnPoint;

    [SerializeField]
    private Sprite yesSprite;
    [SerializeField]
    private Sprite noSprite;

    private bool canRespawn = true;
    [SerializeField]
    private float cooldownTime = 10f;

    private float coolingTime;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private TextMeshProUGUI textUI;

    [ContextMenu("RespawnItem")]

    public void RespawnItem()
    {
        Instantiate(item, respawnPoint.transform.position, Quaternion.identity);
    }

    public override void Use()
    {
        AudioManager.Instance.Play("Use");
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

