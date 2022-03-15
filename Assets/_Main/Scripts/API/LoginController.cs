using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    [SerializeField]
    private InputField emailField;
    [SerializeField]
    private InputField passwordField;

    
    public void Login(){
        APIController.Instance.PostWithFormData("login");
    }

}
