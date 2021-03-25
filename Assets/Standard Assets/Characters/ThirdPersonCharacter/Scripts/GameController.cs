using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private ThirdPersonUserControl character;
    private RoverControl rover;
    public Camera playerCam;
    public Camera roverCam;
    public TextMeshProUGUI roverPopup;
    public TextMeshProUGUI playerPopup;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rover = GameObject.Find("rover").GetComponent<RoverControl>();
        character = GameObject.Find("player").GetComponent<ThirdPersonUserControl>();
        switchPlayer(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchPlayer(bool leaveRover = true)
    {
        playerCam.enabled = true;
        roverCam.enabled = false;
        roverPopup.enabled = false;
        player.SetActive(true);
        rover.stopAnimation();
        rover.enabled = false;
        character.reset();
        if (leaveRover)
        {
            player.transform.position = rover.getPosition();
        }
    }

    public void switchRover()
    {
        playerCam.enabled = false;
        roverCam.enabled = true;
        roverPopup.enabled = true;
        playerPopup.enabled = false;
        player.SetActive(false);
        rover.enabled = true;
        rover.reset();
    }
}
