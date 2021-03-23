using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsScript : MonoBehaviour
{

    public RectTransform button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerOver()
    {
        LeanTween.moveLocalY(this.gameObject, 300f, 2f);
        LeanTween.size(button, new Vector2(250,75), 2f);
    }

    public void OnMouseOver()
    {
        LeanTween.moveLocalY(this.gameObject, 300f, 2f);
    }

    public void Fnc()
    {
        Debug.Log("Działa");
    }
    
        
    
}
