//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonCS : MonoBehaviour
{
    public Transform door;
    public bool closed;

private float doorStartPositionY;
private float doorEndPositionY;

void Start()
    {
        doorStartPositionY = transform.position.y;
        doorEndPositionY = transform.position.y * 4;
    }

    void Update()
    {


        if (closed)
        {
            Vector3 tempos = door.position;
            tempos.y -= Time.deltaTime * 16; //-
            if (tempos.y <= doorStartPositionY) { tempos.y = doorStartPositionY; }
            door.position = tempos;
        }

        if (!closed)
        {
            Vector3 tempos = door.position;
            tempos.y += Time.deltaTime * 4;
            if (tempos.y >= doorEndPositionY) { tempos.y = doorEndPositionY; }
            door.position = tempos;
        }

    }
}
