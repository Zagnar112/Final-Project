using UnityEngine;

public class Bouncing : MonoBehaviour
{
    [Header("Base Values")]
    public float baseBounceHeight = 2f;
    public float baseBounceSpeed = 2f;

    [Header("Random Range")]
    public float heightRandomRange = 0.5f;
    public float speedRandomRange = 0.5f;

    private float bounceHeight;
    private float bounceSpeed;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Save the ORIGINAL starting position
        startPos = transform.position;
        
        // Randomize values when instantiated
        bounceHeight = baseBounceHeight + Random.Range(-heightRandomRange, heightRandomRange);
        bounceSpeed = baseBounceSpeed + Random.Range(-speedRandomRange, speedRandomRange);
    }

    // Update is called once per frame
    void Update()
    {
        // Bounce ONLY upward from the starting position
        float bounce = (Mathf.Sin(Time.time * bounceSpeed) + 1f) / 2f;

        float newY = startPos.y + bounce * bounceHeight;

        transform.position = new Vector3(
            startPos.x,
            newY,
            startPos.z
        );
    }
}
