using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSystemScript : MonoBehaviour
{

    public int numberOfBridgesUp = 0;

    public GameObject[] bridgeSegments;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TargetShot()
    {
        getUpBridgeSegment(numberOfBridgesUp - 1);
    }


    public void getUpBridgeSegment(int index)
    {
        LeanTween.moveLocalY(bridgeSegments[index], 0.356f, 2f);
    }

}
