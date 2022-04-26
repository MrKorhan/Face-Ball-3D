using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Text timerText, diamondText_;
    public Image healthImage;



    public GameObject allPanel;
    public GameObject losePanel;

    public GameObject rocketObject;
    public GameObject ballObject;
    BallMoveScript ballMoveScript;
    BallCollision ballCollision;
    RocketRandomCreatePoint rocketRandomCreatePoint;
    [HideInInspector]
    public int timeCounter_int;


    void Start()
    {
        ballMoveScript = ballObject.GetComponent<BallMoveScript>();
        ballCollision = ballObject.GetComponent<BallCollision>();
        rocketRandomCreatePoint = GetComponent<RocketRandomCreatePoint>();
        timerText.text = "16";
        timeCounter_int = 16;
        StartCoroutine(nameof(TimeCoroutine));


    }




    IEnumerator TimeCoroutine()
    {
        while (true)
        {

            timeCounter_int -= 1;
            timerText.text = timeCounter_int.ToString();

            if (timeCounter_int <= 10)
            {
                timerText.color = Color.white;
                timerText.resizeTextMaxSize = 200;
            }
            else
            {
                timerText.color = Color.black;
                timerText.resizeTextMaxSize = 120;
            }
            if (timeCounter_int <= 0 || healthImage.fillAmount <= 0)
            {
                ballMoveScript.enabled = false;
                ballCollision.enabled = false;
                rocketRandomCreatePoint.enabled = false;
                rocketObject.SetActive(false);
                allPanel.SetActive(false);

                losePanel.SetActive(true);


                StopCoroutine(nameof(TimeCoroutine));
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        if (!PlayerPrefs.HasKey("BestScoreControl"))
        {
            PlayerPrefs.SetInt("BestScoreControl", int.Parse(diamondText_.text.Remove(0, 1)));
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("BestScoreControl") < int.Parse(diamondText_.text.Remove(0, 1)))
            {
                PlayerPrefs.SetInt("BestScoreControl", int.Parse(diamondText_.text.Remove(0, 1)));
                PlayerPrefs.Save();
            }
        }

    }
}
