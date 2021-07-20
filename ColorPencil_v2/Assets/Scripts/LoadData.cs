using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; 
using System.IO;

public class LoadData : MonoBehaviour
{ 	
    private string url= "http://localhost:3000/personaje/";
    private string file= "/datafile.txt";
    void Start()
        {
        PlayerPrefs.SetInt("escenaE",0);
          StartCoroutine(GetData());
        }
    

    IEnumerator GetData()
      {
          using (UnityWebRequest req = UnityWebRequest.Get(url))
          {
              yield return req.SendWebRequest();
              while (!req.isDone)
                  yield return null;
              byte[] result = req.downloadHandler.data;
              string characterJSON = System.Text.Encoding.Default.GetString(result);
              saveData(characterJSON);
              //characterINfo info = JsonUtility.FromJson<characterInfo>(characterJSON);
          }
      }

      public void saveData(string datosjson){
        string path = Application.persistentDataPath + file;
        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(datosjson);
        writer.Close();
        Debug.Log("Se guardo localmente los personaje");
    }

}