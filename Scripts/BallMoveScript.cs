using UnityEngine;

public class BallMoveScript : MonoBehaviour
{
    public Camera cam;

    public FixedJoystick variableJoystick;
    public Rigidbody rb;
    //[HideInInspector]
    public float speed;



    int a = 5;


    public void FixedUpdate()
    {
        float mH = variableJoystick.Horizontal;
        float mV = variableJoystick.Vertical;

        Vector3 input = new Vector3(mH, 0, mV);

        float cameraRot = cam.transform.rotation.eulerAngles.y;

        rb.position += Quaternion.Euler(0, cameraRot, 0) * input * speed * Time.deltaTime;



        if (mV > 0.2f || mV < -0.2f || mH > 0.2f || mH < -0.2f)
        {
            transform.rotation = Quaternion.Euler(a += 25, cameraRot, 0);
        }



    }

}
