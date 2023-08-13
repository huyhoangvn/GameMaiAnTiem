using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the hp bar base on character position, +1 is the offset params which helps hp bar stay above player head\
        //Or you can just simply move hp bar into player object and it will automatically follow assigned object
        transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y + 1, 0);
    }
}
