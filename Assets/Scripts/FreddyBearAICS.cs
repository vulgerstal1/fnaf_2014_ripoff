//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreddyBearAICS : MonoBehaviour
{
    public GameObject playerCamera;
public Transform spawnPointOne;
public Transform spawnPointTwo;
public Transform spawnPointThree;
public Transform spawnPointFour;
public Transform spawnPointFive;
public Transform spawnPreAttack;
public Transform spawnPreAttackTwo;
public Transform spawnAttack;
public Transform spawnNeutral;
public GameObject whoToMove;
public bool enough;
public int spawnPosition;
public bool youAreDead;
public bool youAreDeadTwo;
public AudioClip bearSound;
public GameObject doorRbutton;
public GameObject doorLbutton;
public float speed; //5
public float randomTime;
public bool busy;
public bool weAreGood  = true;
public bool gameOver;
public int suddenAttackPosition = 0;
public int b  = 8;
public bool done;

public bool isPlaying;
public bool notPlaying;
public bool wasPlayed;
public bool wasStopped;
public bool wasListened;

public GameObject jumpScareLight;
public GameObject eyes;

void SuddenAttack()
    {

        wasPlayed = isPlaying;
        wasStopped = notPlaying;

        if (playerCamera.GetComponent<ShowHideCameraButton>().darkness.GetComponent<AudioSource>().isPlaying) { isPlaying = true; eyes.active = true; }
        if (!playerCamera.GetComponent<ShowHideCameraButton>().darkness.GetComponent<AudioSource>().isPlaying && isPlaying) { notPlaying = true; }

        if (wasPlayed && wasStopped)
        {
            if (!wasListened)
            {
                //Some action like 'var lol=35; //Right After Music Stops We Can Do something Once!
                /*if(suddenAttackPosition == 1 || suddenAttackPosition == 2 ) //Right */
                if (suddenAttackPosition == 1991)
                {
                    speed = 15;
                    whoToMove.transform.position = spawnPointTwo.transform.position;
                    whoToMove.transform.rotation = spawnPointTwo.transform.rotation;
                    playerCamera.GetComponent<ShowHideCameraButton>().doorRcounter = 1;
                    SuddenAttackFromRight();
                    //ItEntersFromRight();
                }
                /*if(suddenAttackPosition == 3 || suddenAttackPosition == 4 ) //Left */
                if (suddenAttackPosition == 3 || suddenAttackPosition == 4 || suddenAttackPosition == 1 || suddenAttackPosition == 2)
                {
                    speed = 15;
                    whoToMove.transform.position = spawnPointFive.transform.position;
                    whoToMove.transform.rotation = spawnPointFive.transform.rotation;
                    SuddenAttackFromLeft();
                    //ItEntersFromLeft();
                }

                wasListened = true;
            }
        }

    }

    void Start() { spawnPosition = Random.Range(1, 5); /*1,4*/ }
    void Update()
    {

        SuddenAttack();


        //UNif(Input.GetKey(KeyCode.M)/*wasListened && !done /*|| /*gameOver && *//*!playerCamera.GetComponent(ShowHideCameraButton).darkness.audio.isPlaying && !done*/)
        //UN	{
        //if(suddenAttackPosition == 1 || suddenAttackPosition == 2) //Right
        //{
        //UN			speed = 15;
        //gameOver=true;
        //playerCamera.GetComponent(ShowHideCameraButton).doorRcounter=1;
        //UN			whoToMove.transform.position = spawnPointTwo.transform.position; //spawnPreAttack
        //UN			whoToMove.transform.rotation = spawnPointTwo.transform.rotation;
        //SuddenAttackFromRight();
        //playerCamera.GetComponent(ShowHideCameraButton).doorRcounter=1;
        //UN			ItEntersFromRight();
        //var stepA : float = speed * Time.deltaTime;
        //whoToMove.transform.position = Vector3.MoveTowards(whoToMove.transform.position, spawnPreAttack.position, stepA);
        //UN			done = true;
        //}
        //UN	} //if(wasListened) <<<==================





        //UNCOMMENT2DASHESif(Input.GetKey(KeyCode.N)/*wasListened && !done *//*|| /*gameOver && *//*!playerCamera.GetComponent(ShowHideCameraButton).darkness.audio.isPlaying && !done*/)
        //UN{
        //if(suddenAttackPosition == 3 || suddenAttackPosition == 4) //Left
        //{
        //UN		speed = 15; //15
        //gameOver=true;
        //doorLbutton.GetComponent(DoorButton).closed = false;
        //UN		whoToMove.transform.position = spawnPointFive.transform.position; //spawnPreAttackTwo
        //UN		whoToMove.transform.rotation = spawnPointFive.transform.rotation;
        //SuddenAttackFromLeft();
        //UN		ItEntersFromLeft();
        //var stepB : float = speed * Time.deltaTime;
        //whoToMove.transform.position = Vector3.MoveTowards(whoToMove.transform.position, spawnPreAttackTwo.position, stepB);
        //UN		done = true;
        //}
        //UN}



        randomTime -= Time.deltaTime;
        if (randomTime < 0) { randomTime = 0; busy = false; }


        if (playerCamera.GetComponent<ShowHideCameraButton>().weAreWatching && !enough)
        {
            ItIsSpawning();
        }
        if (!playerCamera.GetComponent<ShowHideCameraButton>().weAreWatching && enough)
        {
            enough = false;
        }

        if (/*playerCamera.GetComponent(ShowHideCameraButton).*/weAreGood)
        {
            ItIsWalking();
            ItEntersFromRight();
            ItEntersFromLeft();
        }








        if (whoToMove.transform.position == spawnPreAttack.transform.position)
        {
            gameOver = false;
            done = true;
            playerCamera.GetComponent<PowerUsageCS>().battery = 0;
            playerCamera.transform.position = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.position;
            playerCamera.transform.rotation = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.rotation;
            youAreDead = false;
            GetComponent<AudioSource>().clip = bearSound;
            GetComponent<AudioSource>().Play();
            whoToMove.transform.position = spawnAttack.position;
            whoToMove.transform.rotation = spawnAttack.rotation;
        }







    }

    void ItIsSpawning()
    {
        spawnPosition = Random.Range(1, 6); //1, 4;1, 5;
        if (spawnPosition == 1)
        {
            whoToMove.transform.position = spawnPointOne.transform.position;
            whoToMove.transform.rotation = spawnPointOne.transform.rotation;
        }
        else if (spawnPosition == 2)
        {
            whoToMove.transform.position = spawnPointTwo.transform.position;
            whoToMove.transform.rotation = spawnPointTwo.transform.rotation;
        }
        else if (spawnPosition == 3)
        {
            whoToMove.transform.position = spawnPointThree.transform.position;
            whoToMove.transform.rotation = spawnPointThree.transform.rotation;
        }
        else if (spawnPosition == 4)
        {
            whoToMove.transform.position = spawnPointFour.transform.position;
            whoToMove.transform.rotation = spawnPointFour.transform.rotation;
        }
        else if (spawnPosition == 5 && !doorLbutton.GetComponent<DoorButtonCS>().closed)
        {
            whoToMove.transform.position = spawnPointFive.transform.position;
            whoToMove.transform.rotation = spawnPointFive.transform.rotation;
        }
        enough = true;
    }

    //if(doorLbutton.GetComponent(DoorButton).closed && whoToMove.transform.position == spawnPointFive.transform.position)
    //{
    //	       whoToMove.transform.position = spawnNeutral.position;
    //	       whoToMove.transform.rotation = spawnNeutral.rotation;
    //}


    void ItIsWalking()
    {
        if (!busy)
        {
            busy = true;
            randomTime = Random.Range(10.0f, 20.0f); //5.0,15.0 //10,25
            ItIsSpawning();
            //randomTime -= Time.deltaTime;
            //if(randomTime<0){randomTime=0; busy=false;}
            //if(randomTime==0){
            //ItIsSpawning();
        }
    }


    /*
        spawnPosition = Random.Range(1, 5); //1, 4
        if(spawnPosition==1)
        {
        whoToMove.transform.position = spawnPointOne.transform.position;
        whoToMove.transform.rotation = spawnPointOne.transform.rotation;
        }
        else if(spawnPosition==2)
        {
        whoToMove.transform.position = spawnPointTwo.transform.position;
        whoToMove.transform.rotation = spawnPointTwo.transform.rotation;
        }
        else if(spawnPosition==3)
        {
        whoToMove.transform.position = spawnPointThree.transform.position;
        whoToMove.transform.rotation = spawnPointThree.transform.rotation;
        }
        else if(spawnPosition==4)
        {
        whoToMove.transform.position = spawnPointFour.transform.position;
        whoToMove.transform.rotation = spawnPointFour.transform.rotation;
        }
        yield WaitForSeconds(randomTime);
        */
    //ItIsSpawning();
    //enough = false;
    //playerCamera.GetComponent(ShowHideCameraButton).weAreWatching = true;
    //playerCamera.GetComponent(ShowHideCameraButton).weAreWatching=true;
    //enough = true;
    //playerCamera.GetComponent(ShowHideCameraButton).weAreWatching=false;
    //enough = false;
    //}

    void ItEntersFromRight()
    {

        if (whoToMove.transform.position == spawnPointTwo.transform.position && playerCamera.GetComponent<ShowHideCameraButton>().doorRcounter == 1)
        { youAreDead = true; }
        if (youAreDead)
        {
            float step  = speed * Time.deltaTime;
            whoToMove.transform.position = Vector3.MoveTowards(whoToMove.transform.position, spawnPreAttack.position, step);
        }
        if (whoToMove.transform.position == spawnPreAttack.transform.position && !doorRbutton.GetComponent<DoorButtonCS>().closed)
        {
            gameOver = false;
            done = true;
            jumpScareLight.GetComponent<Light>().enabled = true;
            eyes.active = false;
            playerCamera.GetComponent<PowerUsageCS>().battery = 0;
            playerCamera.transform.position = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.position;
            playerCamera.transform.rotation = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.rotation;
            youAreDead = false;
            GetComponent<AudioSource>().clip = bearSound;
            GetComponent<AudioSource>().Play();

            //PLACE FOR TIMER


            whoToMove.transform.position = spawnAttack.position;
            whoToMove.transform.rotation = spawnAttack.rotation;
        }
        if (whoToMove.transform.position == spawnPreAttack.transform.position && doorRbutton.GetComponent<DoorButtonCS>().closed)
        {
            whoToMove.transform.position = spawnNeutral.position;
            whoToMove.transform.rotation = spawnNeutral.rotation;
            youAreDead = false;
        }

    }



    void ItEntersFromLeft()
    {

        if (whoToMove.transform.position == spawnPointFive.transform.position && !doorLbutton.GetComponent<DoorButtonCS>().closed)
        { youAreDeadTwo = true; }


        //if(whoToMove.transform.position == spawnPointFive.transform.position && playerCamera.GetComponent(ShowHideCameraButton).doorLcounter==1)
        //	{ youAreDeadTwo=true; }


        if (youAreDeadTwo)
        {
            float stepTwo = (speed / 5) * Time.deltaTime;
            whoToMove.transform.position = Vector3.MoveTowards(whoToMove.transform.position, spawnPreAttackTwo.position, stepTwo);

            if (doorLbutton.GetComponent<DoorButtonCS>().closed)
            {
                whoToMove.transform.position = spawnNeutral.position;
                whoToMove.transform.rotation = spawnNeutral.rotation;
            }


        }


        if (whoToMove.transform.position == spawnPreAttackTwo.transform.position && !doorLbutton.GetComponent<DoorButtonCS>().closed)
        {

            gameOver = false;
            done = true;
            jumpScareLight.GetComponent<Light>().enabled = true;
            eyes.active = false;
            playerCamera.GetComponent<PowerUsageCS>().battery = 0;
            playerCamera.transform.position = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.position;
            playerCamera.transform.rotation = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.rotation;
            youAreDeadTwo = false;
            GetComponent<AudioSource>().clip = bearSound;
            GetComponent<AudioSource>().Play();

            //PLACE FOR TIMER


            whoToMove.transform.position = spawnAttack.position;
            whoToMove.transform.rotation = spawnAttack.rotation;
        }


    }


    void SuddenAttackFromRight()
    {
        float stepFour  = speed * Time.deltaTime;
        whoToMove.transform.position = Vector3.MoveTowards(whoToMove.transform.position, spawnPreAttack.position, stepFour);
    }


void SuddenAttackFromLeft()
{
    float stepThree = (speed / 5) * Time.deltaTime;
    whoToMove.transform.position = Vector3.MoveTowards(whoToMove.transform.position, spawnPreAttackTwo.position, stepThree);
    if (whoToMove.transform.position == spawnPreAttackTwo.transform.position)
        gameOver = false;
    done = true;
    jumpScareLight.GetComponent<Light>().enabled = true;
    eyes.active = false;
    playerCamera.GetComponent<PowerUsageCS>().battery = 0;
    playerCamera.transform.position = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.position;
    playerCamera.transform.rotation = playerCamera.GetComponent<ShowHideCameraButton>().cameraPositionOne.transform.rotation;
    youAreDeadTwo = false;
    GetComponent<AudioSource>().clip = bearSound;
    GetComponent<AudioSource>().Play();
    whoToMove.transform.position = spawnAttack.position;
    whoToMove.transform.rotation = spawnAttack.rotation;
}
}
