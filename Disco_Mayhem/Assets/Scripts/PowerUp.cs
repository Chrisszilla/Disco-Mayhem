using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Spawner>().goodDropPresent = false;
            Destroy(GetComponent<MeshRenderer>());
            foreach (Collider cols in GetComponents<Collider>())
            {
                Destroy(cols);
            }
            PowerUpAction();
        }
    }

    private void PowerUpAction()
    {
        Timer t = FindObjectOfType<Timer>();
        t.rainbowMode = true;
        t.rainbowTimer = 8;
        Destroy(gameObject);
    }

    private void Update()
    {
        if (meshRenderer && meshRenderer.material.color.a < 1)
        {
            meshRenderer.material.color = new Color(meshRenderer.material.color.r, meshRenderer.material.color.g, meshRenderer.material.color.b, Mathf.MoveTowards(meshRenderer.material.color.a, 1, Time.deltaTime));
        }

    }
}
