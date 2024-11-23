using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
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

 //   public GameObject selectionObject;
    // public GameObject selection;

    [ContextMenu("ResetRaycast")]
    // Start is called before the first frame update
    void Start()
    {
       pickUpPanel.SetActive(false);
        powerUpPanel.SetActive(false);
        usePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      //  SelectItem();
    }

    public virtual Transform SelectItem()
    {
        Transform selection;
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 2f))
        {
            // var selection = hitInfo.transform;
             selection = hitInfo.transform;           
        }
        else selection = null;
        return selection;

    }

    public void ResetSelection()
    {

      //  if (SelectItem() == null)
       //     {
            IsPowerUp = false;
            CanBePicked = false;
            CanBeUsed = false;
            pickUpPanel.SetActive(false);
            powerUpPanel.SetActive(false);
            usePanel.SetActive(false);

           // selectionObject = null;
     //   }
      
        return;
    }


    private void ResetRaycast()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);
    }
}
