using System.Collections;
using System.Collections.Generic;


//se supone que este archivo es el almacenara datos adicionales

[System.Serializable]
public class Parte
    {
        public string idP;
        public string numParte;
        public string color;
        public string imagen;
        public string versionIdV;
    }

[System.Serializable]
public class Emocion
    {
        public string idE;        
        public string numEmocion;
        public string color;
        public string imagen;
        public string versionIdV;
    }
[System.Serializable]
public class Accesorio
    {
        public string idA;
        public string numAccesorio;
        public string color;
        public string imagen;
        public string versionIdV;
    }
[System.Serializable]
public class Version
    {
        public string idV;
        public string personajeId;
        public string numVer;
        public List<Parte> partes;
        public List<Emocion> emocions;
        public List<Accesorio> accesorios;
    }

[System.Serializable]
public class Personaje
    {
        public string id;
        public string nombre;
        public string url_ref;
        public List<Version> versions;
    }

[System.Serializable]
public class Data
    {
        public List<Personaje> personajes;
    }

