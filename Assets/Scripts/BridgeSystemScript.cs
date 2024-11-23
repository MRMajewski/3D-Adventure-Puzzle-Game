using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSystemScript : MonoBehaviour
{
    private int numberOfBridgesUp = 0;

    public int NumberOfBridgesUp { get=> numberOfBridgesUp; set=> numberOfBridgesUp=value; }

    [SerializeField]
    private GameObject[] bridgeSegments;

    public void TargetShot()
    {
        getUpBridgeSegment(numberOfBridgesUp);
    }

    public void getUpBridgeSegment(int index)
    {
        LeanTween.moveLocalY(bridgeSegments[index], 0.356f, 2f);
    }
}
