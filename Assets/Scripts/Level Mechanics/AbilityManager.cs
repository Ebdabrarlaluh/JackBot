using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject objectWithScripts; // Kontrol edilecek obje
    public MonoBehaviour[] allScripts; // Etkinleştirilecek betikler
    void Start()
    {
        // Öncelikle, tüm betikleri devre dışı bırak
        allScripts = objectWithScripts.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in allScripts)
        {
            script.enabled = false;
        }
    }
    public void EnableScripts(string name)
    {

        if (name == "Grapple")
        objectWithScripts.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            

        // Ardından, sadece belirli betikleri etkinleştir
        foreach (MonoBehaviour script in allScripts)
        {
            if (script.GetType().Name.ToString() == name)
            {
                Debug.LogError("gird");
                script.enabled = true;
            }
        }
    }
}


