#pragma strict

var explosion:Transform;

function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
//only destroys the enemys
		if(other.tag == "enemy"){
			var exp = Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
			Destroy(other.gameObject);
			Destroy (gameObject);
		}
}