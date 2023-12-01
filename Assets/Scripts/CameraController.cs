using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float FollowSpeed=2f;
    [SerializeField] private float yOffset = 1f;

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
        Vector3 newPos= new Vector3(player.position.x, player.position.y + yOffset, transform.position.z);
        transform.position=Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
