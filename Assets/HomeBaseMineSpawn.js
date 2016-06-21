var minePreFab:Transform;

static var fireRateMine = 3;
private var nextFire = 0.0;

function Start () {

}

function Update () {
	//checks if the spacebar was hit and will only fire a mine every 3 seconds
	if (Input.GetKeyDown("space")&& Time.time > nextFire){
		nextFire = Time.time + fireRateMine;
		var missle = Instantiate(minePreFab, transform.Find("minespawn").transform.position, Quaternion.identity);
	}
}