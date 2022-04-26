using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UsePowerScript : MonoBehaviour
{
    public Image fillImage;
    bool power = false;
    BallMoveScript ballMoveScript;
    TrailRenderer ballTrail_;
    [SerializeField] GameObject ballObject;

    [HideInInspector]
    public float reFillAmo_;



    private void Start()
    {
        ballMoveScript = ballObject.GetComponent<BallMoveScript>();
        ballTrail_ = ballObject.GetComponent<TrailRenderer>();




        StartCoroutine(nameof(UseFlashCoroutine));

    }

    public void UsePower()
    {
        ballTrail_.startWidth = ballObject.transform.localScale.x * 0.5f;

        power = true;

    }
    public void ExitPower()
    {
        power = false;
    }


    IEnumerator UseFlashCoroutine()
    {
        while (true)
        {

            if (power && fillImage.fillAmount > 0)
            {
                fillImage.fillAmount -= reFillAmo_ * Time.deltaTime;

                ballMoveScript.speed += 5f * Time.deltaTime;
                ballTrail_.enabled = true;
            }
            else
            {

                ballTrail_.enabled = false;
                if (ballMoveScript.speed >= PlayerPrefs.GetFloat("Speed"))
                {
                    ballMoveScript.speed -= 25f * Time.deltaTime;
                }

            }

            yield return new WaitForEndOfFrame();
        }
    }
}
