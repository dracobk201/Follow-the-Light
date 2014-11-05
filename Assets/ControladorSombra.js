#pragma strict
public var Xpos : float;
public var Ypos : float;
public var max : boolean;
//public var enemigo : GameObject;

public var Vert : boolean;
public var maxAmount : int;
public var step : float;

function Start () { 
	Xpos = transform.position.x; Ypos = transform.position.y;
	//enemigo = new GameObject();
	}

function FixedUpdate () {

if (Vert) { if (transform.position.y >= Ypos + maxAmount) { max = true; }

     else if (transform.position.y <= Ypos)
     {
         max = false;
     }
 }
 
 else
 {
     if ((transform.position.x >= Xpos + maxAmount))// || (Collider2D.Equals(enemigo)))
     {
         max = true;
         //enemigo = Transform.position (0,0,0);
     }
     
     else if (transform.position.x <= Xpos)
     {
         max = false;
     }
 }
 
 if (Vert)
 {
     if (!max)
     {
         transform.position.y += step;
     }
     
     else
     {
         transform.position.y -= step;
     }
 }
 
 else
 {
     if (!max)
     {
         transform.position.x += step;
     }
     
     else
     {
         transform.position.x -= step;
     }
 }
}

function OnCollisionEnter2D (col : Collision2D) {
	if(col.gameObject.tag == "Player") {
	max = true;
	Debug.Log("Paso");
	}
	Debug.Log("PasoPorLaFuncion");
}