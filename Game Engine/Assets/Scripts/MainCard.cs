using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCard : MonoBehaviour
{
    GameObject gameControl;
    public GameObject front;
    public GameObject back;
    public GameObject backSprite;

    public Sprite[] foodFaces;
    public Sprite[] gemFaces;
    public Sprite[] potionFaces;

    public bool food = true;
    public bool gem = false;
    public bool potion = false;

    public int faceIndex;
    public bool matched = false;

    Vector3 foodScale;
    Vector3 foodPos;

    private void Start()
    {

    }

    public void OnMouseDown()
    {
        if(gameControl.GetComponent<MatchingController>().GetUp().Count < 2)
        {
            Flip();
        }
    }

    public void Flip()
    {
        if (back.activeSelf == true)
        {

                    gameControl.GetComponent<MatchingController>().CheckPair();
                    back.gameObject.SetActive(false);
                    front.gameObject.SetActive(true);
                    gameControl.GetComponent<MatchingController>().RemoveFromUp(back);
                    gameControl.GetComponent<MatchingController>().RemoveFromDown(front);
                    gameControl.GetComponent<MatchingController>().CheckPair();

        }
        else
        {

                    gameControl.GetComponent<MatchingController>().CheckPair();
                    front.gameObject.SetActive(false);
                    back.gameObject.SetActive(true);
                    if(gameControl.GetComponent<MatchingController>().GetUp().Count < 2 
                        && gameControl.GetComponent<MatchingController>().GetDown().Count < 2)
                    {
                        gameControl.GetComponent<MatchingController>().AddToUp(back);
                        gameControl.GetComponent<MatchingController>().AddToDown(front);
                    }
                        
                    gameControl.GetComponent<MatchingController>().CheckPair();



        }

    }

    public void ChangeSprite()
    {
        if (food)
            backSprite.GetComponent<SpriteRenderer>().sprite = foodFaces[faceIndex];
        if (gem)
            backSprite.GetComponent<SpriteRenderer>().sprite = gemFaces[faceIndex];
        if(potion)
            backSprite.GetComponent<SpriteRenderer>().sprite = potionFaces[faceIndex];

    }

    private void Awake()
    {
        gameControl = GameObject.Find("Matching Controller");
    }

}
