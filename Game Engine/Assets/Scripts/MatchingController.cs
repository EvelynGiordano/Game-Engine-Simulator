using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingController : MonoBehaviour
{
    public GameObject original;
    public GameObject greenGirl;
    public GameObject goldGirl;

    public GameObject winText;
    GameObject card;
    List<int> faceindexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8};
    public static System.Random random = new System.Random();
    public int shuffle = 0;
    int[] visibleFaces = { -1, -2 };

    List<GameObject> currentlyUp = new List<GameObject>();
    List<GameObject> currentlyDown = new List<GameObject>();

    int matches = 0;


    private void Start()
    {
        int indexesLength = faceindexes.Count;
        float yPosition = 0f;
        float xPosition = -15f;

        shuffle = random.Next(0, (faceindexes.Count));
        original.GetComponent<MainCard>().faceIndex = faceindexes[shuffle];
        original.GetComponent<MainCard>().ChangeSprite();
        faceindexes.Remove(faceindexes[shuffle]);

        for (int i = 0; i < 17; i++)
        {
            shuffle = random.Next(0, (faceindexes.Count));
            var temp = Instantiate(card, new Vector3(xPosition + 3.5f, yPosition, 0), Quaternion.identity);
            GameObject backCard = temp.transform.GetChild(0).gameObject;
            GameObject backSprite = backCard.transform.GetChild(1).gameObject;
            backSprite.GetComponent<MainCard>().faceIndex = faceindexes[shuffle];
            backSprite.GetComponent<MainCard>().ChangeSprite();
            faceindexes.Remove(faceindexes[shuffle]);
            xPosition = xPosition + 3.5f;
            if (i == 4)
            {
                yPosition = -3.5f;
                xPosition = -18.5f;

            }
            if(i == 10)
            {
                yPosition = -7f;
                xPosition = -18.5f;
            }
        }
    }

    public void AddToUp(GameObject card)
    {
        currentlyUp.Add(card);
    }

    public void RemoveFromUp(GameObject card)
    {
        currentlyUp.Remove(card);
    }

    public void AddToDown(GameObject card)
    {
        currentlyDown.Add(card);
    }

    public void RemoveFromDown(GameObject card)
    {
        currentlyDown.Remove(card);
    }

    private void Awake()
    {
        card = GameObject.Find("Card");  
    }

    void FlipBadPair()
    {
        Debug.Log("GOT INFO!");
        if (currentlyUp.Count == 2 && currentlyDown.Count == 2)
        {
            Debug.Log(currentlyUp);
            Debug.Log(currentlyDown);

            if (greenGirl.gameObject.activeSelf == true)
            {
                greenGirl.GetComponent<Animator>().SetTrigger("Hurt");
            }
            else
            {
                goldGirl.GetComponent<Animator>().SetTrigger("Hurt");
            }

            currentlyUp[0].gameObject.SetActive(false);
            currentlyUp[1].gameObject.SetActive(false);

            currentlyDown[0].gameObject.SetActive(true);
            currentlyDown[1].gameObject.SetActive(true);

            currentlyUp = new List<GameObject>();
            currentlyDown = new List<GameObject>();

        }


    }
    public void CheckPair()
    {
        Debug.Log("CURRENTLY UP, " + currentlyUp.Count);
        if ((currentlyUp.Count == 2 && currentlyDown.Count == 2))
        {
            Debug.Log(currentlyUp);
            Sprite firstSprite = currentlyUp[0].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
            Sprite secondSprite = currentlyUp[1].transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;

            if (firstSprite == secondSprite)
            {
                matches += 1;
                Debug.Log("We got some matchin!");
                if(greenGirl.gameObject.activeSelf == true)
                {
                    greenGirl.GetComponent<Animator>().SetTrigger("Acquire");
                    greenGirl.GetComponent<Animator>().SetTrigger("Acquire");
                    greenGirl.GetComponent<Animator>().SetTrigger("Acquire");
                }
                else
                {
                    goldGirl.GetComponent<Animator>().SetTrigger("Acquire");
                    goldGirl.GetComponent<Animator>().SetTrigger("Acquire");
                    goldGirl.GetComponent<Animator>().SetTrigger("Acquire");
                }

                currentlyUp[0].transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
                currentlyUp[1].transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;

                currentlyUp = new List<GameObject>();
                currentlyDown = new List<GameObject>();

                if(matches == 9)
                {
                    Debug.Log("ALL MATCH");
                    winText.SetActive(true);
                    Invoke("ClearGame", 5f);
                   
                }

            }
            else
            {
                Debug.Log("NO GOOD! CLOSE EM!");
                Debug.Log("Giving them info...");
                Invoke("FlipBadPair", .5f);
            }

        }
    }
    
    public List<GameObject> GetUp()
    {
        return currentlyUp;
    }

    public List<GameObject> GetDown()
    {
        return currentlyDown;
    }

    public void ClearGame()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject go in gos)
        {
            go.transform.GetChild(0).gameObject.SetActive(false);
            go.transform.GetChild(1).gameObject.SetActive(true);

        }

        winText.SetActive(false);
    }
}
