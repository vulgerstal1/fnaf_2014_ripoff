//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal
	
	var moveWhat : Transform;
	var moveTo : GameObject;
	var moveSpeed : int;
	var rotationSpeed : int;
	private var target : Transform;
	//var EvilMass : float;
	
	function Awake() { myTransform = transform; }
	function onCollisionEnter(collision : Collision)	
	{
//		EvilMass = this.rigidbody.mass;
//		this.rigidbody.useGravity = true;
//		EvilMass =- 100;
		this.rigidbody.useGravity = true;
//		rigidbody.useGravity = true;
	}
	function Start ()
	{
		target = moveTo.transform;
	}
	function Update () {
		Debug.DrawLine(target.position, moveWhat.position, Color.yellow);
		//LookAt
		//moveWhat.rotation = Quaternion.Slerp(moveWhat.rotation, Quaternion.LookRotation(target.position - moveWhat.position), rotationSpeed * Time.deltaTime);
		moveWhat.rotation = Quaternion.Lerp(moveWhat.transform.rotation, target.rotation, moveSpeed * Time.deltaTime);
		moveWhat.position = Vector3.Lerp(moveWhat.transform.position, target.position, moveSpeed * Time.deltaTime);
	}