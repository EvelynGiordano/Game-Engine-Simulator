using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public GameObject goldGirl;
    public GameObject greenGirl;
    public GameObject greenSelect;
    public GameObject goldSelect;

    public GameObject settings;

    public GameObject mountain;
    public GameObject mountainSelect;
    public GameObject space;
    public GameObject spaceSelect;
    public GameObject periwinkle;
    public GameObject periSelect;
    public GameObject purple;
    public GameObject purpleSelect;

    public GameObject slime1;
    public GameObject slime2;
    public GameObject slime3;
    public GameObject slimeSelect;

    public GameObject hand1;
    public GameObject hand2;
    public GameObject hand3;
    public GameObject handSelect;

    public GameObject dragon1;
    public GameObject dragon2;
    public GameObject dragon3;
    public GameObject dragonSelect;

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

    public GameObject winText;

    private Vector3 goldGirlPos;
    private Vector3 greenGirlPos;
    private bool isSlime = true;
    private bool isHand = false;
    private bool isDragon = false;

    public int slime = 0;


    public Cinemachine.CinemachineVirtualCamera cam;

    private void Start()
    {
        winText.SetActive(false);
        fightSelect.SetActive(true);
        memorySelect.SetActive(false);
        greenGirl.transform.position = goldGirl.transform.position;
        goldSelect.SetActive(false);
        goldGirl.SetActive(false);
        slimeSelect.SetActive(true);
        handSelect.SetActive(false);
        dragonSelect.SetActive(false);
        ChangeToMountain();
        ChooseSlime();
        ChangeToMusic1();
    }

    private void FixedUpdate()
    {
        goldGirlPos = goldGirl.transform.position;
        greenGirlPos = greenGirl.transform.position;

        if(slime == 3)
        {
            Debug.Log("All Dead");
            slime = 0;
            winText.SetActive(true);
            Invoke("Refresh", 5);
        }
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void Refresh()
    {

        if (isSlime)
        {
            slime1.SetActive(true);
            slime1.transform.GetChild(0).gameObject.SetActive(true);
            slime1.transform.GetChild(1).gameObject.SetActive(true);
            slime1.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            slime1.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;

            slime2.SetActive(true);
            slime2.transform.GetChild(0).gameObject.SetActive(true);
            slime2.transform.GetChild(1).gameObject.SetActive(true);
            slime2.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            slime2.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;

            slime3.SetActive(true);
            slime3.transform.GetChild(0).gameObject.SetActive(true);
            slime3.transform.GetChild(1).gameObject.SetActive(true);
            slime3.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            slime3.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;
        }
        else if (isHand)
        {
            hand1.SetActive(true);
            hand1.transform.GetChild(0).gameObject.SetActive(true);
            hand1.transform.GetChild(1).gameObject.SetActive(true);
            hand1.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            hand1.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;

            hand2.SetActive(true);
            hand2.transform.GetChild(0).gameObject.SetActive(true);
            hand2.transform.GetChild(1).gameObject.SetActive(true);
            hand2.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            hand2.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;

            hand3.SetActive(true);
            hand3.transform.GetChild(0).gameObject.SetActive(true);
            hand3.transform.GetChild(1).gameObject.SetActive(true);
            hand3.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            hand3.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;
        }
        else if (isDragon)
        {
            dragon1.SetActive(true);
            dragon1.transform.GetChild(0).gameObject.SetActive(true);
            dragon1.transform.GetChild(1).gameObject.SetActive(true);
            dragon1.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            dragon1.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;

            dragon2.SetActive(true);
            dragon2.transform.GetChild(0).gameObject.SetActive(true);
            dragon2.transform.GetChild(1).gameObject.SetActive(true);
            dragon2.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            dragon2.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;

            dragon3.SetActive(true);
            dragon3.transform.GetChild(0).gameObject.SetActive(true);
            dragon3.transform.GetChild(1).gameObject.SetActive(true);
            dragon3.transform.GetChild(0).gameObject.GetComponent<HealthBar>().SetHealth(100);
            dragon3.transform.GetChild(0).gameObject.GetComponent<Enemy>().currentHealth = 100;
        }

        winText.SetActive(false);
        slime = 0;

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
        purple.SetActive(true);
        purpleSelect.SetActive(true);
        periwinkle.SetActive(false);
        periSelect.SetActive(false);
        space.SetActive(false);
        spaceSelect.SetActive(false);
        mountain.SetActive(false);
        mountainSelect.SetActive(false);
    }

    public void ChangeToMountain()
    {
        purple.SetActive(false);
        purpleSelect.SetActive(false);
        periwinkle.SetActive(false);
        periSelect.SetActive(false);
        space.SetActive(false);
        spaceSelect.SetActive(false);
        mountain.SetActive(true);
        mountainSelect.SetActive(true);
    }

    public void ChangeToSpace()
    {
        purple.SetActive(false);
        purpleSelect.SetActive(false);
        periwinkle.SetActive(false);
        periSelect.SetActive(false);
        space.SetActive(true);
        spaceSelect.SetActive(true);
        mountain.SetActive(false);
        mountainSelect.SetActive(false);
    }

    public void ChangeToPeriwinkle()
    {
        purple.SetActive(false);
        purpleSelect.SetActive(false);
        periwinkle.SetActive(true);
        periSelect.SetActive(true);
        space.SetActive(false);
        spaceSelect.SetActive(false);
        mountain.SetActive(false);
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


    public void ChooseSlime()
    {
        Refresh();
        slimeSelect.SetActive(true);
        slime1.SetActive(true);
        slime2.SetActive(true);
        slime3.SetActive(true);

        handSelect.SetActive(false);
        hand1.SetActive(false);
        hand2.SetActive(false);
        hand3.SetActive(false);

        dragonSelect.SetActive(false);
        dragon1.SetActive(false);
        dragon2.SetActive(false);
        dragon3.SetActive(false);

        isSlime = true;
        isHand = false;
        isDragon = false;
    }

    public void ChooseHand()
    {
        Refresh();
        slimeSelect.SetActive(false);
        slime1.SetActive(false);
        slime2.SetActive(false);
        slime3.SetActive(false);

        handSelect.SetActive(true);
        hand1.SetActive(true);
        hand2.SetActive(true);
        hand3.SetActive(true);

        dragonSelect.SetActive(false);
        dragon1.SetActive(false);
        dragon2.SetActive(false);
        dragon3.SetActive(false);

        isSlime = false;
        isHand = true;
        isDragon = false;
    }

    public void ChooseDragon()
    {
        Refresh();
        slimeSelect.SetActive(false);
        slime1.SetActive(false);
        slime2.SetActive(false);
        slime3.SetActive(false);

        handSelect.SetActive(false);
        hand1.SetActive(false);
        hand2.SetActive(false);
        hand3.SetActive(false);

        dragonSelect.SetActive(true);
        dragon1.SetActive(true);
        dragon2.SetActive(true);
        dragon3.SetActive(true);

        isSlime = false;
        isHand = false;
        isDragon = true;

    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
    }
    public void ChangeGreen()
    {
        greenGirl.SetActive(true);
        greenSelect.SetActive(true);

        greenGirl.transform.position = goldGirlPos;

        Debug.Log("BUTTON PRESSED! CHANGE TO GREEN GIRL!");
        goldGirl.SetActive(false);
        goldSelect.SetActive(false);

        cam.m_LookAt = greenGirl.transform;
        cam.m_Follow = greenGirl.transform;

    }

    public void ChangeGold()
    {
        Debug.Log("BUTTON PRESSED! CHANGE TO GOLD GIRL!");

        goldGirl.SetActive(true);
        goldSelect.SetActive(true);

        goldGirl.transform.position = greenGirlPos;

        greenGirl.SetActive(false);
        greenSelect.SetActive(false);

        cam.m_LookAt = goldGirl.transform;
        cam.m_Follow = goldGirl.transform;

    }

    public void GoToMemory()
    {
        memorySelect.SetActive(true);
        fightSelect.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
