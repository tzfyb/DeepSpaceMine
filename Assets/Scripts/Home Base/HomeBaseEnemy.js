

function Start () {
	//has the enemy aim towards the base and also adds force into that direction
	transform.LookAt(GameObject.FindGameObjectWithTag("HomeBase").transform);
	rigidbody.AddForce(transform.forward*150);
}

function Update () {

}
