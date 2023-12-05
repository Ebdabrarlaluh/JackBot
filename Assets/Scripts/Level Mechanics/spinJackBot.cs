using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class spinJackBot : MonoBehaviour
{
    public GameObject[] slotObjects;
    public GameObject[] secondSlotObjects;
    public GameObject[] activeObjects;
    private bool onceSpin;

    //public AbilityText abilities;

    //public Image firstImage;
    //public Image secondImage;

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

            //abilities.AbilityDialogue(slotObjects[randomIndex].name, 0);


            slotObjects[randomIndex].SetActive(true);

            //SpriteRenderer spriteRenderer = slotObjects[randomIndex].GetComponent<SpriteRenderer>();
            //Sprite sprite = spriteRenderer.sprite;

            //firstImage.sprite = sprite;
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

            //abilities.AbilityDialogue(secondSlotObjects[secondRandomIndex].name, 1);

            secondSlotObjects[secondRandomIndex].SetActive(true);

            //SpriteRenderer spriteRenderer2 = secondSlotObjects[secondRandomIndex].GetComponent<SpriteRenderer>();
            //Sprite sprite2 = spriteRenderer2.sprite;

            //secondImage.sprite = sprite2;

            yield return new WaitForSeconds(3f);
            onceSpin = false;
        }
    }

    void activateScripts(GameObject activeObject)
    {
        string x = activeObject.name;

        if (x == "Dash")
        {
            jackpot.EnableScripts("GhostEffect");
        }
        if (x == "Freeze")
        {
            jackpot.EnableScripts("FreezeGun");//?????????????
        }

        jackpot.EnableScripts(x);
    }
}
