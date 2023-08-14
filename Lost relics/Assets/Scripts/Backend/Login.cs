using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [Header("Input Field")]
    [SerializeField]
    private InputField _usernameInput;
    [SerializeField]
    private InputField _passwordInput;
    [SerializeField]
    private Button _loginButton;

    // Start is called before the first frame update
    void Start()
    {
        _loginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Backend.instance.web.login(_usernameInput.text, _passwordInput.text));
        });

    }


}
