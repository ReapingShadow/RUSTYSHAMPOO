using UnityEngine;
using System.Collections;


    public class CameraController : MonoBehaviour
    {
    private Vector2 pitchMinMax = new Vector2(0, 30);
    private PlayerManager pm;
    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private Transform target;
    public GameObject Parent;
    float dstToTarget = 5;
    public float cameraMoveSensitivity = 10;
    float yaw;  //Rotation around Y Axis
    float pitch = 75;//Rotation around X Axis
    float zoomInOut;
    private bool xbox = false;

    private void Start()
    {
        target = Parent.GetComponentInChildren<Rigidbody>().transform;
        pm = Parent.GetComponent<PlayerManager>();
    }
    void LateUpdate()
    {
        if (pm.InputID == 1)
        {
            xbox = true;
        }
        else
            xbox = false;

        if (xbox)
        {
            yaw += Input.GetAxis("RXAxis") * cameraMoveSensitivity;
            pitch -= Input.GetAxis("RYAxis") * cameraMoveSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
        }
        else
        {
           

            yaw += Input.GetAxis("Mouse X") * cameraMoveSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * cameraMoveSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
           
        }
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
        transform.position = target.position - transform.forward * dstToTarget;
    }

}
