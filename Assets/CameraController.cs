using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    void Update () {
        var appliedPos= player.transform.position + new Vector3(0, 6.73f, -8.91f);
        // appliedPos.x = 0;
        transform.position = appliedPos;
    }
}
