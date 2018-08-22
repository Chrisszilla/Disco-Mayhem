using UnityEngine;

public class PlayerColorPicker : MonoBehaviour {
    public Color currentColor;
    public MeshRenderer playerRenderer;

    public static PlayerColorPicker picker;

	void Start () {
        picker = this;
	}

}
