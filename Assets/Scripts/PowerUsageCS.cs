//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUsageCS : MonoBehaviour
{
    public GameObject doorLbutton;
public GameObject doorRbutton;
public GameObject  lightL;
public GameObject lightR;
public GameObject lightGlobal;
public GameObject lightLocal;

public GameObject batteryUsageGreen;
public GameObject batteryUsageYellow;
public GameObject batteryUsageOrange;
public GameObject batteryUsageRed;
public int usageCounter = 0;

public int powerUsage;
public float battery = 256;

    public float time = 360; // 6 minutes = 6 hours = 6*60=360

public int timeInteger;
public string timeString = "12:00 AM";

public int newDoorLcounter;
public int newDoorRcounter;

public AudioClip noPowerSound;
public bool havePower = true;

    void Update()
    {
        time -= Time.deltaTime;
        timeInteger = Mathf.RoundToInt(time);
        if (time > 300 && time < 360) { timeString = "12:00 AM"; }
        if (time > 240 && time < 300) { timeString = "1:00 AM"; }
        if (time > 180 && time < 240) { timeString = "2:00 AM"; }
        if (time > 120 && time < 180) { timeString = "3:00 AM"; }
        if (time > 60 && time < 120) { timeString = "4:00 AM"; }
        if (time > 0 && time < 60) { timeString = "5:00 AM"; }
        if (time < 0) { time = 0; timeString = "6:00 AM"; }

        //usageCounter = GetComponent(ShowHideCameraButton).doorLcounter + GetComponent(ShowHideCameraButton).doorRcounter
        //+ GetComponent(ShowHideCameraButton).lightLcounter + GetComponent(ShowHideCameraButton).lightRcounter;

        if (doorLbutton.GetComponent<DoorButtonCS>().closed) { newDoorLcounter = 1; }
        if (!doorLbutton.GetComponent<DoorButtonCS>().closed) { newDoorLcounter = 0; }

        if (doorRbutton.GetComponent<DoorButtonCS>().closed) { newDoorRcounter = 1; }
        if (!doorRbutton.GetComponent<DoorButtonCS>().closed) { newDoorRcounter = 0; }

        usageCounter = newDoorLcounter + newDoorRcounter
        + GetComponent<ShowHideCameraButton>().lightLcounter + GetComponent<ShowHideCameraButton>().lightRcounter;

        battery -= Time.deltaTime * 0.25f;
        if (GetComponent<ShowHideCameraButton>().weAreWatching) { battery -= Time.deltaTime * 0.5f; }

        if (doorLbutton.GetComponent<DoorButtonCS>().closed) //!
        {
            battery -= Time.deltaTime/* * usageCounter*/;
        }


        if (doorRbutton.GetComponent<DoorButtonCS>().closed) //!
        {
            battery -= Time.deltaTime/* * usageCounter*/;
        }


        if (lightL.GetComponent<Light>().enabled)
        {
            battery -= Time.deltaTime * usageCounter;
        }


        if (lightR.GetComponent<Light>().enabled)
        {
            battery -= Time.deltaTime * usageCounter;
        }

        if (battery != 0)
        {

            if (usageCounter == 0) { batteryUsageGreen.GetComponent<Renderer>().enabled = false; batteryUsageYellow.GetComponent<Renderer>().enabled = false; batteryUsageOrange.GetComponent<Renderer>().enabled = false; batteryUsageRed.GetComponent<Renderer>().enabled = false; }
            if (usageCounter == 1) { batteryUsageGreen.GetComponent<Renderer>().enabled = true; batteryUsageYellow.GetComponent<Renderer>().enabled = false; batteryUsageOrange.GetComponent<Renderer>().enabled = false; batteryUsageRed.GetComponent<Renderer>().enabled = false; }
            if (usageCounter == 2) { batteryUsageGreen.GetComponent<Renderer>().enabled = true; batteryUsageYellow.GetComponent<Renderer>().enabled = true; batteryUsageOrange.GetComponent<Renderer>().enabled = false; batteryUsageRed.GetComponent<Renderer>().enabled = false; }
            if (usageCounter == 3) { batteryUsageGreen.GetComponent<Renderer>().enabled = true; batteryUsageYellow.GetComponent<Renderer>().enabled = true; batteryUsageOrange.GetComponent<Renderer>().enabled = true; batteryUsageRed.GetComponent<Renderer>().enabled = false; }
            if (usageCounter == 4) { batteryUsageGreen.GetComponent<Renderer>().enabled = true; batteryUsageYellow.GetComponent<Renderer>().enabled = true; batteryUsageOrange.GetComponent<Renderer>().enabled = true; batteryUsageRed.GetComponent<Renderer>().enabled = true; }

            if (usageCounter < 0) { usageCounter = 0; }
            if (usageCounter > 4) { usageCounter = 4; }
            if (battery < 0) { battery = 0; }

        }

        if (battery == 0 && havePower)
        {
            havePower = false;
            lightGlobal.GetComponent<Light>().enabled = false;
            lightLocal.GetComponent<Light>().intensity = 0.4f;
            lightLocal.GetComponent<AudioSource>().clip = noPowerSound;
            lightLocal.GetComponent<AudioSource>().Play();
        }

    }

    void OnGUI()
    {int batteryInteger = Mathf.RoundToInt(battery);
        GUI.Label(new Rect(10, Screen.height - 32, 100, 20), batteryInteger + "%");
        GUI.Label(new Rect(10, Screen.height - 64, 100, 20), timeString);
    }
}
