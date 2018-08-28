using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDesotryInventory : MonoBehaviour {

    private static bool inventoryExist;


	// Use this for initialization
	void Start () {
            //dont destory inventory system 
            DontDestroyOnLoad(transform.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
