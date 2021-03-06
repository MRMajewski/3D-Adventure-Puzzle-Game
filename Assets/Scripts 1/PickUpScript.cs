using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Transform PlayerHands;

    public ItemInteraction itemInteraction;

    public PlayerStatistics playerStatistics;

    private Rigidbody rg;

    public float force;
    public float maxForce;

    public bool IsPicked = false;

    public UIManager UIManager;


    private void Awake()
    {

        rg = GetComponent<Rigidbody>();
        PlayerHands = GameObject.FindGameObjectWithTag("PlayerHands").transform;
        itemInteraction = FindObjectOfType<ItemInteraction>();
        playerStatistics = FindObjectOfType<PlayerStatistics>();
        UIManager = FindObjectOfType<UIManager>();
        force = 0f;
        //  maxForce = 50f;
        maxForce = playerStatistics.PlayerThrowPower;
    }



    //private void Update()
    //{
    //    if (itemInteraction.CanBePicked && Input.GetMouseButtonDown(1) && IsPicked)
    //    {
    //        Throw();

    //    }
    //}

    private void Update()
    {
        if (itemInteraction.CanBePicked  && IsPicked)
        {
            maxForce = playerStatistics.PlayerThrowPower;
            UIManager.ThrowingUI(0, maxForce);

            if (Input.GetMouseButton(1))
            {

               
                UIManager.ThrowingUI(0, maxForce);
                Debug.Log("A key or mouse click has been detected");
                force += Time.deltaTime*15f;
               // Debug.Log(force);
                UIManager.ThrowingUI(force, maxForce);
             
            }
            if (Input.GetMouseButtonUp(1))
            {
    
                UIManager.ThrowingUI(0,maxForce);
                Debug.Log("rzut");
                if (force >= maxForce) force = maxForce;
                Debug.Log("rzut");
                Throw(force);
                force = 0;
            }
        }

    }

    private void Throw(float force)
    {
        this.transform.parent = null;
        rg.isKinematic = false;
        rg.useGravity = true;
        rg.AddForce(PlayerHands.forward * force, ForceMode.Impulse);
        this.gameObject.GetComponent<Collider>().isTrigger = false;
    }

    private void OnMouseDown()
    {
        if (!itemInteraction.CanBePicked) return;
        else
        {
            UIManager.ThrowingUI(0, maxForce);
            IsPicked = true;

            this.gameObject.GetComponent<Collider>().isTrigger = true;
            this.transform.position = PlayerHands.position;
            rg.MovePosition(PlayerHands.position);
            this.transform.parent = GameObject.Find("PlayerHands").transform;

            rg.velocity = Vector3.zero;
            rg.useGravity = false;
            rg.isKinematic = true;

            this.gameObject.GetComponent<Collider>().isTrigger = true;
        
        }       
    }

    private void OnMouseUp()
    {
        force = 0;
        UIManager.ThrowingUI(0, maxForce);
        IsPicked = false;

     
        this.transform.parent = null;

        rg.useGravity = true;
        rg.isKinematic = false;

        this.gameObject.GetComponent<Collider>().isTrigger = false;

    }

    public void SetThrowPower(float maxForce)
    {
        this.maxForce = maxForce;
    }


}
