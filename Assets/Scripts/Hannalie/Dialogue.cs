using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor.Timeline.Actions;
#endif



public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
     [SerializeField] public GameObject arrow;
    [SerializeField] public GameObject backgroundImage;
    [SerializeField] public GameObject secondDialogueBox;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        backgroundImage.SetActive(true);
        secondDialogueBox.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

        void StartDialogue()
        {
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }

            else
            {
            gameObject.SetActive(false);
            arrow.SetActive(false);
            backgroundImage.SetActive(false);
            secondDialogueBox.SetActive(true);
            }
        }
    }

