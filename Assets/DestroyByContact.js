#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
	//only destroys enemys
	if(other.tag == "enemy")
		Destroy(other.gameObject);
}