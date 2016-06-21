#pragma strict

var  enemy:Transform;
var x = 0;
var y = 0;
var z = 0;
var i = 0;
function Start () {
	
}

function Update () {

	if(GameObject.FindGameObjectsWithTag("enemy").Length == 0)
		i = 0;
	if(i == 0)
	{
		while((x < 25) && (x > -25))
			x = Random.Range(-50,50);
		while((y < 25) && (y > -25))
			y = Random.Range(-50,50);
		while((z < 25) && (z > -25))
			z = Random.Range(-50,50);
			
		var newenemy = Instantiate(enemy, Vector3(x,y,z), Quaternion.identity);
		i++;
		x = 0;
		y = 0;
		z = 0;
	}
}