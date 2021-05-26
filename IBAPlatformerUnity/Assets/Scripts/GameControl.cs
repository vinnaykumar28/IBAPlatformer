using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject Parent;
    GameObject token;
    public Text clickCountTxt;
    public Button easyBtn;
    MainToken tokenUp1 = null;
    MainToken tokenUp2 = null;
    List<int> faceIndexes = new List<int>{ 0, 1, 2, 3, 0, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11};
    int finalMatched = 0;
    public static System.Random rnd = new System.Random();
    private int shuffleNum = 0;
    float tokenScale = 4;
    float yStart = 2.5f;
    int numOfTokens = 8;
    float yChange = -5f;
    private int clickCount = 0;

    void StartGame()
    {
        int startTokenCount = numOfTokens;
        float xPosition = -7.2f;
        float yPosition = yStart;
        int row = 1;
        // The camera orthographicSize is 1/2 the height of the window
        float ortho = Camera.main.orthographicSize / 7.0f;
        for (int i = 1; i < startTokenCount + 1; i++)
        {
            shuffleNum = rnd.Next(0, (numOfTokens));
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity, Parent.transform);
            temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
            temp.transform.localScale = new Vector3(ortho / tokenScale, ortho / tokenScale, 0);
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            numOfTokens--;
            xPosition = xPosition + 4;
            if (i % 4 < 1)
            {
                yPosition = yPosition + yChange;
                xPosition = -7.2f;
                row++;
            }
        }
        token.SetActive(false);
    }

    public void TokenDown(MainToken tempToken)
    {
        if (tokenUp1 == tempToken)
        {
            tokenUp1 = null;
        }
        else if (tokenUp2 == tempToken)
        {
            tokenUp2 = null;
        }
    }

    public bool TokenUp(MainToken tempToken)
    {
        bool flipCard = true;
        if (tokenUp1 == null)
        {
            tokenUp1 = tempToken;
        }
        else if (tokenUp2 == null)
        {
            tokenUp2 = tempToken;
        }
        else
        {
            flipCard = false;
        }
        return flipCard;
    }

    public void CheckTokens()
    {
        clickCount++;
        clickCountTxt.text = clickCount.ToString();
        if (tokenUp1 != null && tokenUp2 != null &&
            tokenUp1.faceIndex == tokenUp2.faceIndex)
        {
            tokenUp1.matched = true;
            tokenUp2.matched = true;
            tokenUp1 = null;
            tokenUp2 = null;
            finalMatched++;
        }

        if(finalMatched == 4){
            PlayerController.returnToLevel(3);
            SceneManager.LoadScene(3);
        }
    }

    public void EasySetup()
    {
        HideButtons();
        StartGame();
    }

    private void HideButtons()
    {
        easyBtn.gameObject.SetActive(false);
        GameObject[] startImages = 
            GameObject.FindGameObjectsWithTag("startImage");
        foreach (GameObject item in startImages)
            Destroy(item);
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
    }

    void OnEnable()
    {
        easyBtn.onClick.AddListener(() => EasySetup());
    }
}
