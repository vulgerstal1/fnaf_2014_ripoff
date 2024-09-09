//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideCameraButton : MonoBehaviour
{
    public Transform cameraHolder;
public float screenLocalRotationX;
public int screenCounter = 0;
public int doorLcounter = 0;
public int doorRcounter = 0;
public int lightLcounter = 0;
public int lightRcounter = 0;
public GameObject doorLbutton;
public GameObject doorRbutton;
public GameObject lightL;
public GameObject lightR;
public Transform cameraPositionOne;
public Transform cameraPositionTwo;
public Transform cameraPositionThree;
public Transform cameraPositionFour;
public bool weAreWatching;
public AudioClip switchCameraSound;
public AudioClip screenOnSound;
public AudioClip screenOffSound;
public AudioClip switchButtonSound;
public AudioClip doorMoveSound;
public GameObject doorL;
public GameObject doorR;
public GameObject lightLbutton;
public GameObject lightRbutton;
public GameObject screen;
public GameObject screenOfComputer;
public GameObject darkness;
public GameObject bear;
public bool weAreGood = true;
public int a;
public bool mobileInput;
public GameObject mobileDoorL;
public GameObject mobileLightL;
public GameObject mobileDoorR;
public GameObject mobileLightR;
public bool done;

    void Start() {
        Quaternion tempLocRot = cameraHolder.localRotation;
        tempLocRot.x = 90;
        cameraHolder.localRotation = tempLocRot;
    }

    void Update()
    {

        if (mobileInput)
        {
            mobileDoorL.active = true;
            mobileLightL.active = true;
            mobileDoorR.active = true;
            mobileLightR.active = true;
        }
        if (!mobileInput)
        {
            mobileDoorL.active = false;
            mobileLightL.active = false;
            mobileDoorR.active = false;
            mobileLightR.active = false;
        }

        screenLocalRotationX = cameraHolder.transform.rotation.x;
        if (Input.GetMouseButtonDown(0))
        {
            var ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "ScreenButton" && GetComponent<PowerUsageCS>().battery != 0)
                {
                    screenCounter++;
                    if (screenCounter > 1) { screenCounter = 0; }
                }
                if (hit.transform.name == "DoorButtonL" && GetComponent<PowerUsageCS>().battery != 0 || hit.transform.name == "doorLtouch" && GetComponent<PowerUsageCS>().battery != 0)
                {
                    doorL.GetComponent<AudioSource>().clip = doorMoveSound;
                    doorL.GetComponent<AudioSource>().Play();
                    doorLcounter++;
                    if (doorLcounter > 1) { doorLcounter = 0; }

                    if (bear.GetComponent<FreddyBearAICS>().whoToMove.transform.position == bear.GetComponent<FreddyBearAICS>().spawnPointFive.transform.position && !doorLbutton.GetComponent<DoorButtonCS>().closed)
                    {
                        bear.GetComponent<FreddyBearAICS>().whoToMove.transform.position = bear.GetComponent<FreddyBearAICS>().spawnNeutral.position;
                        bear.GetComponent<FreddyBearAICS>().whoToMove.transform.rotation = bear.GetComponent<FreddyBearAICS>().spawnNeutral.rotation;
                        bear.GetComponent<FreddyBearAICS>().youAreDead = false;
                    }
                }
                if (hit.transform.name == "DoorButtonR" && GetComponent<PowerUsageCS>().battery != 0 || hit.transform.name == "doorRtouch" && GetComponent<PowerUsageCS>().battery != 0)
                {
                    doorR.GetComponent<AudioSource>().clip = doorMoveSound;
                    doorR.GetComponent<AudioSource>().Play();
                    doorRcounter++;
                    if (doorRcounter > 1) { doorRcounter = 0; } //1,0
                }
                if (hit.transform.name == "LightButtonL" && GetComponent<PowerUsageCS>().battery != 0 || hit.transform.name == "lightLtouch" && GetComponent<PowerUsageCS>().battery != 0)
                {
                    lightLcounter++;
                    if (lightLcounter > 1) { lightLcounter = 0; }
                    lightLbutton.GetComponent<AudioSource>().clip = switchButtonSound;
                    lightLbutton.GetComponent<AudioSource>().Play();
                    if (lightLcounter == 1 && !lightL.GetComponent<Light>().enabled) { lightL.GetComponent<Light>().enabled = true; }
                    if (lightLcounter == 0 && lightL.GetComponent<Light>().enabled) { lightL.GetComponent<Light>().enabled = false; }
                }
                if (hit.transform.name == "LightButtonR" && GetComponent<PowerUsageCS>().battery != 0 || hit.transform.name == "lightRtouch" && GetComponent<PowerUsageCS>().battery != 0)
                {
                    lightRcounter++;
                    if (lightRcounter > 1) { lightRcounter = 0; }
                    lightRbutton.GetComponent<AudioSource>().clip = switchButtonSound;
                    lightRbutton.GetComponent<AudioSource>().Play();
                    if (lightRcounter == 1 && !lightR.GetComponent<Light>().enabled) { lightR.GetComponent<Light>().enabled = true; }
                    if (lightRcounter == 0 && lightR.GetComponent<Light>().enabled) { lightR.GetComponent<Light>().enabled = false; }
                }
                if (hit.transform.name == "CameraOneButton")
                {
                    transform.position = cameraPositionOne.transform.position;
                    transform.rotation = cameraPositionOne.transform.rotation;
                    GetComponent<AudioSource>().clip = switchCameraSound;
                    GetComponent<AudioSource>().Play();
                }
                if (hit.transform.name == "CameraTwoButton")
                {
                    transform.position = cameraPositionTwo.transform.position;
                    transform.rotation = cameraPositionTwo.transform.rotation;
                    GetComponent<AudioSource>().clip = switchCameraSound;
                    GetComponent<AudioSource>().Play();
                }
                if (hit.transform.name == "CameraThreeButton")
                {
                    transform.position = cameraPositionThree.transform.position;
                    transform.rotation = cameraPositionThree.transform.rotation;
                    GetComponent<AudioSource>().clip = switchCameraSound;
                    GetComponent<AudioSource>().Play();
                }
                if (hit.transform.name == "CameraFourButton")
                {
                    transform.position = cameraPositionFour.transform.position;
                    transform.rotation = cameraPositionFour.transform.rotation;
                    GetComponent<AudioSource>().clip = switchCameraSound;
                    GetComponent<AudioSource>().Play();
                }

                if (hit.transform.name == "RestartButton") { Application.LoadLevel(Application.loadedLevelName); }
                if (hit.transform.name == "ExitButton") { Application.Quit(); }



            }
        }
        if (screenCounter == 0 && cameraHolder.transform.localRotation.x != 0) { Quaternion tempLocRot = cameraHolder.transform.localRotation;  tempLocRot.x -= Time.deltaTime * 4; cameraHolder.transform.localRotation = tempLocRot; }
        if (screenCounter == 1 && cameraHolder.transform.localRotation.x != 0.9) { Quaternion tempLocRot = cameraHolder.transform.localRotation; tempLocRot.x += Time.deltaTime * 4; cameraHolder.transform.localRotation = tempLocRot; }

        if (cameraHolder.transform.localRotation.x < 0) { GetComponent<AudioSource>().clip = screenOnSound; GetComponent<AudioSource>().Play(); Quaternion tempLocRot = cameraHolder.transform.localRotation; tempLocRot.x = 0; cameraHolder.transform.localRotation = tempLocRot; weAreWatching = true; }
        if (cameraHolder.transform.localRotation.x > 0.9) { GetComponent<AudioSource>().clip = screenOffSound; GetComponent<AudioSource>().Play(); Quaternion tempLocRot = cameraHolder.transform.localRotation; tempLocRot.x = 0.9f; cameraHolder.transform.localRotation = tempLocRot; weAreWatching = false; }

        if (doorLcounter == 0 && !doorLbutton.GetComponent<DoorButtonCS>().closed) { doorLbutton.GetComponent<DoorButtonCS>().closed = true; }
        if (doorLcounter == 1 && doorLbutton.GetComponent<DoorButtonCS>().closed) { doorLbutton.GetComponent<DoorButtonCS>().closed = false; }

        if (doorRcounter == 0 && !doorRbutton.GetComponent<DoorButtonCS>().closed) { doorRbutton.GetComponent<DoorButtonCS>().closed = true; }
        if (doorRcounter == 1 && doorRbutton.GetComponent<DoorButtonCS>().closed) { doorRbutton.GetComponent<DoorButtonCS>().closed = false; }
        if (GetComponent<PowerUsageCS>().battery == 0)
        {

            bear.GetComponent<FreddyBearAICS>().weAreGood = false;
            doorRbutton.GetComponent<DoorButtonCS>().closed = false;
            doorLbutton.GetComponent<DoorButtonCS>().closed = false;
            lightL.GetComponent<Light>().enabled = false;
            lightR.GetComponent<Light>().enabled = false;
            screen.active = false;
            transform.position = cameraPositionOne.transform.position;
            transform.rotation = cameraPositionOne.transform.rotation;
            screenOfComputer.active = false;
            if (!bear.GetComponent<FreddyBearAICS>().gameOver && !bear.GetComponent<FreddyBearAICS>().done) { darkness.active = true; }
            if (!done) { bear.GetComponent<FreddyBearAICS>().suddenAttackPosition = Random.Range(1, 5); done = true; } //was(1,3) now 1-4
        }
        //Bear will be moving randomly in random time if We're staring at map or located in our room
        if (transform.position == cameraPositionOne.transform.position || weAreWatching)
        {
            //ItIsWalking();
        }

    }
}
