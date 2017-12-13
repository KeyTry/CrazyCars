using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawners : MonoBehaviour {
    Transform parent;
    GameObject carSpawners;
	// Use this for initialization
	void Start () {
        parent = transform.parent;
        carSpawners = parent.Find("CarSpawners").gameObject;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            carSpawners.SetActive(false);
        }
    }
}
