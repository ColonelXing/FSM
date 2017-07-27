using UnityEngine;
using System.Collections;

public class characterRotate : MonoBehaviour {

	public GameObject frog;
	
	
	
	private Rect FpsRect ;
	private string frpString;
	
	private GameObject instanceObj;
	public GameObject[] gameObjArray=new GameObject[9];
	public AnimationClip[] AniList  = new AnimationClip[4];
	
	float minimum = 2.0f;
	float maximum = 50.0f;
	float touchNum = 0f;
	string touchDirection ="forward"; 
	private GameObject Villarger_A_Girl_prefab;
	
	// Use this for initialization
	void Start () {
		
		//frog.animation["dragon_03_ani01"].blendMode=AnimationBlendMode.Blend;
		//frog.animation["dragon_03_ani02"].blendMode=AnimationBlendMode.Blend;
		//Debug.Log(frog.GetComponent("dragon_03_ani01"));
		
		//Instantiate(gameObjArray[0], gameObjArray[0].transform.position, gameObjArray[0].transform.rotation);
	}
	
 void OnGUI() {
	  if (GUI.Button(new Rect(20, 10, 70, 30),"Idle")){
		 frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Idle");
	  }
	    if (GUI.Button(new Rect(90, 10, 70, 30),"Greeting")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Greeting");
	  }
		   if (GUI.Button(new Rect(160, 10, 70, 30),"Talk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Talk");
	  }
	     if (GUI.Button(new Rect(230, 10, 70, 30),"Walk")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Walk");
	  } 
		if (GUI.Button(new Rect(300, 10, 70, 30),"Run")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Run00");
	  } 
		if (GUI.Button(new Rect(370, 10, 70, 30),"Jump")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Jump_NoDagger");
	  } 
			if (GUI.Button(new Rect(440, 10, 70, 30),"DrawDagger")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Once;
		  	frog.GetComponent<Animation>().CrossFade("DrawDagger");
	  } 
			if (GUI.Button(new Rect(510, 10, 70, 30),"ATK_standy")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Attackstandy");
	  }
			if (GUI.Button(new Rect(20, 40, 70, 30),"Attack00"))
        { //580, 20, 70, 40
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Attack");
	  }
			if (GUI.Button(new Rect(90, 40, 70, 30),"Attack01"))
        {//650, 20, 70, 40
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Attack01");
	  }
			if (GUI.Button(new Rect(160, 40, 70, 30),"Attack02"))
        {//720, 20, 70, 40
            frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Attack02");
	  }
			if (GUI.Button(new Rect(230, 40, 70, 30),"Combo"))
        {//790, 20, 70, 40
            frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Combo");
	  }
			if (GUI.Button(new Rect(300, 40, 70, 30),"Skill"))
        {//20, 60, 70, 40
            frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Skill");
	  }
			if (GUI.Button(new Rect(370, 40, 70, 30),"M_Avoid"))
        {//90, 60, 70, 40
            frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("M_Avoid");
			
	  }	if (GUI.Button(new Rect(440, 40, 70, 30),"L_Avoid"))
        {//160, 60, 70, 40
            frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("L_Avoid");
			
	  }	if (GUI.Button(new Rect(510, 40, 70, 30),"R_Avoid"))
        {//230, 60, 70, 40
            frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("R_Avoid");
	  }
			if (GUI.Button(new Rect(20, 70, 70, 30),"Run01"))
        {//300, 60, 70, 40
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Run");
	  }
			if (GUI.Button(new Rect(90, 70, 70, 30),"Jump"))
        {//370, 60, 70, 40
            frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Jump");
	  }
			if (GUI.Button(new Rect(160, 70, 70, 30),"PickUp")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Pickup");
	  }
				if (GUI.Button(new Rect(230, 70, 70, 30),"Damage")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Damage");
	  }
				if (GUI.Button(new Rect(300, 70, 70, 30),"Death")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Death");
	  }
			if (GUI.Button(new Rect(370, 70, 70, 30),"Elevator")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Elevator");
	  }
			if (GUI.Button(new Rect(440, 70, 140, 30),"GangnamStyle")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("GangnamStyle");
	  }  
				if (GUI.Button(new Rect(20, 250, 140, 30),"V  1.6")){
		  frog.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		  	frog.GetComponent<Animation>().CrossFade("Idle");
	  } 
				//if (GUI.Button(new Rect(600, 480, 140, 40),"Ver 1.2")){
		 // frog.animation.wrapMode= WrapMode.Loop;
		  //	frog.animation.CrossFade("Idle");
	  //}
		
		
 }
	
	// Update is called once per frame
	void Update () {
		
		//if(Input.GetMouseButtonDown(0)){
		
			//touchNum++;
			//touchDirection="forward";
		 // transform.position = new Vector3(0, 0,Mathf.Lerp(minimum, maximum, Time.time));
			//Debug.Log("touchNum=="+touchNum);
		//}
		/*
		if(touchDirection=="forward"){
			if(Input.touchCount>){
				touchDirection="back";
			}
		}
	*/
		 
		//transform.position = Vector3(Mathf.Lerp(minimum, maximum, Time.time), 0, 0);
	if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		//frog.transform.Rotate(Vector3.up * Time.deltaTime*30);
	}
	
}
