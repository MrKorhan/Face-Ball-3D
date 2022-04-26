using UnityEngine;
using UnityEngine.UI;

public class BestScoreScript : MonoBehaviour
{
    Text best_score_text;
    public Text dia_text_;

    private void OnEnable()
    {
        best_score_text = GetComponent<Text>();
        if (!PlayerPrefs.HasKey("BestScoreControl"))
        {
            best_score_text.text = "Best Score: " + dia_text_.text.Remove(0, 1);
        }
        else
        {
            best_score_text.text = "Best Score: " + PlayerPrefs.GetInt("BestScoreControl").ToString();
        }
    }
}
