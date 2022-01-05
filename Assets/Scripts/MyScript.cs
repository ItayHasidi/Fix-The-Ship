using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;
using System.IO;
using UnityEngine.UI;
using System;

public class MyScript : MonoBehaviour
{

    public bool Input1 = false;
    public bool Input2 = false;
    public bool Input3 = false;
    public bool Input4 = false;
    public bool Input5 = false;

    public bool ExitDoor = false;
    public bool BakaraDoor = false;
    public bool EngineDoor = false;
    public bool SleepingDoor = false;
    public bool CafiteriaDoor = false;
    public string myScript;
    Script script;

    private static IEnumerable<int> GetNumOfDoors()
    {
       
            yield return 5;
    }

    /*
    private static string[] GetDoorsList()
    {
        string[] doors = 
        {
            "ExitDoor",
            "BakaraDoor",
            "EngineDoor",
            "SleepingDoor",
            "CafiteriaDoor"
        };

        return doors;
    }

    private static Table GetNumberTable(Script script)
    {
        Table tbl = new Table(script);
        tbl[0] = "Bakara";
        tbl[1] = "BBakara";
        tbl[2] = "Basdakara";
        tbl[3] = "Basdfkara";
        tbl[4] = "Baasdfasfkara";

        return tbl;
    }

    private static List<string> GetNumberList()
    {
        List<string> lst = new List<string>();

        lst.Add("FDVASFDVakara");
        lst.Add("SDFACakara");
        lst.Add("Bakara");
        lst.Add("HSGBakara");
        lst.Add("AVADFVakara");


        return lst;
    }
    */
    private static List<string> GetDoors()
    {
        string[] doors =
{
            "ExitDoor",
            "BakaraDoor",
            "EngineDoor",
            "SleepingDoor",
            "CafiteriaDoor"
        };

        List<string> lst = new List<string>();

        for (int i = 0; i <= 4; i++)
            lst.Add(doors[i]);

        return lst;
    }

    public void initScript (string scriptText) 
    {
        script = new Script();
        myScript = scriptText;
        script.DoString(myScript);
    }

    public void runScript ()
    {
        script.Globals["Input1"] = Input1;
        script.Globals["Input2"] = Input2;
        script.Globals["Input3"] = Input3;
        script.Globals["Input4"] = Input4;
        script.Globals["Input5"] = Input5;

        script.Globals["ExitDoor"] = ExitDoor;
        script.Globals["BakaraDoor"] = BakaraDoor;
        script.Globals["EngineDoor"] = EngineDoor;
        script.Globals["SleepingDoor"] = SleepingDoor;
        script.Globals["CafiteriaDoor"] = CafiteriaDoor;

        //script.Globals["getNumOfDoors"] = (Func<IEnumerable<int>>)GetNumOfDoors;
        //script.Globals["getDoors"] = (Func<string[]>)GetDoorsList;
        //script.Globals["getDoors2"] = (Func<Script, Table>)(GetNumberTable);
        script.Globals["getDoors"] = (Func<List<string>>)GetDoors;

        DynValue val = script.Call(script.Globals["OpenDoor"]);

        ExitDoor = script.Globals.Get("ExitDoor").CastToBool();
        BakaraDoor = script.Globals.Get("BakaraDoor").CastToBool();
        EngineDoor = script.Globals.Get("EngineDoor").CastToBool();
        SleepingDoor = script.Globals.Get("SleepingDoor").CastToBool();
        CafiteriaDoor = script.Globals.Get("CafiteriaDoor").CastToBool();
    }

    public void initScriptFromFile (string fileName)
    {
        script = new Script();
        StreamReader sr = new StreamReader(fileName);
        string tmpString = sr.ReadToEnd();
        sr.Close();
        script.DoString(tmpString);
    }
}
