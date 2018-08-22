using UnityEngine;

public class CharController : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }


    void Update()
    {
        if (Input.anyKey)
            Move();
    }

    void Move()
    {
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        rb.AddForce(rightMovement);
        rb.AddForce(upMovement);
    }

}
