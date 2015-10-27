using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class escapetoquit : MonoBehaviour {

    public string finalQuitURL;

    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsc;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			Analytics.CustomEvent("quitGame", new Dictionary<string, object>{ { "gameTime", Time.timeSinceLevelLoad} });
			
            #if UNITY_EDITOR
		            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_WEBPLAYER
		            if (finalQuitURL != ""){
			            Application.OpenURL(finalQuitURL);
		            }
            #else
                        if (finalQuitURL != "")
                        {
                            Application.OpenURL(finalQuitURL);
                        }
                        Application.Quit();
            #endif
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            fpsc.enabled = true;
        }
	}
}
