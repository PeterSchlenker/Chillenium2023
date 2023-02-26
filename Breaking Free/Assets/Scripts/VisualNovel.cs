using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public List<int> YGRorder;
    public List<string> textOrder;

    public void Display(int YGR, string textToDisplay)
    {
        if(YGR == 0)
        {
            textBox.color = Color.yellow;
            textBox.text = "Amber: ";
        } else if(YGR == 1)
        {
            textBox.color = Color.green;
            textBox.text = "Jade: ";

        } else
        {
            textBox.color = Color.red;
            textBox.text = "Jasper: ";
        }

        textBox.text += textToDisplay;
    }

    private void Start()
    {

    }

    public void Next()
    {
        if (currIndex < YGRorder.Count - 1)
        {
            Display(YGRorder[currIndex], textOrder[currIndex]);
            currIndex++;
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
