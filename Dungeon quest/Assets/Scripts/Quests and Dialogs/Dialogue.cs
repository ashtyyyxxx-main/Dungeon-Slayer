using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isQuestGiver;
    public string[] lines;
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private Button nextDialogButton;
    [SerializeField] private Button byeDialogButton;
    [SerializeField] private float speedText;
    [SerializeField] AudioSource startDialogSound;

    private int index;

    private CharacterMovement characterMovement;
    private QuestGiver questGiver;

    private void Start()
    {
        characterMovement = FindAnyObjectByType<CharacterMovement>();

        DialogText.text = string.Empty;

        if (isQuestGiver)
            questGiver = GetComponent<QuestGiver>();
    }

    public void StartDialog()
    {
        index = 0;
        DialogText.text = string.Empty;
        UIPanel.SetActive(true);
        StartCoroutine(TypeLine());

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        characterMovement.canMove = false;

        nextDialogButton.onClick.RemoveAllListeners();
        byeDialogButton.onClick.RemoveAllListeners();

        nextDialogButton.onClick.AddListener(skipText);
        byeDialogButton.onClick.AddListener(EndDialog);

        if (isQuestGiver)
            nextDialogButton.onClick.AddListener(questGiver.AcceptQuest);
    }

    public void EndDialog()
    {
        if (isQuestGiver)
            questGiver.DeclineQuest();

        UIPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterMovement.canMove = true;

        StopAllCoroutines();
    }

    public void Interact()
    {
        StartDialog();
        startDialogSound.Play();
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            DialogText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void skipText()
    {
        if (DialogText.text == lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            DialogText.text = lines[index];
        }
    }

    private void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            DialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            UIPanel.SetActive(false);

            characterMovement.canMove = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
