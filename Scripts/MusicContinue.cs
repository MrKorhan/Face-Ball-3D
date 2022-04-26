using UnityEngine;
public class MusicContinue : MonoBehaviour
{

    private static MusicContinue obje = null;

    void Awake()
    {
        if (obje == null)
        {
            obje = this;
            DontDestroyOnLoad(this);
        }
        else if (this != obje)
        {
            Destroy(gameObject);
        }
    }

}
