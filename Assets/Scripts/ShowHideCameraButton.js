//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

#pragma strict
var cameraHolder : Transform;
var screenLocalRotationX : float;
var screenCounter : int = 0;
var doorLcounter : int = 0;
var doorRcounter : int = 0;
var lightLcounter : int = 0;
var lightRcounter : int = 0;
var doorLbutton : GameObject;
var doorRbutton : GameObject;
var lightL : GameObject;
var lightR : GameObject;
var cameraPositionOne : Transform;
var cameraPositionTwo : Transform;
var cameraPositionThree : Transform;
var cameraPositionFour : Transform;
var weAreWatching : boolean;
var switchCameraSound : AudioClip;
var screenOnSound : AudioClip;
var screenOffSound : AudioClip;
var switchButtonSound : AudioClip;
var doorMoveSound : AudioClip;
var doorL : GameObject;
var doorR : GameObject;
var lightLbutton : GameObject;
var lightRbutton : GameObject;
var screen : GameObject;
var screenOfComputer : GameObject;
var darkness : GameObject;
var bear : GameObject;
var weAreGood : boolean = true;
var a : int;
var mobileInput : boolean;
var mobileDoorL : GameObject;
var mobileLightL : GameObject;
var mobileDoorR : GameObject;
var mobileLightR : GameObject;
var done : boolean;

function Start() { cameraHolder.transform.localRotation.x = 90; }
function Update ()
{

if(mobileInput)
{
mobileDoorL.active = true;
mobileLightL.active = true;
mobileDoorR.active = true;
mobileLightR.active = true;
}
if(!mobileInput)
{
mobileDoorL.active = false;
mobileLightL.active = false;
mobileDoorR.active = false;
mobileLightR.active = false;
}

screenLocalRotationX = cameraHolder.transform.rotation.x;
	if(Input.GetMouseButtonDown(0))
	{
	    var ray = camera.ScreenPointToRay(Input.mousePosition);
    	var hit: RaycastHit;
        if (Physics.Raycast(ray, hit))
        {  if (hit.transform.name == "ScreenButton" && GetComponent(PowerUsage).battery != 0 )
	        { 
		        screenCounter++;
		        if(screenCounter>1){screenCounter=0;}
	        }
	       if (hit.transform.name == "DoorButtonL" && GetComponent(PowerUsage).battery != 0 || hit.transform.name == "doorLtouch" && GetComponent(PowerUsage).battery != 0)
	        { 
	        	doorL.audio.clip = doorMoveSound;
				doorL.audio.Play();
				doorLcounter++;
				if(doorLcounter>1){doorLcounter=0;}
				
				if(bear.GetComponent(FreddyBearAI).whoToMove.transform.position == bear.GetComponent(FreddyBearAI).spawnPointFive.transform.position && !doorLbutton.GetComponent(DoorButton).closed)
				{
		   bear.GetComponent(FreddyBearAI).whoToMove.transform.position = bear.GetComponent(FreddyBearAI).spawnNeutral.position;
	       bear.GetComponent(FreddyBearAI).whoToMove.transform.rotation = bear.GetComponent(FreddyBearAI).spawnNeutral.rotation;
	       bear.GetComponent(FreddyBearAI).youAreDead = false;
				}	
	        }  
	       if (hit.transform.name == "DoorButtonR" && GetComponent(PowerUsage).battery != 0 || hit.transform.name == "doorRtouch" && GetComponent(PowerUsage).battery != 0)
	        { 
	        	doorR.audio.clip = doorMoveSound;
				doorR.audio.Play();
				doorRcounter++;
				if(doorRcounter>1){doorRcounter=0;} //1,0
	        }
	       if (hit.transform.name == "LightButtonL" && GetComponent(PowerUsage).battery != 0 || hit.transform.name == "lightLtouch" && GetComponent(PowerUsage).battery != 0)
	        { 
				lightLcounter++;
				if(lightLcounter>1){lightLcounter=0;}
				lightLbutton.audio.clip = switchButtonSound;
				lightLbutton.audio.Play();
			if(lightLcounter==1 && !lightL.GetComponent(Light).enabled) { lightL.GetComponent(Light).enabled=true;}
			if(lightLcounter==0 && lightL.GetComponent(Light).enabled) { lightL.GetComponent(Light).enabled=false;}
	        } 
	       if (hit.transform.name == "LightButtonR" && GetComponent(PowerUsage).battery != 0 || hit.transform.name == "lightRtouch" && GetComponent(PowerUsage).battery != 0)
	        { 
				lightRcounter++;
				if(lightRcounter>1){lightRcounter=0;}
				lightRbutton.audio.clip = switchButtonSound;
				lightRbutton.audio.Play();
			if(lightRcounter==1 && !lightR.GetComponent(Light).enabled) { lightR.GetComponent(Light).enabled=true;}
			if(lightRcounter==0 && lightR.GetComponent(Light).enabled) { lightR.GetComponent(Light).enabled=false;}
	        }
	       if (hit.transform.name == "CameraOneButton")
	        { 
				transform.position = cameraPositionOne.transform.position;
				transform.rotation = cameraPositionOne.transform.rotation;
				audio.clip = switchCameraSound;
				audio.Play();
	        }
	       if (hit.transform.name == "CameraTwoButton")
	        { 
				transform.position = cameraPositionTwo.transform.position;
				transform.rotation = cameraPositionTwo.transform.rotation;
				audio.clip = switchCameraSound;
				audio.Play();
	        }
	       if (hit.transform.name == "CameraThreeButton")
	        { 
				transform.position = cameraPositionThree.transform.position;
				transform.rotation = cameraPositionThree.transform.rotation;
				audio.clip = switchCameraSound;
				audio.Play();
	        }
	       if (hit.transform.name == "CameraFourButton")
	        { 
				transform.position = cameraPositionFour.transform.position;
				transform.rotation = cameraPositionFour.transform.rotation;
				audio.clip = switchCameraSound;
				audio.Play();
	        } 
	        
	       if (hit.transform.name == "RestartButton") { Application.LoadLevel (Application.loadedLevelName); }
	       if (hit.transform.name == "ExitButton") { Application.Quit(); }
	          
	           
	             
        }
     } 
    if(screenCounter==0 && cameraHolder.transform.localRotation.x != 0) { cameraHolder.transform.localRotation.x -= Time.deltaTime*4; }
    if(screenCounter==1 && cameraHolder.transform.localRotation.x != 0.9) { cameraHolder.transform.localRotation.x += Time.deltaTime*4; }

	if(cameraHolder.transform.localRotation.x<0) {audio.clip = screenOnSound; audio.Play(); cameraHolder.transform.localRotation.x=0; weAreWatching=true;}
	if(cameraHolder.transform.localRotation.x>0.9) {audio.clip = screenOffSound; audio.Play(); cameraHolder.transform.localRotation.x=0.9; weAreWatching=false;}
	
	if(doorLcounter==0 && !doorLbutton.GetComponent(DoorButton).closed) { doorLbutton.GetComponent(DoorButton).closed=true;}
	if(doorLcounter==1 && doorLbutton.GetComponent(DoorButton).closed) { doorLbutton.GetComponent(DoorButton).closed=false;}
	
	if(doorRcounter==0 && !doorRbutton.GetComponent(DoorButton).closed) { doorRbutton.GetComponent(DoorButton).closed=true;}
	if(doorRcounter==1 && doorRbutton.GetComponent(DoorButton).closed) { doorRbutton.GetComponent(DoorButton).closed=false;}
	if(GetComponent(PowerUsage).battery == 0) {
	
	bear.GetComponent(FreddyBearAI).weAreGood=false;
	doorRbutton.GetComponent(DoorButton).closed = false;
	doorLbutton.GetComponent(DoorButton).closed = false;
	lightL.GetComponent(Light).enabled = false;
	lightR.GetComponent(Light).enabled = false;
	screen.active = false;
	transform.position = cameraPositionOne.transform.position;
	transform.rotation = cameraPositionOne.transform.rotation;
	screenOfComputer.active=false;
	if(!bear.GetComponent(FreddyBearAI).gameOver && !bear.GetComponent(FreddyBearAI).done){darkness.active=true;}
	if(!done){ bear.GetComponent(FreddyBearAI).suddenAttackPosition = Random.Range(1, 5); done=true;} //was(1,3) now 1-4
	}
	 //Bear will be moving randomly in random time if We're staring at map or located in our room
	if(transform.position == cameraPositionOne.transform.position || weAreWatching)
	{
	//ItIsWalking();
	}
	
}