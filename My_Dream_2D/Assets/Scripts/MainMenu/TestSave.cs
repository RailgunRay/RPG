using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TestSave : MonoBehaviour
{
    public GameObject player;
    private PlayerHealthManager PlayerHealth;
    public GameObject Game;
    void Awake()
    {

    }

    void Start()
    {
        PlayerHealth = FindObjectOfType<PlayerHealthManager>();

    }

    public void Save()
    {

        Parametrs parametrs = new Parametrs();
        parametrs.x = player.transform.position.x;
        parametrs.y = player.transform.position.y;
        parametrs.z = player.transform.position.z;
        parametrs.HP = PlayerHealth.playerCurrentHealth;

        if (!Directory.Exists(Application.dataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }
        FileStream fs = new FileStream(Application.dataPath + "/Saves/Save1.sv", FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, parametrs);
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
                Game.SetActive(true);
                Parametrs par = (Parametrs)formatter.Deserialize(fs);
                player.transform.position = new Vector3(par.x, par.y, par.z);
                player.GetComponent<PlayerHealthManager>().playerCurrentHealth = par.HP;
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

    [System.Serializable]
    public class Parametrs
    {
        public int HP;
        public float x;
        public float y;
        public float z;

    }

}

