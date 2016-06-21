#pragma strict

var turretlevel1 : Texture;
var turretlevel2 : Texture;
var turretlevel3 : Texture;
var turretlevel4 : Texture;

var missilelevel1 : Texture;
var missilelevel2 : Texture;
var missilelevel3 : Texture;
var missilelevel4 : Texture;

var bomblevel1 : Texture;
function Start () {
	
}

function Update () {

}

//changes shields strength and health regen
function changeShield(level)
{
	switch(level)
	{
		case 1:
		ShieldLogicUpdate.shieldStrength = 20;
		ShieldLogicUpdate.shieldRate = 10;
		break;
		case 2:
		ShieldLogicUpdate.shieldStrength = 40;
		ShieldLogicUpdate.shieldRate = 8.5;
		break;
		case 3:	
		ShieldLogicUpdate.shieldStrength = 60;
		ShieldLogicUpdate.shieldRate = 7;
		break;
		default:
		ShieldLogicUpdate.shieldStrength = 80;
		ShieldLogicUpdate.shieldRate = 5.5;
		break;
	}
}

//changes bases health and health regen rate
function changeHealth(level)
{
	switch(level)
	{
		case 1:
		DestroyByHitsUpdate.health = 20;
		DestroyByHitsUpdate.healthRate = 10;
		break;
		case 2:
		DestroyByHitsUpdate.health = 40;
		DestroyByHitsUpdate.healthRate = 8.5;
		break;
		case 3:	
		DestroyByHitsUpdate.health = 60;
		DestroyByHitsUpdate.healthRate = 7;
		break;
		default:
		DestroyByHitsUpdate.health = 80;
		DestroyByHitsUpdate.healthRate = 5.5;
		break;
	}
}

//changes specified turret to specified type and level
function ChangeTurret(turret, level, type) 
{	
	switch(turret)
	{
		case 1:
			change1(level, type);
		break;
		case 2:
			change2(level, type);
		break;
		case 3:
			change3(level, type);
		break;
		case 4:
			change4(level, type);
		break; 
		case 5:
			change5(level, type);
		break; 
		default:
			change6(level, type);
		break;
	}
}

//change turret 1
function change1(level, type)
{
	//changes level of turret
	Turret1Control.level1 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret1Control.type1 = 1;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret1").renderer.material.mainTexture = turretlevel1;
			Turret1Control.fireRateTur = 1;
			break;
			case 2:
			GameObject.Find("turret1").renderer.material.mainTexture = turretlevel2;
			Turret1Control.fireRateTur = 0.75;
			break;
			case 3:
			GameObject.Find("turret1").renderer.material.mainTexture = turretlevel3;
			Turret1Control.fireRateTur = 0.5;
			break;
			default:
			GameObject.Find("turret1").renderer.material.mainTexture = turretlevel4;
			Turret1Control.fireRateTur = 0.25;
			break;
		}
	}
	else if(type == "BOMB")
	{
		Turret1Control.type1 = 3;
		GameObject.Find("turret1").renderer.material.mainTexture = bomblevel1;
	}
	else
	{
		Turret1Control.type1 = 2;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret1").renderer.material.mainTexture = missilelevel1;
			Turret1Control.fireRate = 0.2;
			break;
			case 2:
			GameObject.Find("turret1").renderer.material.mainTexture = missilelevel2;
			Turret1Control.fireRate = 0.16;
			break;
			case 3:
			GameObject.Find("turret1").renderer.material.mainTexture = missilelevel3;
			Turret1Control.fireRate = 0.12;
			break;
			default:
			GameObject.Find("turret1").renderer.material.mainTexture = missilelevel4;
			Turret1Control.fireRate = 0.08;
			break;
		}
	}
}

//change turret 2
function change2(level, type)
{
	//changes level of turret
	Turret2Control.level2 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret2Control.type2 = 1;
		
				//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret2").renderer.material.mainTexture = turretlevel1;
			Turret2Control.fireRateTur = 1;
			break;
			case 2:
			GameObject.Find("turret2").renderer.material.mainTexture = turretlevel2;
			Turret2Control.fireRateTur = 0.75;
			break;
			case 3:
			GameObject.Find("turret2").renderer.material.mainTexture = turretlevel3;
			Turret2Control.fireRateTur = 0.5;
			break;
			default:
			GameObject.Find("turret2").renderer.material.mainTexture = turretlevel4;
			Turret2Control.fireRateTur = 0.25;
			break;
		}
	}
	else if(type == "BOMB")
	{
		Turret2Control.type2 = 3;
		
		GameObject.Find("turret2").renderer.material.mainTexture = bomblevel1;
	}
	else
	{
		Turret2Control.type2 = 2;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret2").renderer.material.mainTexture = missilelevel1;
			Turret2Control.fireRate = 0.2;
			break;
			case 2:
			GameObject.Find("turret2").renderer.material.mainTexture = missilelevel2;
			Turret2Control.fireRate = 0.16;
			break;
			case 3:
			GameObject.Find("turret2").renderer.material.mainTexture = missilelevel3;
			Turret2Control.fireRate = 0.12;
			break;
			default:
			GameObject.Find("turret2").renderer.material.mainTexture = missilelevel4;
			Turret2Control.fireRate = 0.08;
			break;
		}
	}
}

//change turret 3
function change3(level, type)
{
	//changes level of turret
	Turret3Control.level3 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret3Control.type3 = 1;
		
				//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret3").renderer.material.mainTexture = turretlevel1;
			Turret3Control.fireRateTur = 1;
			break;
			case 2:
			GameObject.Find("turret3").renderer.material.mainTexture = turretlevel2;
			Turret3Control.fireRateTur = 0.75;
			break;
			case 3:
			GameObject.Find("turret3").renderer.material.mainTexture = turretlevel3;
			Turret3Control.fireRateTur = 0.5;
			break;
			default:
			GameObject.Find("turret3").renderer.material.mainTexture = turretlevel4;
			Turret3Control.fireRateTur = 0.25;
			break;
		}
	}
	else if(type == "BOMB")
	{
		Turret3Control.type3 = 3;
		
		GameObject.Find("turret3").renderer.material.mainTexture = bomblevel1;
	}
	else
	{
		Turret3Control.type3 = 2;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret3").renderer.material.mainTexture = missilelevel1;
			Turret3Control.fireRate = 0.2;
			break;
			case 2:
			GameObject.Find("turret3").renderer.material.mainTexture = missilelevel2;
			Turret3Control.fireRate = 0.16;
			break;
			case 3:
			GameObject.Find("turret3").renderer.material.mainTexture = missilelevel3;
			Turret3Control.fireRate = 0.12;
			break;
			default:
			GameObject.Find("turret3").renderer.material.mainTexture = missilelevel4;
			Turret3Control.fireRate = 0.08;
			break;
		}
	}
}

//change turret 4
function change4(level, type)
{
	//changes level of turret
	Turret4Control.level4 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret4Control.type4 = 1;
		
				//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret4").renderer.material.mainTexture = turretlevel1;
			Turret4Control.fireRateTur = 1;
			break;
			case 2:
			GameObject.Find("turret4").renderer.material.mainTexture = turretlevel2;
			Turret4Control.fireRateTur = 0.75;
			break;
			case 3:
			GameObject.Find("turret4").renderer.material.mainTexture = turretlevel3;
			Turret4Control.fireRateTur = 0.5;
			break;
			default:
			GameObject.Find("turret4").renderer.material.mainTexture = turretlevel4;
			Turret4Control.fireRateTur = 0.25;
			break;
		}
	}
	else if(type == "BOMB")
	{
		Turret4Control.type4 = 3;
		
		GameObject.Find("turret4").renderer.material.mainTexture = bomblevel1;
	}
	else
	{
		Turret4Control.type4 = 2;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret4").renderer.material.mainTexture = missilelevel1;
			Turret4Control.fireRate = 0.2;
			break;
			case 2:
			GameObject.Find("turret4").renderer.material.mainTexture = missilelevel2;
			Turret4Control.fireRate = 0.16;
			break;
			case 3:
			GameObject.Find("turret4").renderer.material.mainTexture = missilelevel3;
			Turret4Control.fireRate = 0.12;
			break;
			default:
			GameObject.Find("turret4").renderer.material.mainTexture = missilelevel4;
			Turret4Control.fireRate = 0.08;
			break;
		}
	}
}

//change turret 5
function change5(level, type)
{
	//changes level of turret
	Turret5Control.level5 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret5Control.type5 = 1;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret5").renderer.material.mainTexture = turretlevel1;
			Turret5Control.fireRateTur = 1;
			break;
			case 2:
			GameObject.Find("turret5").renderer.material.mainTexture = turretlevel2;
			Turret5Control.fireRateTur = 0.75;
			break;
			case 3:
			GameObject.Find("turret5").renderer.material.mainTexture = turretlevel3;
			Turret5Control.fireRateTur = 0.5;
			break;
			default:
			GameObject.Find("turret5").renderer.material.mainTexture = turretlevel4;
			Turret5Control.fireRateTur = 0.25;
			break;
		}
	}
	else if(type == "BOMB")
	{
		Turret5Control.type5 = 3;
		
		GameObject.Find("turret5").renderer.material.mainTexture = bomblevel1;
	}
	else
	{
		Turret5Control.type5 = 2;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret5").renderer.material.mainTexture = missilelevel1;
			Turret5Control.fireRate = 0.2;
			break;
			case 2:
			GameObject.Find("turret5").renderer.material.mainTexture = missilelevel2;
			Turret5Control.fireRate = 0.16;
			break;
			case 3:
			GameObject.Find("turret5").renderer.material.mainTexture = missilelevel3;
			Turret5Control.fireRate = 0.12;
			break;
			default:
			GameObject.Find("turret5").renderer.material.mainTexture = missilelevel4;
			Turret5Control.fireRate = 0.08;
			break;
		}
	}
}

//change turret 6
function change6(level, type)
{
	//changes level of turret
	Turret6Control.level6 = level;
	
	//changes type of turret
	if(type == "TURRET")
	{
		Turret6Control.type6 = 1;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret6").renderer.material.mainTexture = turretlevel1;
			Turret6Control.fireRateTur = 1;
			break;
			case 2:
			GameObject.Find("turret6").renderer.material.mainTexture = turretlevel2;
			Turret6Control.fireRateTur = 0.75;
			break;
			case 3:
			GameObject.Find("turret6").renderer.material.mainTexture = turretlevel3;
			Turret6Control.fireRateTur = 0.5;
			break;
			default:
			GameObject.Find("turret6").renderer.material.mainTexture = turretlevel4;
			Turret6Control.fireRateTur = 0.25;
			break;
		}
	}
	else if(type == "BOMB")
	{
		Turret6Control.type6 = 3;
		
		GameObject.Find("turret6").renderer.material.mainTexture = bomblevel1;
	}
	else
	{
		Turret6Control.type6 = 2;
		
		//changes to the correct texture based on the level
		switch(level){
			case 1:
			GameObject.Find("turret6").renderer.material.mainTexture = missilelevel1;
			Turret6Control.fireRate = 0.2;
			break;
			case 2:
			GameObject.Find("turret6").renderer.material.mainTexture = missilelevel2;
			Turret6Control.fireRate = 0.16;
			break;
			case 3:
			GameObject.Find("turret6").renderer.material.mainTexture = missilelevel3;
			Turret6Control.fireRate = 0.12;
			break;
			default:
			GameObject.Find("turret6").renderer.material.mainTexture = missilelevel4;
			Turret6Control.fireRate = 0.08;
			break;
		}
	}
}