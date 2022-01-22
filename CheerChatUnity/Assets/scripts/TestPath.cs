using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPath : MonoBehaviour {

	Text mtext;

	// Use this for initialization
	void Start () {
		mtext = GetComponent<Text>();

		string dataPath = Application.dataPath;
		string persistentDataPath = Application.persistentDataPath;

		mtext.text = persistentDataPath + "   "+dataPath;
	}
	
	
}
