using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Collections.Generic;


public class BallCollision : MonoBehaviour
{
    public Image image;
    public GameObject cm_;

    public Text diamond_text;

    CinemachineCollider cm_collider;
    BallMoveScript ballMoveScript;

    public GameObject timerObject;
    Timer timer;

    public GameObject auidoObject;
    AudioSource audio_source;

    int totalDiamond;






    [Space(15f)]
    public List<Transform> CheckPointTransforms;

    [HideInInspector]
    public int diamond_counter;

    void Start()
    {
        diamond_counter = 0;
        cm_collider = cm_.GetComponent<CinemachineCollider>();
        ballMoveScript = gameObject.GetComponent<BallMoveScript>();
        timer = timerObject.GetComponent<Timer>();

        audio_source = auidoObject.GetComponent<AudioSource>();



        if (!PlayerPrefs.HasKey("TotalDiamond"))
        {
            totalDiamond = 0;

        }
        else
        {
            totalDiamond = PlayerPrefs.GetInt("TotalDiamond");
        }



    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Flash"))
        {
            image.fillAmount = 1;
            int flash_pos = Random.Range(0, CheckPointTransforms.Count);
            other.transform.position = new Vector3(CheckPointTransforms[flash_pos].position.x,
            other.transform.position.y, CheckPointTransforms[flash_pos].position.z);
        }

        if (other.gameObject.CompareTag("CheckPoint"))
        {
            audio_source.Play();
            int check_pos = Random.Range(0, CheckPointTransforms.Count);
            other.transform.parent.position = new Vector3(CheckPointTransforms[check_pos].position.x,
            other.transform.position.y, CheckPointTransforms[check_pos].position.z);
            image.fillAmount = 1;
            timer.timeCounter_int += 18;

            diamond_counter += 1;
            diamond_text.text = "x" + diamond_counter.ToString();



            totalDiamond += 1;
            PlayerPrefs.SetInt("TotalDiamond", totalDiamond);
            PlayerPrefs.Save();


        }

    }




}
