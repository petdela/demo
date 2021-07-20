using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ObjectSelector : MonoBehaviour
{
    private int escena = 0;  //0 indica escena de personajes y 1 la de versiones, 3 indica lienzo
    private string file= "/datafile.txt";
    public List<GameObject> personaje;
    

    private void Start()
    {
        escena = PlayerPrefs.GetInt("escenaE");
        personaje.Add(GameObject.Find("1"));
        personaje.Add(GameObject.Find("2"));
        personaje.Add(GameObject.Find("3"));
        personaje.Add(GameObject.Find("4"));
        personaje.Add(GameObject.Find("5"));
        personaje.Add(GameObject.Find("6"));
        personaje.Add(GameObject.Find("7"));
        personaje.Add(GameObject.Find("8"));
        personaje.Add(GameObject.Find("9"));

        foreach(GameObject lienzo in personaje) 
        {
            lienzo.SetActive(false);
        }


        //aqui se supone que se debe de cargar los elementos a la base local 
        string personajeData = leerDatos().ToString();
        Debug.Log(personajeData);
        string nuevojson = "{\"personajes\":" + personajeData + "}";
        Data personajesD = JsonUtility.FromJson<Data>(nuevojson);
        int totalPersonaje = 0;
        foreach(Personaje person in personajesD.personajes){
            totalPersonaje++;
        }

        if(escena!=3){
                    //con la cantidad de personajes se activa la opcion de personajes
        cargarlienzos(totalPersonaje, personajesD, escena);
            //luego de que se carga los lienzos con las imagenes de referencia
            //borrar_lienzos();
            //cargarlienzos(4);

        }
         //else{
             // Aqui yo pondria el llamado de dibujar las partes en el lienzo
         //}
    
    }
    
    public string leerDatos(){
        string path = Application.persistentDataPath + file;
        StreamReader reader = new StreamReader(path);
        string datajson= reader.ReadToEnd();
        Debug.Log(datajson);
        reader.Close();
        return datajson;
    }

    private void cargarlienzos(int cant, Data datos, int numescena)
    {
        if(numescena == 0){
            Debug.Log("Numero de personajess");
            Debug.Log(cant);
            personaje[cant-1].SetActive(true);
             int numeroLienzo = 1;
            foreach(Personaje persona in datos.personajes){
                GameObject botonLienzo = GameObject.Find(cant+"/Canvas/"+"btnL"+numeroLienzo);
                StartCoroutine(cargarImagen(persona.url_ref,botonLienzo));
                numeroLienzo++;
            }
            escena++;

        }
        else{
            int version = PlayerPrefs.GetInt("personaje");
            int cantV = datos.personajes[version-1].versions.Count;
            Debug.Log("Numero de versiones");
            Debug.Log(cantV);
            int cantP = datos.personajes.Count;
            personaje[cantV-1].SetActive(true);
            int numeroLienzo = 1;
            foreach(Version persona in datos.personajes[version-1].versions){
                GameObject botonLienzo = GameObject.Find(cantV+"/Canvas/"+"btnL"+numeroLienzo);
                StartCoroutine(cargarImagen(datos.personajes[numeroLienzo-1].url_ref,botonLienzo));
            numeroLienzo++;
            }
        }
        


    }


    //este codigo se podria copiar para colocar las imagenes a los gameobject que representaran las partes
    //solo seria de modificarlo
    private IEnumerator cargarImagen(string url, GameObject lienzo){
        //lienzo.GetComponent<Image>().sprite = nuevo sprite;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if(request.isNetworkError || request.isHttpError) 
            Debug.Log(request.error);
        else{
            Texture2D tex = ((DownloadHandlerTexture) request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            lienzo.GetComponent<Image>().sprite = sprite;
            Debug.Log("pues si nada");
        }
    }

    

    private void borrar_lienzos() {
        foreach (GameObject lienzo in personaje)
        {
            lienzo.SetActive(false);
        }
    }

    }
