using UnityEngine;

public class Tile : MonoBehaviour {

    public MeshRenderer cubeRenderer;

    public Color overrideColor;
    public Color colorBeforeRainbowMode;

    private void Update()
    {
        if (Timer.timer.rainbowMode && cubeRenderer.materials[1].color != Color.white)
        {
            cubeRenderer.materials[1].color = overrideColor;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        PlayerColorPicker playerColorPicker = col.GetComponent<PlayerColorPicker>();
        if (col.CompareTag("Player"))
        {
            cubeRenderer.materials[1].color = playerColorPicker.currentColor;

            Timer.timer.CheckTiles();
        }

    }

    public Color SetDefaultColor()
    {
        return colorBeforeRainbowMode;
    }
}
