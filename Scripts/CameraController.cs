using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position; // get current position

        if (target.position.x < 0)
            return;

        pos.x = target.position.x; //get x and y and set it back inside
        //pos.y = target.position.y; //if commented out, camera doesnt move with player 

        transform.position = pos;
    }
}
