using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VisualNovel : MonoBehaviour
{
    [SerializeField] Image AmberImage;
    [SerializeField] Image JadeImage;
    [SerializeField] Image JasperImage;
    int currIndex = 0;
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] GameObject darkBackground;
    public List<int> YGRorder;
    public List<string> textOrder;

    [SerializeField] bool allVisible = true;
    //[SerializeField] GameObject darkBackground;

    [SerializeField] CharacterMovement charas;
    public AudioSource talk;

    bool dismissTips = false;
    [SerializeField] Button dismisButton;

    private void Start()
    {
        if (allVisible)
        {
            AmberImage.gameObject.SetActive(true);
            JasperImage.gameObject.SetActive(true);
            JadeImage.gameObject.SetActive(true);
        } else
        {
            AmberImage.gameObject.SetActive(false);
            JasperImage.gameObject.SetActive(false);
            JadeImage.gameObject.SetActive(false);
            textBox.gameObject.SetActive(false);
            darkBackground.SetActive(false);
            dismisButton.gameObject.SetActive(false);
            Next();
            currIndex = 0;
        }
    }

    public void Display(int YGR, string textToDisplay)
    {
        textBox.gameObject.SetActive(true);
        darkBackground.SetActive(true);
        if (YGR == 0)
        {
            textBox.color = Color.yellow;
            textBox.text = "Amber: ";
            if (!allVisible)
            {
                AmberImage.gameObject.SetActive(true);
                JasperImage.gameObject.SetActive(false);
                JadeImage.gameObject.SetActive(false);
            }
        } else if(YGR == 1)
        {
            textBox.color = Color.green;
            textBox.text = "Jade: ";
            if (!allVisible)
            {
                AmberImage.gameObject.SetActive(false);
                JadeImage.gameObject.SetActive(true);
                JasperImage.gameObject.SetActive(false);
            }

        } else
        {
            textBox.color = Color.red;
            textBox.text = "Jasper: ";
            if (!allVisible)
            {
                AmberImage.gameObject.SetActive(false);
                JasperImage.gameObject.SetActive(true);
                JadeImage.gameObject.SetActive(false);

            }
        }

        textBox.text += textToDisplay;
        if(talk)
            talk.Play();
    }

    public void Next()
    {
        if (currIndex < YGRorder.Count)
        {
            Display(YGRorder[currIndex], textOrder[currIndex]);
            currIndex++;
        } else if(allVisible)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        } else
        {
            AmberImage.gameObject.SetActive(false);
            JasperImage.gameObject.SetActive(false);
            JadeImage.gameObject.SetActive(false);

            textBox.gameObject.SetActive(false);
            darkBackground.SetActive(false);
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if(!allVisible && !charas.isActiveGreen() && currIndex == 0)
        {
            dismisButton.gameObject.SetActive(true);
            Debug.Log(currIndex);
            if (charas.isActiveYellow())
            {
                Display(YGRorder[4], textOrder[4]);
                currIndex = 4;
            } else if (charas.isActiveRed())
            {
                Display(YGRorder[1], textOrder[1]);
                currIndex = 1;
            }
        } else if (!allVisible && currIndex != 0 && !dismissTips)
        {
            if (charas.isActiveYellow())
            {
                Display(YGRorder[4], textOrder[4]);
                currIndex = 3;
            }
            else if (charas.isActiveRed())
            {
                Display(YGRorder[1], textOrder[1]);
                currIndex = 1;
            } else if(charas.isActiveGreen())
            {
                Display(YGRorder[2], textOrder[2]);
                currIndex = 2;
            }
        }
    }

    public void Dismiss()
    {
        dismissTips = true;
        AmberImage.gameObject.SetActive(false);
        JasperImage.gameObject.SetActive(false);
        JadeImage.gameObject.SetActive(false);
        textBox.gameObject.SetActive(false);
        darkBackground.SetActive(false);
        dismisButton.gameObject.SetActive(false);

    }


}
