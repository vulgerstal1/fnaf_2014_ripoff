//This script is a part of Five Nights at Teddy's Project by Dima Vulgerstal
//vulgerstal@gmail.com		youtube.com/vulgerstal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDachaCS : MonoBehaviour
{
    public Transform moveWhat;
	public GameObject moveTo ;
	public int moveSpeed;
	public int rotationSpeed;
	private Transform target;
	//public float EvilMass;
	
	//void Awake() { myTransform = transform; }
    void onCollisionEnter(Collision collision)
    {
        //		EvilMass = GetComponent<Rigidbody>()..mass;
        //		GetComponent<Rigidbody>()..useGravity = true;
        //		EvilMass =- 100;
        GetComponent<Rigidbody>().useGravity = true;
        //		rigidbody.useGravity = true;
    }
    void Start()
    {
        target = moveTo.transform;
    }
    void Update()
    {
        Debug.DrawLine(target.position, moveWhat.position, Color.yellow);
        //LookAt
        //moveWhat.rotation = Quaternion.Slerp(moveWhat.rotation, Quaternion.LookRotation(target.position - moveWhat.position), rotationSpeed * Time.deltaTime);
        moveWhat.rotation = Quaternion.Lerp(moveWhat.transform.rotation, target.rotation, moveSpeed * Time.deltaTime);
        moveWhat.position = Vector3.Lerp(moveWhat.transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
