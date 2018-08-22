using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] drops;
    public float spawnRate = 5;
    public bool badDropPresent = false;
    public bool goodDropPresent = false;

    private float timer;
    private Timer t;

    private void Start()
    {
        timer = Time.time + spawnRate;
        t = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        float spawn = spawnRate - (t.score / 10);
        if (Time.time > timer)
        {
            timer = Time.time + spawn;
            Vector3 spawnPosition = SetRandomPosition();
            int drop = Random.Range(0, 5);
            Debug.Log(drop);
            if (goodDropPresent && badDropPresent)
            {
                return;
            }
            GameObject dropObject = Instantiate(drops[Random.Range(0, drops.Length)], spawnPosition, Quaternion.identity);
            if (drop == 0)
            {
                dropObject.transform.Rotate(new Vector3(45, 0, 90));
                badDropPresent = true;
            }
            else
            {
                dropObject.transform.Rotate(new Vector3(45, 0, 90));
                goodDropPresent = true;
            }
        }
    }

    private float RandomPosition()
    {
        return Mathf.Round(Random.Range(0, 5));
    }

    private Vector3 SetRandomPosition()
    {
        bool valid = false;
        Vector3 pos = new Vector3(RandomPosition(), 4, RandomPosition());
        while (!valid)
        {
            if ((pos.x == 5 && pos.z == 5) || (pos.x == 5 && pos.z == 0) || (pos.x == 0 && pos.z == 5) || (pos.x == 0 && pos.z == 0))
            {
                pos = new Vector3(RandomPosition(), 4, RandomPosition());
            }
            else
            {
                valid = true;
            }
        }
        return pos;
    }
}
