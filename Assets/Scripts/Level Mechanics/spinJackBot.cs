using System.Collections;
using UnityEngine;

public class spinJackBot : MonoBehaviour
{
    public GameObject[] slotObjects;
    public GameObject[] secondSlotObjects;
    public GameObject[] activeObjects;
    private bool onceSpin;

    public AbilityManager jackpot;
    void Start()
    {
        onceSpin = true;
        foreach (GameObject obj in slotObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in secondSlotObjects)
        {
            obj.SetActive(false);
        }

        StartCoroutine(ShowSlotObjectsSequentially());
    }

    IEnumerator ShowSlotObjectsSequentially()
    {
        while (onceSpin)
        {
            // Slot objelerini teker teker gösterme
            foreach (GameObject obj in slotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(1f); obj.SetActive(false);
            }

            foreach (GameObject obj in slotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                obj.SetActive(false);
            }
            foreach (GameObject obj in slotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                obj.SetActive(false);
            }
            foreach (GameObject obj in slotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.1f);
                obj.SetActive(false);
            }
            foreach (GameObject obj in slotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.05f); obj.SetActive(false);
            }

            int randomIndex = Random.Range(0, slotObjects.Length);
            activateScripts(slotObjects[randomIndex]);
            slotObjects[randomIndex].SetActive(true);
            yield return new WaitForSeconds(1f);

            

            /////////////////////////////////////////////////////////////

            foreach (GameObject obj in secondSlotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(1f);
                obj.SetActive(false);
            }

            foreach (GameObject obj in secondSlotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                obj.SetActive(false);
            }
            foreach (GameObject obj in secondSlotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.25f); obj.SetActive(false);
            }
            foreach (GameObject obj in secondSlotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.1f); obj.SetActive(false);
            }
            foreach (GameObject obj in secondSlotObjects)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                obj.SetActive(false);
            }

            int secondRandomIndex = Random.Range(0, secondSlotObjects.Length);
            activateScripts(secondSlotObjects[secondRandomIndex]);
            secondSlotObjects[secondRandomIndex].SetActive(true);
            yield return new WaitForSeconds(3f);
            onceSpin = false;
        }
    }

    void activateScripts(GameObject activeObject)
    {
        string x = activeObject.name;

        if (x == "Move")
        {
            jackpot.EnableScripts("Jump");
        }
        if (x == "Dash")
        {
            jackpot.EnableScripts("Ghost Effect");
        }

        jackpot.EnableScripts(x);
    }
}
