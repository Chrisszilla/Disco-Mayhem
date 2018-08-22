using UnityEngine;

public class HueLamp : MonoBehaviour {

    public Color[] backgroundColors;
    public int targetNumber;

    private Light lamp;
    private Color targetColor;

    private void Start()
    {
        targetColor = backgroundColors[targetNumber];
        lamp = GetComponent<Light>();
    }

    private void Update()
    {
        if (lamp.color != targetColor)
        {
            lamp.color = Color.Lerp(lamp.color, targetColor, Time.deltaTime * (Timer.timer.rainbowMode ? 10 : 5));
        }
        else
        {
            targetNumber = (targetNumber + 1) % backgroundColors.Length;
            targetColor = backgroundColors[targetNumber];
        }
    }

}
