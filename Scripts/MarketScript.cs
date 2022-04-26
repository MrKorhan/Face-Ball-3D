using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MarketScript : MonoBehaviour
{
    public Text totalDiamondText;
    public Button marketButton, settingsButton;
    public GameObject marketPanel, faceBallObject;

    BallMoveScript ballMoveScript;
    UsePowerScript usePowerScript;
    public Button[] ballButtons;
    public List<Sprite> sprites_, ball_sprites;
    public Material ball_material;

    TrailRenderer boughtRenderer;

    int total_diamond;

    void Start()
    {
        Time.timeScale = 1f;
        boughtRenderer = faceBallObject.GetComponent<TrailRenderer>();
        ballMoveScript = faceBallObject.GetComponent<BallMoveScript>();
        usePowerScript = gameObject.GetComponent<UsePowerScript>();
        PowerPrefControl();
        SpeedPrefControl();
        BallMaterialChange();

    }

    public void BallMaterialChange()
    {
        if (usePowerScript.reFillAmo_ == 0.7f)
        {
            ball_material.SetTexture("_MainTex", ball_sprites[0].texture);
            boughtRenderer.startColor = new Color(255f, 3f, 125f);
        }
        else if (usePowerScript.reFillAmo_ == 0.65f)
        {
            ball_material.SetTexture("_MainTex", ball_sprites[1].texture);
            boughtRenderer.startColor = new Color(3f, 255f, 221f);
        }
        else if (usePowerScript.reFillAmo_ == 0.6f)
        {
            ball_material.SetTexture("_MainTex", ball_sprites[2].texture);
            boughtRenderer.startColor = new Color(3f, 255f, 57f);
        }
        else if (usePowerScript.reFillAmo_ == 0.5f)
        {
            ball_material.SetTexture("_MainTex", ball_sprites[3].texture);
            boughtRenderer.startColor = new Color(209f, 255f, 3f);
        }
        else if (usePowerScript.reFillAmo_ == 0.25f)
        {
            ball_material.SetTexture("_MainTex", ball_sprites[4].texture);
            boughtRenderer.startColor = new Color(255f, 141f, 0f);
        }
        else if (usePowerScript.reFillAmo_ == .1f)
        {
            ball_material.SetTexture("_MainTex", ball_sprites[5].texture);
            boughtRenderer.startColor = Color.black;
        }
        else
        {
            ball_material.SetTexture("_MainTex", ball_sprites[6].texture);
            boughtRenderer.startColor = new Color(255f, 141f, 0f);
        }

    }

    public void BallPurchased()
    {
        if (PlayerPrefs.HasKey("BallOneBought"))
        {
            ballButtons[0].GetComponent<Image>().sprite = sprites_[0];
        }
        if (PlayerPrefs.HasKey("BallTwoBought"))
        {
            ballButtons[1].GetComponent<Image>().sprite = sprites_[1];
        }
        if (PlayerPrefs.HasKey("BallThreeBought"))
        {
            ballButtons[2].GetComponent<Image>().sprite = sprites_[2];
        }
        if (PlayerPrefs.HasKey("BallFourBought"))
        {
            ballButtons[3].GetComponent<Image>().sprite = sprites_[3];
        }
        if (PlayerPrefs.HasKey("BallFiveBought"))
        {
            ballButtons[4].GetComponent<Image>().sprite = sprites_[4];
        }
        if (PlayerPrefs.HasKey("BallSixBought"))
        {
            ballButtons[5].GetComponent<Image>().sprite = sprites_[5];
        }

    }


    public void SpeedPrefControl()
    {
        if (!PlayerPrefs.HasKey("Speed"))
        {
            ballMoveScript.speed = 10.1f;
            PlayerPrefs.SetFloat("Speed", 10.1f);
            PlayerPrefs.Save();
        }
        else
        {
            ballMoveScript.speed = PlayerPrefs.GetFloat("Speed");
        }
    }
    public void PowerPrefControl()
    {
        if (!PlayerPrefs.HasKey("Power"))
        {
            usePowerScript.reFillAmo_ = .85f;
        }
        else
        {
            usePowerScript.reFillAmo_ = PlayerPrefs.GetFloat("Power");
        }
    }

    public void MarketButtonClick()
    {
        BallPurchased();
        if (!PlayerPrefs.HasKey("TotalDiamond"))
        {
            total_diamond = 0;

        }
        else
        {
            total_diamond = PlayerPrefs.GetInt("TotalDiamond");
        }

        totalDiamondText.text = total_diamond.ToString();
        marketPanel.SetActive(true);
        marketButton.interactable = false;
        settingsButton.interactable = false;
        Time.timeScale = 0;

        if (total_diamond >= 100 || PlayerPrefs.HasKey("BallOneBought"))
        {
            ballButtons[0].interactable = true;
        }
        if (total_diamond >= 200 || PlayerPrefs.HasKey("BallTwoBought"))
        {
            ballButtons[1].interactable = true;
        }
        if (total_diamond >= 500 || PlayerPrefs.HasKey("BallThreeBought"))
        {
            ballButtons[2].interactable = true;
        }
        if (total_diamond >= 750 || PlayerPrefs.HasKey("BallFourBought"))
        {
            ballButtons[3].interactable = true;
        }
        if (total_diamond >= 2000 || PlayerPrefs.HasKey("BallFiveBought"))
        {
            ballButtons[4].interactable = true;
        }
        if (total_diamond >= 5000 || PlayerPrefs.HasKey("BallSixBought"))
        {
            ballButtons[5].interactable = true;
        }
    }

    public void ExitButton()
    {
        marketPanel.SetActive(false);
        marketButton.interactable = true;
        settingsButton.interactable = true;
        Time.timeScale = 1;
    }

    public void BallOneButtonClick()
    {

        if (!PlayerPrefs.HasKey("BallOneBought"))
        {
            total_diamond -= 100;
            totalDiamondText.text = total_diamond.ToString();
            PlayerPrefs.SetInt("TotalDiamond", total_diamond);
            PlayerPrefs.SetInt("BallOneBought", 1);
        }



        PlayerPrefs.SetFloat("Power", .70f);
        PlayerPrefs.SetFloat("Speed", 13f);
        PlayerPrefs.Save();



        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BallTwoButtonClick()
    {
        if (!PlayerPrefs.HasKey("BallTwoBought"))
        {
            total_diamond -= 200;
            totalDiamondText.text = total_diamond.ToString();
            PlayerPrefs.SetInt("TotalDiamond", total_diamond);
            PlayerPrefs.SetInt("BallTwoBought", 1);
        }

        PlayerPrefs.SetFloat("Power", .65f);
        PlayerPrefs.SetFloat("Speed", 15f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BallThreeButtonClick()
    {
        if (!PlayerPrefs.HasKey("BallThreeBought"))
        {
            total_diamond -= 500;
            totalDiamondText.text = total_diamond.ToString();
            PlayerPrefs.SetInt("TotalDiamond", total_diamond);
            PlayerPrefs.SetInt("BallThreeBought", 1);
        }

        PlayerPrefs.SetFloat("Power", .60f);
        PlayerPrefs.SetFloat("Speed", 17f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BallFourButtonClick()
    {
        if (!PlayerPrefs.HasKey("BallFourBought"))
        {
            total_diamond -= 750;
            totalDiamondText.text = total_diamond.ToString();
            PlayerPrefs.SetInt("TotalDiamond", total_diamond);
            PlayerPrefs.SetInt("BallFourBought", 1);
        }

        PlayerPrefs.SetFloat("Power", .50f);
        PlayerPrefs.SetFloat("Speed", 20f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BallFiveButtonClick()
    {
        if (!PlayerPrefs.HasKey("BallFiveBought"))
        {
            total_diamond -= 2000;
            totalDiamondText.text = total_diamond.ToString();
            PlayerPrefs.SetInt("TotalDiamond", total_diamond);
            PlayerPrefs.SetInt("BallFiveBought", 1);
        }

        PlayerPrefs.SetFloat("Power", .25f);
        PlayerPrefs.SetFloat("Speed", 27f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BallSixButtonClick()
    {

        if (!PlayerPrefs.HasKey("BallSixBought"))
        {
            total_diamond -= 5000;
            totalDiamondText.text = total_diamond.ToString();
            PlayerPrefs.SetInt("TotalDiamond", total_diamond);
            PlayerPrefs.SetInt("BallSixBought", 1);
        }

        PlayerPrefs.SetFloat("Power", .10f);
        PlayerPrefs.SetFloat("Speed", 36f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
