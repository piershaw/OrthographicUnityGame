//JsonLoaderScript Class by pier shaw
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

public class JsonLoaderScript : MonoBehaviour {

    private string gameDataFileName = "Resorces/data.json";
    private string jsonfile;
    private float size;
    private int index;
    private JArray jsonArray;
    
    public GameObject dirt;
    public GameObject grass;
    public GameObject stone;
    public GameObject wood;
  
    //Terrain
    [System.Serializable]
    public class Terrain
    {
        public List<string> TerrainGrid { get; set; }
        public int TileType { get; set; }
       
    }

    void Start()
    {
        SpriteRenderer sizeOfSprite = dirt.GetComponent<SpriteRenderer>();
        size = sizeOfSprite.size.x;
        LoadGameData();
    }


    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.dataPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            StreamReader reader = File.OpenText(filePath);
            JObject josonJObject = (JObject)JToken.ReadFrom(new JsonTextReader(reader));

            int rows = 1;
            int cols = 0;

          
            for (int i = 0; i < 16; i++)
            {
                jsonArray = (JArray)josonJObject["TerrainGrid"][i];
                 Debug.Log(jsonArray.Count);

               

                foreach (JToken vaule in jsonArray.Children())
                {
                   
                    string select = (string)vaule.SelectToken("TileType");

                    switch (select)
                    {
                        case "0":
                            Instantiate(dirt, new Vector3(rows * size,0, cols * size), Quaternion.Euler(90, 0, 0));
                            break;
                        case "1":
                            Instantiate(grass, new Vector3(rows * size,0, cols * size), Quaternion.Euler(90, 0, 0));
                            break;
                        case "2":
                            Instantiate(stone, new Vector3(rows * size,0, cols * size), Quaternion.Euler(90, 0, 0));
                            break;
                        case "3":
                   
                            Instantiate(wood, new Vector3(rows * size,0, cols * size), Quaternion.Euler(90, 0, 0));
                            break;

                    }

                    if (rows == 16)
                    {
                        rows = 1;
                        cols += 1;
                        
                    }
                    else
                    {
                        rows++;
                    }
                   
                }

               

            }
        } else {

            Debug.LogError("Cannot load game data!");
        }
        Debug.Log(index);
        
    }

}
