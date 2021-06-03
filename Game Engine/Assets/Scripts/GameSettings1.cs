using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings1 : MonoBehaviour
{
    public GameObject settings;

    public GameObject goldGirl;
    public GameObject greenGirl;
    public GameObject greenSelect;
    public GameObject goldSelect;

    public GameObject panel;

    public Sprite mountain;
    public Sprite space;
    public Sprite periwinkle;
    public Sprite purple;

    public GameObject foodSelect;
    public GameObject gemSelect;
    public GameObject potionSelect;

    public GameObject mountainSelect;
    public GameObject spaceSelect;
    public GameObject periSelect;
    public GameObject purpleSelect;

    public AudioSource music;
    public GameObject on;
    public GameObject off;
    public GameObject music1select;
    public GameObject music2select;
    public GameObject music3select;
    public GameObject music4select;

    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;

    public GameObject fightSelect;
    public GameObject memorySelect;

    public static System.Random random = new System.Random();
    public int shuffle = 0;
    List<int> faceindexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8 };


    private void Start()
    {
        fightSelect.SetActive(false);
        memorySelect.SetActive(true);
        //keep settings open when you get to this scene
        goldSelect.SetActive(false);
        goldGirl.SetActive(false);
        ChangeToMountain();
        ChangeToFood();
        ChangeToMusic1();
    }


    public void OpenSettings()
    {
        Debug.Log("WE FELT THAT");
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject go in gos)
        {
            go.transform.GetChild(0).transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
            go.transform.GetChild(1).transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;

        }
        settings.SetActive(true);
    }

    public void Refresh()
    {
        FlipOver();

        if (foodSelect.activeSelf)
            ChangeToFood();
        if (gemSelect.activeSelf)
            ChangeToGem();
        if (potionSelect.activeSelf)
            ChangeToPotion();

    }

    void FlipOver()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject go in gos)
        {
            go.transform.GetChild(0).gameObject.SetActive(false);
            go.transform.GetChild(1).gameObject.SetActive(true);

        }
    }

    public void ChangeToFood()
    {
        gemSelect.SetActive(false);
        foodSelect.SetActive(true);
        potionSelect.SetActive(false);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");
        shuffle = 0;

        foreach (GameObject go in gos)
        {
            shuffle = random.Next(0, (faceindexes.Count));

            var temp = go.transform.GetChild(1).transform.GetChild(1).GetComponent<MainCard>();
            temp.food = true;
            temp.gem = false;
            temp.potion = false;
            
            temp.faceIndex = faceindexes[shuffle];
            temp.ChangeSprite();
            if(temp.back.activeSelf)
                temp.Flip();
            faceindexes.Remove(faceindexes[shuffle]); 

        }

        faceindexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        FlipOver();

    }

    public void ChangeToGem()
    {
        gemSelect.SetActive(true);
        foodSelect.SetActive(false);
        potionSelect.SetActive(false);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");
        shuffle = 0;


        foreach (GameObject go in gos)
        {
            shuffle = random.Next(0, (faceindexes.Count));

            var temp = go.transform.GetChild(1).transform.GetChild(1).GetComponent<MainCard>();
            temp.food = false;
            temp.gem = true;
            temp.potion = false;

            temp.faceIndex = faceindexes[shuffle];
            temp.ChangeSprite();
            if (temp.back.activeSelf)
                temp.Flip();
            faceindexes.Remove(faceindexes[shuffle]);

        }

        faceindexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    }

    public void ChangeToPotion()
    {
        gemSelect.SetActive(false);
        foodSelect.SetActive(false);
        potionSelect.SetActive(true);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");
        shuffle = 0;


        foreach (GameObject go in gos)
        {
            shuffle = random.Next(0, (faceindexes.Count));

            var temp = go.transform.GetChild(1).transform.GetChild(1).GetComponent<MainCard>();
            temp.food = false;
            temp.gem = false;
            temp.potion = true;

            temp.faceIndex = faceindexes[shuffle];
            temp.ChangeSprite();
            if (temp.back.activeSelf)
                temp.Flip();
            faceindexes.Remove(faceindexes[shuffle]);

        }

        faceindexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        FlipOver();

    }


    public void Mute()
    {
        music.mute = true;
        on.SetActive(false);
        off.SetActive(true);
    }

    public void UnMute()
    {
        music.mute = false;
        on.SetActive(true);
        off.SetActive(false);
    }


    public void ChangeToPurple()
    {
        panel.GetComponent<Image>().sprite = purple;
        purpleSelect.SetActive(true);
        spaceSelect.SetActive(false);
        periSelect.SetActive(false);
        mountainSelect.SetActive(false);
    }

    public void ChangeToMountain()
    {
        panel.GetComponent<Image>().sprite = mountain;
        purpleSelect.SetActive(false);
        spaceSelect.SetActive(false);
        periSelect.SetActive(false);
        mountainSelect.SetActive(true);
    }

    public void ChangeToSpace()
    {
        panel.GetComponent<Image>().sprite = space;
        purpleSelect.SetActive(false);
        spaceSelect.SetActive(true);
        periSelect.SetActive(false);
        mountainSelect.SetActive(false);
    }

    public void ChangeToPeriwinkle()
    {
        panel.GetComponent<Image>().sprite = periwinkle;
        purpleSelect.SetActive(false);
        spaceSelect.SetActive(false);
        periSelect.SetActive(true);
        mountainSelect.SetActive(false);
    }

    public void ChangeToMusic1()
    {
        UnMute();
        music.clip = music1;
        music.Play();
        music1select.SetActive(true);
        music2select.SetActive(false);
        music3select.SetActive(false);
        music4select.SetActive(false);
    }

    public void ChangeToMusic2()
    {
        UnMute();
        music.clip = music2;
        music.Play();
        music1select.SetActive(false);
        music2select.SetActive(true);
        music3select.SetActive(false);
        music4select.SetActive(false);
    }

    public void ChangeToMusic3()
    {
        UnMute();
        music.clip = music3;
        music.Play();
        music1select.SetActive(false);
        music2select.SetActive(false);
        music3select.SetActive(true);
        music4select.SetActive(false);
    }

    public void ChangeToMusic4()
    {
        UnMute();
        music.clip = music4;
        music.Play();
        music1select.SetActive(false);
        music2select.SetActive(false);
        music3select.SetActive(false);
        music4select.SetActive(true);
    }



    public void ReturnToHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void GoToEnemy()
    {
        memorySelect.SetActive(false);
        fightSelect.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void CloseSettings()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Card");

        foreach (GameObject go in gos)
        {
            go.transform.GetChild(0).transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
            go.transform.GetChild(1).transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;

        }
        settings.SetActive(false);
    }
    public void ChangeGreen()
    {
        greenGirl.SetActive(true);
        greenSelect.SetActive(true);

        goldGirl.SetActive(false);
        goldSelect.SetActive(false);

    }

    public void ChangeGold()
    {
        Debug.Log("BUTTON PRESSED! CHANGE TO GOLD GIRL!");

        goldGirl.SetActive(true);
        goldSelect.SetActive(true);


        greenGirl.SetActive(false);
        greenSelect.SetActive(false);
    }
}
