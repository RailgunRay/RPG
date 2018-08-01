using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Saver : MonoBehaviour {

    public GameObject player;

    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }

	public void Save()
    {

        Position position = new Position();
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        position.z = player.transform.position.z;

        if(!Directory.Exists(Application.dataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }
        FileStream fs = new FileStream(Application.dataPath + "/Saves/Save1.sv", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, position);
        fs.Close();
        
    }

    public void Load()
    {
        if (File.Exists(Application.dataPath + "/Saves/Save1.sv"))
        {
            FileStream fs = new FileStream(Application.dataPath + "/Saves/Save1.sv", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                Position pos = (Position)formatter.Deserialize(fs);
                player.transform.position = new Vector3(pos.x, pos.y, pos.z);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        else
        {
            Application.Quit();
        }
    }
         
    }

