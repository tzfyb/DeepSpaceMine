var target : Transform;
var distance = 5;

var defaultZDistance = -5.04;
var defaultYDistance = 2.05;


var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

var maxDist : float = 10;
var minDist : float = 1;
var zoomSpeed : float = 2;

private var relateZDistance : float = -5.04;
private var relateYDistance : float = 2.05;
private var relateXDistance : float = 0;
//private var relateRotation = Quaternion.identity;

private var x = 0.0;
private var y = 0.0;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (rigidbody)
		rigidbody.freezeRotation = true;
}

function Update(){
 
    transform.position.z = target.position.z +relateZDistance;
    transform.position.y = target.position.y +relateYDistance;
    transform.position.x = target.position.x +relateXDistance;
   // transform.rotation = relateRotation;
 
}

function LateUpdate () {
    if (target && Input.GetMouseButton(2)) {
    	
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
 		y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       
        var rotation = Quaternion.Euler(y, x, 0);
        var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
        
        relateZDistance = transform.position.z - target.position.z;
        relateYDistance = transform.position.y - target.position.y;
        relateXDistance = transform.position.x - target.position.x;
        //relateRotation = transform.rotation;
    }
    
    if(Input.GetAxis("Mouse ScrollWheel") > 0 && distance > minDist){
    	distance -= zoomSpeed;
    	transform.Translate(Vector3.forward * zoomSpeed);
    	relateZDistance = transform.position.z - target.position.z;
        relateYDistance = transform.position.y - target.position.y;
        relateXDistance = transform.position.x - target.position.x;
    }
    
    if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance < maxDist){           
           distance += zoomSpeed;                             
           transform.Translate(Vector3.forward * -zoomSpeed); 
           relateZDistance = transform.position.z - target.position.z;
           relateYDistance = transform.position.y - target.position.y;
           relateXDistance = transform.position.x - target.position.x;
    }
    
    if (Input.GetKey('r')){
    	relateZDistance = defaultZDistance;
    	relateYDistance = defaultYDistance;
    	relateXDistance = 0;
    	transform.rotation = Quaternion.identity;
    }
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}