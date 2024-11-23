using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTemplate : MonoBehaviour
{
    [SerializeField]
    protected Interaction_UsingItem itemInteraction;

    public bool isUsed = false;

    private void Awake()
    {
      //  itemInteraction = FindObjectOfType<Interaction_UsingItem>();
    }

    void Update()
    {
        if (itemInteraction.CanBeUsed)
        {

            Debug.Log("Można użyć");
            if (Input.GetMouseButtonUp(0))
            {   
                if(isUsed)
                {
                  
                    Use();

                }
               
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

