using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOutput : MonoBehaviour {

    public Color outputColor;
    public MeshRenderer baseRenderer; 

	void Start () {
        baseRenderer.material.color = outputColor;
	}

    void OnTriggerEnter(Collider col)
    {
        PlayerColorPicker playerColorPicker = col.GetComponent<PlayerColorPicker>();
        playerColorPicker.currentColor = outputColor;
        playerColorPicker.playerRenderer.material.color = outputColor;
    }
	
	
}
