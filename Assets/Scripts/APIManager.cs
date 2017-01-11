using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSparks.Core;
using Facebook.Unity;
using System.Collections.Generic;

public class APIManager : MonoBehaviour
{

    Text userNameField, connectionInfoField;
    InputField userNameInput, passwordInput;

    void Wait()
    {

        FacebookConnect_bttn();
    }
    // Use this for initialization
    void Start()
    {
        GS.GameSparksAvailable += OnGameSparksConnected;
       // Invoke("Wait",3f);
       // FacebookConnect_bttn();
    }

    private void OnGameSparksConnected(bool _isConnected)
    {
        if (_isConnected)
        {
            //connectionInfoField.text = "GameSparks Connected...";
            Debug.Log("GameSparks Connected...");
        }
        else
        {
            //connectionInfoField.text = "GameSparks Not Connected...";
            Debug.Log("GameSparks Not Connected...");
        }
    }

    public void UserAuthentication_Bttn()
    {
        Debug.Log("Attempting User Login...");
        // print out the username and password here just to check they are correct //
        Debug.Log("User Name:" + userNameInput.text);
        Debug.Log("Password:" + passwordInput.text);
        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(userNameInput.text) // set the username for login
            .SetPassword(passwordInput.text) // set the password for login
            .Send((auth_response) => { // send the authentication request
                if (!auth_response.HasErrors)
                { // for the next part, check to see if we have any errors i.e. authentication failed
                    connectionInfoField.text = "GameSparks Authenticated...";
                    userNameField.text = auth_response.DisplayName;
                }
                else
                {
                    Debug.LogWarning(auth_response.Errors.JSON); // if we have errors, print them out
                    if (auth_response.Errors.GetString("DETAILS") == "UNRECOGNISED")
                    { // if we get this error it means we are not registered, so lets register the user instead
                        Debug.Log("User Doesnt Exists, Registering User...");
                        new GameSparks.Api.Requests.RegistrationRequest()
                            .SetDisplayName(userNameInput.text)
                            .SetUserName(userNameInput.text)
                            .SetPassword(passwordInput.text)
                            .Send((reg_response) => {
                                if (!reg_response.HasErrors)
                                {
                                    connectionInfoField.text = "GameSparks Authenticated...";
                                    //userNameField.text = reg_response.DisplayName;
                                }
                                else
                                {
                                    Debug.LogWarning(auth_response.Errors.JSON); // if we have errors, print them out
                                }
                            });
                    }
                }
            });
    }

    public void DeviceAuthentication_bttn()
    {
        Debug.Log("Attempting Device Authentication...");
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
            .SetDisplayName("Player 2")
            .Send((auth_response) => {
                if (!auth_response.HasErrors)
                { // for the next part, check to see if we have any errors i.e. authentication failed
                    connectionInfoField.text = "GameSparks Authenticated...";
                    //userNameField.text = auth_response.DisplayName;
                }
                else
                {
                    Debug.LogWarning(auth_response.Errors.JSON); // if we have errors, print them out
                }
            });
    }

    public void FacebookConnect_bttn()
    {
        Debug.Log("Connecting Facebook With GameSparks...");
        // first check if FB is ready, and then login //
        // if its not ready we just init FB and use the login method as the callback for the init method //
        if (!FB.IsInitialized)
        {
            //Debug.Log("Initilizing Facebook...");
            FB.Init(ConnectGameSparksToGameSparks, null);
        }
        else
        {
            FB.ActivateApp();
            ConnectGameSparksToGameSparks();
        }
    }

    /// <summary>
    /// This method is used as the delegate for FB initilization. It logs in FB
    /// </summary>
    private void ConnectGameSparksToGameSparks()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            Debug.Log("Logging Into Facebook...");
            var perms = new List<string>() { "public_profile", "email", "user_friends" };
            FB.LogInWithReadPermissions(perms, (result) => {
                if (FB.IsLoggedIn)
                {
                    Debug.Log("Logged In, Connecting GS via FB..");
                    new GameSparks.Api.Requests.FacebookConnectRequest()
                        .SetAccessToken(AccessToken.CurrentAccessToken.TokenString)
                        .SetDoNotLinkToCurrentPlayer(false) // we dont want to create a new account so link to the player that is currently logged in
                        .SetSwitchIfPossible(true) //  this will switch to the player with this FB account id they already have an account from a seperate login
                        .Send((fbauth_response) => {
                            if (!fbauth_response.HasErrors)
                            {
                                //connectionInfoField.text = "GameSparks Authenticated With Facebook...";
                                Debug.Log("GameSparks Authenticated With Facebook..."+ fbauth_response.DisplayName);
                                //userNameField.text = fbauth_response.DisplayName;
                            }
                            else
                            {
                                Debug.LogWarning(fbauth_response.Errors.JSON); // if we have errors, print them out
                            }
                        });
                }
                else
                {
                    Debug.LogWarning("Facebook Login Failed:" + result.Error);
                }
            }); // lastly call another method to login, and when logged in we have a callback
        }
        else
        {
            FacebookConnect_bttn();// if we are still not connected, then try to process again
        }
    }

}
