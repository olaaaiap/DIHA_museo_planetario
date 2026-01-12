using UnityEngine;

//Definición de una clase Singleton para aplicar en objetos que no se puedan repetir en la escena: pool manager, game manager etc.
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null )
            {
                _instance = FindFirstObjectByType<T>();
            }
            return _instance;
        }
    }
}
