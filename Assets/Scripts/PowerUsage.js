//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

#pragma strict
var doorLbutton : GameObject;
var doorRbutton : GameObject;
var lightL : GameObject;
var lightR : GameObject;
var lightGlobal : GameObject;
var lightLocal : GameObject;

var batteryUsageGreen : GameObject;
var batteryUsageYellow : GameObject;
var batteryUsageOrange : GameObject;
var batteryUsageRed : GameObject;
var usageCounter : int = 0;

var powerUsage : int;
var battery : float = 256;

var time : float = 360; // 6 minutes = 6 hours = 6*60=360
var timeInteger : int;
var timeString : String = "12:00 AM";

var newDoorLcounter : int;
var newDoorRcounter : int;

var noPowerSound : AudioClip;
var havePower : boolean = true;

function Start () {}
function Update ()
{
time -= Time.deltaTime;
timeInteger = time;
if(time>300 && time<360) { timeString = "12:00 AM";}
if(time>240 && time<300) { timeString = "1:00 AM";}
if(time>180 && time<240) { timeString = "2:00 AM";}
if(time>120 && time<180) { timeString = "3:00 AM";}
if(time>60 && time<120) { timeString = "4:00 AM";}
if(time>0 && time<60) { timeString = "5:00 AM";}
if(time<0) { time=0; timeString = "6:00 AM";}

//usageCounter = GetComponent(ShowHideCameraButton).doorLcounter + GetComponent(ShowHideCameraButton).doorRcounter
//+ GetComponent(ShowHideCameraButton).lightLcounter + GetComponent(ShowHideCameraButton).lightRcounter;

if(doorLbutton.GetComponent(DoorButton).closed) { newDoorLcounter = 1; }
if(!doorLbutton.GetComponent(DoorButton).closed) { newDoorLcounter = 0; }

if(doorRbutton.GetComponent(DoorButton).closed) { newDoorRcounter = 1; }
if(!doorRbutton.GetComponent(DoorButton).closed) { newDoorRcounter = 0; }

usageCounter = newDoorLcounter + newDoorRcounter
+ GetComponent(ShowHideCameraButton).lightLcounter + GetComponent(ShowHideCameraButton).lightRcounter;

battery -= Time.deltaTime * 0.25;
if(GetComponent(ShowHideCameraButton).weAreWatching) { battery -= Time.deltaTime * 0.5; }

if(doorLbutton.GetComponent(DoorButton).closed) //!
{
battery -= Time.deltaTime/* * usageCounter*/;
}


if(doorRbutton.GetComponent(DoorButton).closed) //!
{
battery -= Time.deltaTime/* * usageCounter*/;
}


if(lightL.GetComponent(Light).enabled)
{
battery -= Time.deltaTime * usageCounter;
}


if(lightR.GetComponent(Light).enabled)
{
battery -= Time.deltaTime * usageCounter;
}

if(battery!=0){

if(usageCounter==0) { batteryUsageGreen.renderer.enabled = false; batteryUsageYellow.renderer.enabled = false; batteryUsageOrange.renderer.enabled = false; batteryUsageRed.renderer.enabled = false;}
if(usageCounter==1) { batteryUsageGreen.renderer.enabled = true; batteryUsageYellow.renderer.enabled = false; batteryUsageOrange.renderer.enabled = false; batteryUsageRed.renderer.enabled = false;}
if(usageCounter==2) { batteryUsageGreen.renderer.enabled = true; batteryUsageYellow.renderer.enabled = true; batteryUsageOrange.renderer.enabled = false; batteryUsageRed.renderer.enabled = false;}
if(usageCounter==3) { batteryUsageGreen.renderer.enabled = true; batteryUsageYellow.renderer.enabled = true; batteryUsageOrange.renderer.enabled = true; batteryUsageRed.renderer.enabled = false;}
if(usageCounter==4) { batteryUsageGreen.renderer.enabled = true; batteryUsageYellow.renderer.enabled = true; batteryUsageOrange.renderer.enabled = true; batteryUsageRed.renderer.enabled = true;}

if(usageCounter<0) { usageCounter=0; }
if(usageCounter>4) { usageCounter=4; }
if(battery<0) { battery=0; }

}

if(battery==0 && havePower)
{
havePower = false;
lightGlobal.light.enabled = false;
lightLocal.light.light.intensity = 0.4;
lightLocal.audio.clip = noPowerSound;
lightLocal.audio.Play();
}

}

function OnGUI () {
		var batteryInteger : int = battery;
		GUI.Label (Rect (10, Screen.height-32, 100, 20), batteryInteger+"%");
		GUI.Label (Rect (10, Screen.height-64, 100, 20), timeString);
	}