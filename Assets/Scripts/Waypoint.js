//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

#pragma strict
var objectToMove : GameObject;
var forward : GameObject;
var backward : GameObject;
var left : GameObject;
var right : GameObject;
var moveSpeed : int;
var randomMinimumTime : float = 20.0f;
var randomMaximumTime : float = 50.0f;
var randomTime : int;
var randomDirection : int;
var activated : boolean;
var tictoc : boolean;
var picked : boolean;
var rotationSpeed : int;
private var target : Transform;

var lolo : boolean; //true
var huhu : int;
var hoho : int;
var time : boolean;
var timeLeft : float = 360;
var jojo : int;
var freeze : boolean;
//var timeStopped : boolean; //made to stop enemies when we're looking at'em through camera.
//so all enemies have ultraspeed. only foxy has normal run speed in corridor.
//var test : boolean;

function Update () {
	
//	if(timeStopped) { time=false; }
//	if(!timeStopped) { time=true; }
	
	if(objectToMove.transform.position == transform.position && !lolo)
	{
	lolo = true;
	huhu = Random.Range(1,5); //5,30
	hoho = Random.Range(1,5);
	timeLeft = Random.Range(1,5); //15,60		5,15
	time=true;
	}
	
	if(time)
	{
	timeLeft -= Time.deltaTime;
	}
	
	if(timeLeft < 0) { timeLeft = 0; }
	if(timeLeft == 0 /*&& !test*/)
	{
	timeLeft = 0.1; //(commented by test)
	//test=true;
	time=false;
	jojo = 3;
	}


if(jojo==3 && objectToMove.transform.position != forward.transform.position)
{
	moveSpeed=3;
	target = forward.transform;
	//if(time) //test
	//{
	FollowTransform();
	//}
}


//Here we check proximity
if (Vector3.Distance(objectToMove.transform.position, forward.transform.position) < 2.5) {freeze = true;}
if (Vector3.Distance(objectToMove.transform.position, forward.transform.position) > 2.5) {freeze = false;}


if(jojo==3 && objectToMove.transform.position == forward.transform.position)
{
	jojo=0;

	if(lolo) { lolo = false; /*test=false;*/ } //test
}

//if(objectToMove.transform.position == transform.position)
//{
//lolo=false;
//}

//if(objectToMove.transform.position == forward.transform.position)
//{
//forward.GetComponent(Waypoint).lolo=false;
//}



	if(/*randomDirection == 1*/ randomDirection != 0)
	{
	moveSpeed=3;
	target = forward.transform;
	FollowTransform();
	forward.GetComponent(Waypoint).activated=true;
	//if(objectToMove.transform != forward.transform) { activated=false; }
	}

if(tictoc/* && randomTime > randomMinimumTime*/ ) {randomTime -= Time.deltaTime; }
//if(tictoc && timeIsZero) {randomTime =; }
if(randomTime < 0) { randomTime = 0; }


if(objectToMove.transform.position == transform.position && activated)
{
activated = false;
randomTime = Random.Range(randomMinimumTime,randomMaximumTime);	//Pick random delay before move
tictoc=true;
	if(/*randomTime == 0 && */tictoc && !picked)
	{
	randomDirection = Random.Range(1,5);							//Pick random movement direction
	//if(randomDirection == 0) { Random.Range(2,5); }
	tictoc=false;
	}
}


}

function FollowTransform()
{
Debug.DrawLine(target.position, objectToMove.transform.position, Color.yellow);
objectToMove.transform.rotation = Quaternion.Lerp(objectToMove.transform.rotation, target.rotation, moveSpeed * Time.deltaTime);
objectToMove.transform.position = Vector3.Lerp(objectToMove.transform.position, target.position, moveSpeed * Time.deltaTime);
}