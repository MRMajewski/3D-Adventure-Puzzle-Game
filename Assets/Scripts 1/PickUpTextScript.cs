using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTextScript : MonoBehaviour
{
    public float scaleSize = 1.5f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    TextMovement();
    //}

    private void TextMovement()
    {
        LeanTween.scale(this.gameObject, new Vector3(scaleSize, scaleSize, scaleSize), 1f).setLoopPingPong();
    }
}
