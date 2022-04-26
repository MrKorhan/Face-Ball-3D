using UnityEngine;
using UnityEngine.UI;

public class RocketTargetScript : MonoBehaviour
{
    public Image health_;
    public Transform targetBall;

    Vector3 direction_;
    Vector3 instantiateTarget_pos;

    public float radius = 15.0F;
    public float power = 10.0F;



    void Update()
    {
        transform.LookAt(instantiateTarget_pos);
        direction_ = instantiateTarget_pos - transform.position;
        transform.Translate(direction_.normalized * 80f * Time.deltaTime, Space.World);


        if (Mathf.Round(direction_.x) <= 0.3)
        {
            BombForce();
            gameObject.SetActive(false);
        }




    }



    private void OnEnable()
    {

        instantiateTarget_pos = targetBall.position;

    }

    public void BombForce()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 15, ForceMode.Impulse);

            if (hit.gameObject.CompareTag("Ball"))
            {
                health_.fillAmount -= .34f;
            }

        }

    }
}
