using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTemplate : MonoBehaviour
{
    public ItemInteraction itemInteraction;

    public bool isUsed = false;

    public GameObject objectUsed;

    private void Awake()
    {
        itemInteraction = FindObjectOfType<ItemInteraction>();
       
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
                Use();
             //   Use();
            }
        }
    }


    public virtual void Use()
    {
        Debug.Log("Use zadzaiałało ale w Template");
    }
}

