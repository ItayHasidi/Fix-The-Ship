using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    public GameObject questionPanel;
    MyScript testScript;
    public TMP_InputField tmpInput;
    public Button but;


    //public Toggle togInput1;
    //public Toggle togInput2;
    //public Toggle togInput3;
    //public Toggle togInput4;
    //public Toggle togInput5;

    public Toggle togExitDoor;
    public Toggle togBakaraDoor;
    public Toggle togEngineDoor;
    public Toggle togSleepingDoor;
    public Toggle togCafiteriaDoor;

    public GameObject closedDoor;


    void Start()
    {
        /*
        string tmpString = @"
        function OpenDoor() 
            if Input1 then
                Output1 = true
            else
                Output1 = false
            end
        end
        ";
        */

        /*
        string tmpString = @"
            function OpenDoor()
            // Doors = [""ExitDoor"", ""BakaraDoor"", ""EngineDoor"", ""SleepingDoor"", ""CafitiriaDoor""]
             Doors = getDoors() 
             for i in ipairs(Doors) do
                if Doors[i] == ""EngineDoor"" then
                    Output1 = true;
                end
             end
        end
        ";
        */

        string tmpString = @"
    function OpenDoor()
    --//Doors = [""ExitDoor"", ""BakaraDoor"", ""EngineDoor"", ""SleepingDoor"", ""CafitiriaDoor""]
    --//This Was The Original Array, But The Order Has Been Changed.
    --//You Must Iterate Over The Array, And Open The Engine Room.
        Doors = getDoors() 
    --//Your Code Here...

    end
    ";

        /*
        function openDoor()
            Doors = [ExitDoor, BakaraDoor, EngineDoor, SleepingDoor, CafiteriaDoor] // All locks doors.
            // You need to iterate over all the doors using the function "GetDoors" and unlock the EngineDoor.
            // using d1 = true -> open the door.
            for door in Doors
                door = true       
        ";
        */
        but.onClick.AddListener(TaskOnClick);
        testScript = tmpInput.GetComponentInChildren<MyScript>();
        testScript.initScript(tmpString);
        tmpInput.text = testScript.myScript;
    }

    // Update is called once per frame
    void Update()
    {
        testScript.runScript();
    }

    public void updateScript()
    {
        string tmpString = tmpInput.text;
        testScript.initScript(tmpString);

        testScript.ExitDoor = togExitDoor.isOn;
        testScript.BakaraDoor = togBakaraDoor.isOn;
        testScript.EngineDoor = togEngineDoor.isOn;
        testScript.SleepingDoor = togSleepingDoor.isOn;
        testScript.CafiteriaDoor = togCafiteriaDoor.isOn;


        testScript.runScript();

        togExitDoor.isOn = testScript.ExitDoor;
        togBakaraDoor.isOn = testScript.BakaraDoor;
        togEngineDoor.isOn = testScript.EngineDoor;
        togSleepingDoor.isOn = testScript.SleepingDoor;
        togCafiteriaDoor.isOn = testScript.CafiteriaDoor;

        Debug.Log("Hello" + tmpString);
    }

    void TaskOnClick()
    {
        Debug.Log("Clicked");
        updateScript();
        if(togEngineDoor.isOn)
        {
            closedDoor.GetComponent<BoxCollider>().enabled = true;
            //questionPanel.SetActive(false);
            Debug.Log("asdfasdfasdf");
        }
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
    }

}
