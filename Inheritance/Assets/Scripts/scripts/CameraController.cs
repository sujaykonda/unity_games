using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour

{
    public GameObject player;  //The offset of the camera to centrate the player in the X axis
    public float offset = -5;  //The offset of the camera to centrate the player in the Z axis
    

    // Update is called once per frame
    void Update()
    {
        float angle = player.transform.eulerAngles.y;
        transform.position = new Vector3(offset*Mathf.Sin(angle*Mathf.Deg2Rad), 3f, offset*Mathf.Cos(angle*Mathf.Deg2Rad))+player.transform.position;
        transform.LookAt(player.transform);
    }
}