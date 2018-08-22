using UnityEngine;

public class Drop : MonoBehaviour {

    public Transform pivot;

    [SerializeField] private float desiredRotation;
    private bool active = true;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        pivot = FindObjectOfType<PivotToken>().transform;
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && active)
        {
            FindObjectOfType<Spawner>().badDropPresent = false;
            active = false;
            desiredRotation += 180;
            Destroy(GetComponentInChildren<MeshRenderer>());
            foreach (CapsuleCollider cols in GetComponents<CapsuleCollider>())
            {
                Destroy(cols);
            }
        }
    }

    private void Update()
    {
        if (meshRenderer && meshRenderer.materials[0].color.a < 1)
        {
            meshRenderer.materials[0].color = new Color(meshRenderer.materials[0].color.r, meshRenderer.materials[0].color.g, 
                meshRenderer.materials[0].color.b, Mathf.MoveTowards(meshRenderer.materials[0].color.a, 1, Time.deltaTime));
            meshRenderer.materials[1].color = new Color(meshRenderer.materials[1].color.r, meshRenderer.materials[1].color.g,
                meshRenderer.materials[1].color.b, Mathf.MoveTowards(meshRenderer.materials[1].color.a, 1, Time.deltaTime));
        }
        if (desiredRotation > 0)
        {
            desiredRotation--;
            pivot.Rotate(0, 1, 0);
            if (desiredRotation == 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
