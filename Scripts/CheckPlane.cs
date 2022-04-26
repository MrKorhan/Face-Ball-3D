using UnityEngine;
using UnityEngine.UI;

public class CheckPlane : MonoBehaviour
{
    public Image health_image;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(0, 1f, 0);
        health_image.fillAmount -= 0.34f;
    }
}
