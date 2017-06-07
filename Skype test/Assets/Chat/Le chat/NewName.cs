using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CustomChatGUI))]
public class NewName : MonoBehaviour
{
    private const string UserNamePlayerPref = "NamePickUserName";

    public CustomChatGUI chatNewComponent;

    public InputField idInput;

    public void Start()
    {
        this.chatNewComponent = FindObjectOfType<CustomChatGUI>();


        string prefsName = PlayerPrefs.GetString(NewName.UserNamePlayerPref);
        if (!string.IsNullOrEmpty(prefsName))
        {
            this.idInput.text = prefsName;
        }
    }


    // new UI will fire "EndEdit" event also when loosing focus. So check "enter" key and only then StartChat.
    public void EndEditOnEnter()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            this.StartChat();
        }
    }

    public void StartChat()
    {
        ChatGui chatNewComponent = FindObjectOfType<ChatGui>();
        chatNewComponent.UserName = this.idInput.text.Trim();
        chatNewComponent.Connect();
        enabled = false;

        PlayerPrefs.SetString(NewName.UserNamePlayerPref, chatNewComponent.UserName);
    }
}