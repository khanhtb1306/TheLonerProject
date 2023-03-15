using UnityEngine;

public class DontDesroyOnLoad1 : MonoBehaviour
{
    // This is a reference to the instance of the object that should persist across scenes
    private static DontDesroyOnLoad1 instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
