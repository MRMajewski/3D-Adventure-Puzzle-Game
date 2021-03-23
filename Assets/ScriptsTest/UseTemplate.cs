using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTemplate : MonoBehaviour
{
    // public ItemInteraction itemInteraction;
    public Interaction_UsingItem itemInteraction;

    public bool isUsed = false;

    public GameObject objectUsed;

    private void Awake()
    {
        itemInteraction = FindObjectOfType<Interaction_UsingItem>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (itemInteraction.CanBeUsed)
        {
            objectUsed = itemInteraction.selectionObject;

            Debug.Log("Można użyć");
            if (Input.GetMouseButtonUp(0))
            {   
                if(isUsed)
                Use();
             //   Use();
            }
        }
    }


    public virtual void Use()
    {
        Debug.Log("Use zadzaiałało ale w Template");
    }

    private void OnMouseEnter()
    {
        this.isUsed = true;
    }

    private void OnMouseExit()
    {
         
        this.isUsed = false;
    }
}

