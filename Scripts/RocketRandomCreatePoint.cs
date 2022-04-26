using System.Collections.Generic;
using UnityEngine;

public class RocketRandomCreatePoint : MonoBehaviour
{
    public GameObject rocket_;
    [Space(10f)]
    public List<Transform> rocketCreate_point;

    void Start()
    {
        rocket_.transform.position = rocketCreate_point[Random.Range(0, rocketCreate_point.Count)].position;
        InvokeRepeating(nameof(CreateRocketInvoke), 1f, 1f);


    }



    public void CreateRocketInvoke()
    {
        if (!rocket_.activeSelf)
        {
            rocket_.transform.position = rocketCreate_point[Random.Range(0, rocketCreate_point.Count)].position;
            rocket_.SetActive(true);
        }
    }

    void OnDestroy()
    {
        CancelInvoke(nameof(CreateRocketInvoke));

    }


}
