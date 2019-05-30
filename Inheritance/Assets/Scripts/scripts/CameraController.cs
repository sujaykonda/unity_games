using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour

{
    public Transform player;  //The offset of the camera to centrate the player in the X axis
    public float offset = -5f;  //The offset of the camera to centrate the player in the Z axis
    

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(offset*Mathf.Sin(player.eulerAngles.y * Mathf.Deg2Rad), 3f, offset*Mathf.Cos(player.eulerAngles.y * Mathf.Deg2Rad));
        transform.LookAt(player);
    }
}