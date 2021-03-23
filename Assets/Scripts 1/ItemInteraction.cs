using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction_PowerUP : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private PickUpScript itemBeingSelected;

    [SerializeField]
    private LayerMask layerMask;

    public bool CanBePicked;
    public bool IsPowerUp;
    public bool CanBeUsed;

    [SerializeField]
    protected GameObject pickUpPanel;

    [SerializeField]
    protected GameObject powerUpPanel;

    [SerializeField]
    protected GameObject usePanel;


    protected Ray ray;

    public GameObject selectionObject;
   // public GameObject selection;

    [ContextMenu("ResetRaycast")]
    // Start is called before the first frame update
    void Start()
    {
        pickUpPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ResetRaycast();
           // Debug.Log("Działa raycast reset");
        }

        SelectItem();
    }

    private void SelectItem()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);

        RaycastHit hitInfo;
      
        if (Physics.Raycast(ray, out hitInfo, 2f));
        {
            // var selection = hitInfo.transform;
            var selection= hitInfo.transform;
            if (selection == null)
            {
                IsPowerUp = false;
                CanBePicked = false;
                CanBeUsed = false;
                pickUpPanel.SetActive(false);
                powerUpPanel.SetActive(false);
                usePanel.SetActive(false);

                selectionObject = null;

                //  selection.GetComponent<ControlMovingPlatform>().isUsed = false;
                return;
            }
    
            else if (selection.GetComponent<PickUpScript>() != null)
            {
                CanBePicked = true;
                IsPowerUp = false;
                pickUpPanel.SetActive(true);
             //   Debug.Log("Dzieje się");
                return;
            }

            else if (selection.GetComponent<PowerUpScript>() !=null)
            {
                CanBePicked = false;
                IsPowerUp = true;
                powerUpPanel.SetActive(true);
                //  powerUpPanel.GetComponent<TextMeshProUGUI>().text=
                return;
            }

            else if (selection.tag == "CanBeUsed")
            {
                selectionObject = selection.gameObject;


                CanBePicked = false;
                IsPowerUp = false;
                CanBeUsed = true;
                pickUpPanel.SetActive(false);
                powerUpPanel.SetActive(false);
                usePanel.SetActive(true);         
                return;
            }

           
        }

    }

    //private void ThrowTest(float force)
    //{
    //    this.transform.parent = null;
    //    rg.isKinematic = false;
    //    rg.useGravity = true;
    //    rg.AddForce(PlayerHands.forward * force, ForceMode.Impulse);
    //    this.gameObject.GetComponent<Collider>().isTrigger = false;
    //}



    private void ResetRaycast()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);
    }
}
