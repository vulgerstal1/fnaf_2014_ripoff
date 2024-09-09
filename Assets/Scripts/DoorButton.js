//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

#pragma strict

var door : Transform;
var closed : boolean;

private var doorStartPositionY : float;
private var doorEndPositionY : float;

function Start () {
doorStartPositionY = transform.position.y;
doorEndPositionY = transform.position.y * 4;
}

function Update () {


if(closed)
{
door.transform.position.y -= Time.deltaTime*16; //-
if(door.transform.position.y <= doorStartPositionY) { door.transform.position.y = doorStartPositionY;}
}

if(!closed)
{
door.transform.position.y += Time.deltaTime*4;
if(door.transform.position.y >= doorEndPositionY) { door.transform.position.y = doorEndPositionY;}
}

}