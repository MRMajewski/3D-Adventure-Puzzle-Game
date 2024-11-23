using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private Camera currentCamera;

    private PickUpScript itemBeingSelected;

    [SerializeField]
    private LayerMask layerMask;

    protected bool canBePicked;
    protected bool isPowerUp;
    protected bool canBeUsed;

    public bool CanBePicked {  get { return canBePicked; } }
    public bool IsPowerUp { get { return isPowerUp; } }
    public bool CanBeUsed { get { return canBeUsed; } }

    [SerializeField]
    protected GameObject pickUpPanel;

    [SerializeField]
    protected GameObject powerUpPanel;

    [SerializeField]
    protected GameObject usePanel;

    protected Ray ray;

    [ContextMenu("ResetRaycast")]
    void Start()
    {
        pickUpPanel.SetActive(false);
        powerUpPanel.SetActive(false);
        usePanel.SetActive(false);
        currentCamera = Camera.current;
    }

    public virtual Transform SelectItem()
    {
        Transform selection;
        ray = currentCamera .ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 2f))
        {
            selection = hitInfo.transform;
        }
        else selection = null;
        return selection;
    }

    public void ResetSelection()
    {
        isPowerUp = false;
        canBePicked = false;
        canBeUsed = false;
        pickUpPanel.SetActive(false);
        powerUpPanel.SetActive(false);
        usePanel.SetActive(false);
        return;
    }

    private void ResetRaycast()
    {
        ray = currentCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 3f, Color.red);
    }
}
