using UnityEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    public float moveSpeed = 50;
    public float drag = 0.98f;
    public float maxSpeed = 15;
    public float steerAngle = 20;
    public float traction = 1;
    private Vector3 moveForce;

    // Update is called once per frame
    void Update()
    {
        moveForce += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

        transform.position += moveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * moveForce.magnitude * steerAngle * Time.deltaTime);

        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);

        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
    }
}
