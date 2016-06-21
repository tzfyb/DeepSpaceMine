#pragma strict

 var target : Transform; 
 var moveSpeed = 10;; 
 var rotationSpeed = 1; 
 var stop : float=10;
 var myTransform : Transform; 
 var fireRate : float=3;
 var nextFire : float=0;
 var shot : GameObject;
 var shotSpawn : Transform;
	
 function Awake()
 {
     myTransform = transform; 
 }
  
 function Start()
 {
      target = GameObject.FindWithTag("Player").transform; 
      shotSpawn = transform.Find("ShotSpawn");
  
 }
  
 function Update () {
 	if (Time.time > nextFire)
	{
		nextFire = Time.time + fireRate;
		//GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
		Instantiate(shot, myTransform.rigidbody.position, myTransform.rigidbody.rotation);
	}
     //rotate to look at the player
     var distance = Vector3.Distance(myTransform.position, target.position);
     myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
     Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
  
  
     if(distance>stop){
  
     //move towards the player
     myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
     Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
     myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
     }
     else if (distance<=stop) {
     myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
     Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
     }
  
  
 }