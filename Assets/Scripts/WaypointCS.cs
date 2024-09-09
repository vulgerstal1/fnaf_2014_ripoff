//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCS : MonoBehaviour
{
    public GameObject objectToMove;
public GameObject forward;
public GameObject backward;
public GameObject left;
public GameObject right;
public int moveSpeed;
public float randomMinimumTime = 20.0f;
public float randomMaximumTime = 50.0f;
public int randomTime;
public int randomDirection;
public bool activated;
public bool tictoc;
public bool picked;
public int rotationSpeed;
private Transform target;

public bool lolo; //true
public int huhu;
public int hoho;
public bool time;
public float timeLeft = 360;
public int jojo;
public bool freeze;
    //public timeStopped : boolean; //made to stop enemies when we're looking at'em through camera.
    //so all enemies have ultraspeed. only foxy has normal run speed in corridor.
    //public test : boolean;

    void Update()
    {

        //	if(timeStopped) { time=false; }
        //	if(!timeStopped) { time=true; }

        if (objectToMove.transform.position == transform.position && !lolo)
        {
            lolo = true;
            huhu = Random.Range(1, 5); //5,30
            hoho = Random.Range(1, 5);
            timeLeft = Random.Range(1, 5); //15,60		5,15
            time = true;
        }

        if (time)
        {
            timeLeft -= Time.deltaTime;
        }

        if (timeLeft < 0) { timeLeft = 0; }
        if (timeLeft == 0 /*&& !test*/)
        {
            timeLeft = 0.1f; //(commented by test)
                            //test=true;
            time = false;
            jojo = 3;
        }


        if (jojo == 3 && objectToMove.transform.position != forward.transform.position)
        {
            moveSpeed = 3;
            target = forward.transform;
            //if(time) //test
            //{
            FollowTransform();
            //}
        }


        //Here we check proximity
        if (Vector3.Distance(objectToMove.transform.position, forward.transform.position) < 2.5) { freeze = true; }
        if (Vector3.Distance(objectToMove.transform.position, forward.transform.position) > 2.5) { freeze = false; }


        if (jojo == 3 && objectToMove.transform.position == forward.transform.position)
        {
            jojo = 0;

            if (lolo) { lolo = false; /*test=false;*/ } //test
        }

        //if(objectToMove.transform.position == transform.position)
        //{
        //lolo=false;
        //}

        //if(objectToMove.transform.position == forward.transform.position)
        //{
        //forward.GetComponent(Waypoint).lolo=false;
        //}



        if (/*randomDirection == 1*/ randomDirection != 0)
        {
            moveSpeed = 3;
            target = forward.transform;
            FollowTransform();
            forward.GetComponent<WaypointCS>().activated = true;
            //if(objectToMove.transform != forward.transform) { activated=false; }
        }

        if (tictoc/* && randomTime > randomMinimumTime*/ ) { randomTime = Mathf.RoundToInt(randomTime - Time.deltaTime); }
        //if(tictoc && timeIsZero) {randomTime =; }
        if (randomTime < 0) { randomTime = 0; }


        if (objectToMove.transform.position == transform.position && activated)
        {
            activated = false;
            randomTime = Mathf.RoundToInt(Random.Range(randomMinimumTime, randomMaximumTime));    //Pick random delay before move
            tictoc = true;
            if (/*randomTime == 0 && */tictoc && !picked)
            {
                randomDirection = Random.Range(1, 5);                           //Pick random movement direction
                                                                                //if(randomDirection == 0) { Random.Range(2,5); }
                tictoc = false;
            }
        }


    }

    void FollowTransform()
    {
        Debug.DrawLine(target.position, objectToMove.transform.position, Color.yellow);
        objectToMove.transform.rotation = Quaternion.Lerp(objectToMove.transform.rotation, target.rotation, moveSpeed * Time.deltaTime);
        objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
