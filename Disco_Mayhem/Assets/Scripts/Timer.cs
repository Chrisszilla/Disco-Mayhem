using UnityEngine;
using UnityEngine.UI;
using Audio;

public class Timer : MonoBehaviour {

    public Color[] colorArray;
    public MeshRenderer timerRenderer;
    public float maxTime = 10;
    public Color currentColor;
    public Text scoreText;
    public bool rainbowMode = false;
    public MusicAsset basicMusic;
    public MusicAsset rainbowMusic;
    public AudioLooper looper;

    public float rainbowTimer;
    public float score = 0;

    public static Timer timer;

    private Tile[] allTiles;
    private Color targetColor;
    private int targetNumber = 0;

    private float currentTime;
    private bool hasUpdated = false; //Is de Audio Looper geupdated?

    public Transform visual; //Discoball

	void Start ()
    {
        timer = this;
        allTiles = FindObjectsOfType<Tile>();
        timerRenderer.material.color = colorArray[0];
        scoreText.text = "Score: 0";
    }

	void Update ()
    {
        visual.Rotate(0, 0, Time.deltaTime * 10, Space.Self);
        if (rainbowMode)
        {
            if (!hasUpdated)
            {
                foreach (Tile tile in allTiles)
                {
                    tile.colorBeforeRainbowMode = tile.cubeRenderer.materials[1].color;
                }
                LampFlash.flasher.Flash();
                hasUpdated = true;
                looper.musicAsset = rainbowMusic;
                looper.Initialize();
            }
            rainbowTimer -= Time.deltaTime;
            foreach (Tile tile in allTiles)
            {
                if (tile.overrideColor != targetColor || tile.cubeRenderer.materials[1].color != Color.white)
                {
                    tile.overrideColor = Color.Lerp(tile.overrideColor, targetColor, Time.deltaTime * 15);
                }
                else
                {
                    targetNumber = (targetNumber + 1) % colorArray.Length;
                    targetColor = colorArray[targetNumber];
                }
            }
            if (rainbowTimer <= 0)
            {
                if (hasUpdated)
                {
                    hasUpdated = false;
                    foreach (Tile tile in allTiles)
                    {
                        tile.colorBeforeRainbowMode = tile.SetDefaultColor();
                    }
                    looper.musicAsset = basicMusic;
                    looper.Initialize();
                }
                rainbowMode = false;
            }
            return;
        }
        currentTime = currentTime - Time.deltaTime;
        visual.localScale = Vector3.Lerp(new Vector3(0.01f, 0.01f, 0.01f), new Vector3(1, 1, 1), currentTime / maxTime);
        if (currentTime < 0)
        {
            currentTime = maxTime;
            currentColor = colorArray[Random.Range(0, colorArray.Length)];
            timerRenderer.material.color = currentColor;
            hasUpdated = false;
        }
	}

    public void CheckTiles()
    {
        foreach(Tile tile in allTiles)
        {
            if((tile.cubeRenderer.materials[1].color != currentColor && !rainbowMode) || (rainbowMode && tile.cubeRenderer.materials[1].color == Color.white))
            {
                return;
            }
        }

        //Wint de speler een ster
        //Voeg een punt toe;
        Debug.Log("Player Scores A Star!");
        if (true)
        {
            hasUpdated = true;
            score++;
            scoreText.text = "Score: " + score.ToString();
            foreach (Tile tile in allTiles)
            {
                tile.cubeRenderer.materials[1].color = Color.white;
            }
        }
    }
}
