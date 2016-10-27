using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using Facebook.MiniJSON;
using System.Linq;
namespace GS
{
    public class FBManager : MonoBehaviour
    {
        public GameObject leaderboardLoading, inviteLoading;
        public Sprite[] stateSprites;
        // List of the invite and leaderboard list items
        List<ListItemLeaderboard> listLeaderboard = new List<ListItemLeaderboard>();
        List<ListItemInvite> listInvites = new List<ListItemInvite>();
        // List containers that list Items - (Dynamically Increasing ListView <Custom>)
        public GameObject leaderParent, inviteParent;

        //Prefabs that holds items that will be places in the containers.
        public ListItemLeaderboard itemLeaderPref;
        public ListItemInvite itemInvitePref;

        //string that let you get JSON from the Facebook API calls.
        string getScoreAPIString = "app/scores?fields=score",
            loadInvitableFriendsString = "me/invitable_friends?limit=150";

        //These Two buttons will be Active One at a Time
        public GameObject fbLogin, fbLogout, btnShareOverFB, btnPostScore, postScoreUI;

        public InputField scoreInputField;

        public ToggleState tglStateSlctAll = ToggleState.Unchecked;
        //Reference to Invite Button and select All- toggler
        public GameObject btnInvite;
        public Button btnSlctAll;

        // Info Text
        public Text infoText;
        // Delegate Responsible for Performing after picture Load Actions
        delegate void LoadPictureCallback(Texture2D texture, int index);

        void Awake()
        {
            SetButtonsListners();
            SetFBItems(false);
            InitNLogin();
        }
        void SetInfoText(string msg)
        {
            infoText.gameObject.SetActive(true);
            infoText.text = msg;
            Invoke("HideMsg", 3.0f);
        }
        void HideMsg()
        {
            infoText.gameObject.SetActive(false);
        }
        void SetButtonsListners()
        {
            fbLogin.GetComponent<Button>().onClick.AddListener(() =>
            {
                InitNLogin();
            });
            fbLogout.GetComponent<Button>().onClick.AddListener(() =>
            {
                LogoutFB();
            });
            
            btnShareOverFB.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShareScoreOverFacebook();
            });
            btnPostScore.GetComponent<Button>().onClick.AddListener(() =>
            {
                postScoreUI.SetActive(true);
            });

            btnInvite.GetComponent<Button>().onClick.AddListener(() =>
            {
                SendInvites();
            });
            btnSlctAll.onClick.AddListener(() =>
            {
                TglSelectAllClickHandler();
            });
        }

        #region Get and Post Score
        public void PostScore()
        {
            /*
            If you don't have facebook publish permission already, Ask for it
            Note! this is not going to work if your publish_actions permission is not approved by facebook.
            Each time you'll post score, It'll prompt user to grant publish_actions unless your app is 
            approved by facebook for publish actions.
            */
            if (!AccessToken.CurrentAccessToken.Permissions.Contains(publishPermission[0]))
            {
                // As A good Practice, You should tell your users that why you need publish permission so
                // show a dialog telling about it. or else simply go to facebook permission prompt.
                //sm.publish_permissionDialog.SetActive(true);
                GetPublishPermission();
            }
            else
            {
                PostOnlyIfPermitted();
            }
        }


        public void GetPublishPermission()
        {
            FB.LogInWithPublishPermissions(publishPermission,
            delegate (ILoginResult loginResult)
            {
                if (AccessToken.CurrentAccessToken.Permissions.Contains(publishPermission[0]))
                {
                    if (string.IsNullOrEmpty(loginResult.Error) && !loginResult.Cancelled)
                    {
                        PostOnlyIfPermitted();
                    }
                }
                else
                {
                    SetInfoText("no Publish Permission!");
                }

            });
        }
        void PostOnlyIfPermitted()
        {
            var scoreData = new Dictionary<string, string>() { { "score", scoreInputField.textComponent.text } };
            FB.API("/me/scores", HttpMethod.POST, delegate (IGraphResult r)
            {
                if (!r.Cancelled || r.Error != null)
                {
                    SetInfoText("Score Posted Successfully!");
                    LoadLeaderboard();
                }
                else
                {
                    SetInfoText("Error Occured!");
                }
            }, scoreData);
        }

        [HideInInspector]
        public int highScoreFacebook = 0;

        void GetFBScoreOfCurrentUser()
        {
            FB.API("me/score?fields=score", HttpMethod.GET, delegate (IGraphResult result)
            {
                if (string.IsNullOrEmpty(result.Error) && !result.Cancelled)
                {
                    try
                    {
                        //IDictionary data = result.ResultDictionary["data"] as IDictionary;
                        //highScoreFacebook = Convert.ToInt32(data["score"] as string);

                        Dictionary<string, object> JSON = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
                        List<object> data = JSON["data"] as List<object>;

                        highScoreFacebook= int.Parse(Convert.ToString(((Dictionary<string, object>)data[0])["score"]));
                        print(highScoreFacebook);
                        ShareScoreOverFacebook();
                    }
                    catch (Exception exp)
                    {
                        SetInfoText(exp.ToString());
                    }
                }
            });
        }
        #endregion

        #region Leaderboard
        //Method to load leaderboard
        public void LoadLeaderboard()
        {
            leaderboardLoading.SetActive(true);
            ReloadLeaderboard();
            FB.API(getScoreAPIString, HttpMethod.GET, CallBackLoadLeaderboard);
        }
        //callback of from Facebook API when the leaderboard data from the server is loaded.
        void CallBackLoadLeaderboard(IGraphResult result)
        {
            if (string.IsNullOrEmpty(result.Error) && !result.Cancelled)
            {
                Dictionary<string, object> JSON = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
                List<object> data = JSON["data"] as List<object>;
                for (int i = 0; i < data.Count; i++)
                {
                    string fScore;
                    try
                    {
                        fScore = Convert.ToString(((Dictionary<string, object>)data[i])["score"]);
                    }
                    catch (Exception)
                    {
                        fScore = "0";
                    }
                    Dictionary<string, object> UserInfo = ((Dictionary<string, object>)data[i])["user"] as Dictionary<string, object>;
                    string name = Convert.ToString(UserInfo["name"]);
                    string id = Convert.ToString(UserInfo["id"]);
                    CreateListItemLeaderboard(id, name, fScore, i + 1);
                    LoadFriendsAvatar(i);
                }
                leaderboardLoading.SetActive(false);
            }
            if (result.Error != null)
            {
                FB.API(getScoreAPIString, HttpMethod.GET, CallBackLoadLeaderboard);
                return;
            }
        }

        // Method to load Friends Profile Pictures
        void LoadFriendsAvatar(int index)
        {
            FB.API(Util.GetPictureURL(listLeaderboard[index].fId), HttpMethod.GET, result =>
         {
             if (result.Error != null)
             {
                 Debug.LogError(result.Error);
                 return;
             }
             listLeaderboard[index].picUrl = Util.DeserializePictureURLString(result.RawResult);
             StartCoroutine(LoadPicRoutine(listLeaderboard[index].picUrl, index));
         });
        }

        //Method to all items to the leaderboard dynamically scrollable list
        void CreateListItemLeaderboard(string id, string fName, string fScore = "", int rank = 0)
        {
            ListItemLeaderboard tempItem = Instantiate(itemLeaderPref) as ListItemLeaderboard;
            tempItem.AssignValues(id, fName, fScore, rank.ToString());
            tempItem.transform.SetParent(leaderParent.transform, false);
            listLeaderboard.Add(tempItem);
        }

        //Coroutine to load Picture from the specified URL
        IEnumerator LoadPicRoutine(string url, int index)
        {
            WWW www = new WWW(url);
            yield return www;

            Texture2D texture = www.texture;
            if (texture == null)
            {
                StartCoroutine(LoadPicRoutine(listLeaderboard[index].picUrl, index));
            }
            else
            {
                listLeaderboard[index].imgPic.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            }
        }
        #endregion

        #region fbLoginLogout

        List<string> readPermission = new List<string>() { "public_profile", "user_friends" },
        publishPermission = new List<string>() { "publish_actions" };

        bool inProcess = false;
        public void InitNLogin()
        {
            if (!inProcess)
            {
                inProcess = true;
                if (!FB.IsInitialized)
                {
                    FB.Init(InitCallback, onHideUnity);
                }
                else
                {
                    FB.ActivateApp();
                    if (FB.IsLoggedIn)
                    {
                        SetInfoText("Already Logged In.");
                        SetFacebookRelatedData();
                    }
                    else
                    {
                        WaitForSecAndCheck();
                    }
                }
            }

        }
        private void InitCallback()
        {
            if (FB.IsInitialized)
            {
                WaitForSecAndCheck();
            }
            else
            {
                SetInfoText("Failed to Initialize the Facebook SDK");
                InitNLogin();
            }

        }

        private void onHideUnity(bool isGameShown)
        {
            if (!isGameShown)
            {
                // Pause the game - we will need to hide
                Time.timeScale = 0;
            }
            else
            {
                // Resume the game - we're getting focus again
                Time.timeScale = 1;
            }
        }

        //Callback method of login
        void LoginCallback(ILoginResult result)
        {
            if (FB.IsLoggedIn)
            {
                // AccessToken class will have session details
                //var aToken = AccessToken.CurrentAccessToken;
                //foreach (string perm in aToken.Permissions)
                //{
                //    print(perm);
                //}
                SetInfoText("Logged In Successfully!");
                SetFacebookRelatedData();
            }
            else
            {
                SetInfoText("User cancelled login");
                SetFBItems(false);
            }
        }
        void SetFBItems(bool isLoggedIn)
        {
            inProcess = false;
            fbLogin.SetActive(!isLoggedIn);

            btnSlctAll.gameObject.SetActive(isLoggedIn);
            btnInvite.SetActive(isLoggedIn);
            btnShareOverFB.SetActive(isLoggedIn);
            fbLogout.SetActive(isLoggedIn);
            btnPostScore.SetActive(isLoggedIn);
        }
        void SetFacebookRelatedData()
        {
            SetFBItems(true);
            LoadLeaderboard();
            LoadInvitableFriends();
        }

        // Remedy for A Facebook Plugin Bug that Returns False if Inquired about FB.IsLoggedIn in Call Back of FB.Init!
        void WaitForSecAndCheck()
        {
            if (FB.IsLoggedIn)
            {
                SetInfoText("Already Logged In.");
                SetFacebookRelatedData();
            }
            else
            {
                StartCoroutine(CheckFbInit());
            }
        }
        IEnumerator CheckFbInit()
        {
            yield return new WaitForSeconds(1f);

            if (FB.IsLoggedIn)
            {
                //Here you should be logged in
                SetFacebookRelatedData();
            }
            else
            {
                FB.ActivateApp();
                FB.LogInWithReadPermissions(readPermission, LoginCallback);
            }

        }
        public void LogoutFB()
        {
            FB.LogOut();
            SetFBItems(false);
            ReloadLeaderboard();
            ReloadInvite();
        }
        void ReloadLeaderboard()
        {
            listLeaderboard.Clear();
            for (int i = 0; i < leaderParent.transform.childCount; i++)
            {
                Destroy(leaderParent.transform.GetChild(i).gameObject);
            }
        }

        void ReloadInvite()
        {
            listInvites.Clear();
            for (int i = 0; i < inviteParent.transform.childCount; i++)
            {
                Destroy(inviteParent.transform.GetChild(i).gameObject);
            }
            tglStateSlctAll = ToggleState.Unchecked;
            btnSlctAll.image.sprite = stateSprites[0];
        }
        #endregion

        #region ShareStory

        public void ShareScoreOverFacebook()
        {
            if (highScoreFacebook == 0)
            {
                GetFBScoreOfCurrentUser();
            }
            else
            {
                string shareDesc = (highScoreFacebook > 0) ?
                Constants.shareDialogMsg + " My High Score is " + highScoreFacebook :
                Constants.shareDialogMsg;

                if (FB.IsLoggedIn)
                {
                    FB.ShareLink(
                        contentURL: Constants.fbShareURI,
                        contentTitle: Constants.shareDialogTitle,
                        contentDescription: shareDesc,
                        photoURL: Constants.fbSharePicURI,
                        callback: PostOnFBCallback
                        );
                }
            }

        }
        private void PostOnFBCallback(IShareResult result)
        {
            if (string.IsNullOrEmpty(result.Error) && !result.Cancelled)
            {
                SetInfoText("Story Posted Successfully!");
            }
            else
            {
                SetInfoText("Error Occured!");
            }

        }
        
        #endregion

        #region Invite
        // Method that Proceeds with the Invitable Friends
        void LoadInvitableFriends()
        {
            ReloadInvite();
            inviteLoading.SetActive(true);
            FB.API(loadInvitableFriendsString, HttpMethod.GET, CallBackLoadInvitableFriends);
        }
        //Callback of Invitable Friends API Call
        void CallBackLoadInvitableFriends(IGraphResult result)
        {
            //Deserializing JSON returned from server
            Dictionary<string, object> JSON = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
            List<object> data = JSON["data"] as List<object>;
            //Loop to traverse and process all the items returned from the server.
            for (int i = 0; i < data.Count; i++)
            {
                string id = Convert.ToString(((Dictionary<string, object>)data[i])["id"]);
                string name = Convert.ToString(((Dictionary<string, object>)data[i])["name"]);
                Dictionary<string, object> picInfo = ((Dictionary<string, object>)data[i])["picture"] as Dictionary<string, object>;
                string url = Util.DeserializePictureURLObject(picInfo);
                CreateListItemInvite(id, name, url);
                StartCoroutine(LoadFPicRoutine(url, PicCallBackInvitable, i));
            }
            inviteLoading.SetActive(false);
        }
        //Method to add item to the custom invitable dynamically scrollable list
        void CreateListItemInvite(string id, string fName, string url = "")
        {
            ListItemInvite tempItem = Instantiate(itemInvitePref) as ListItemInvite;
            tempItem.AssignValues(id, url, fName);
            tempItem.transform.SetParent(inviteParent.transform, false);
            listInvites.Add(tempItem);
        }
        //Callback of Invitable Friend API call
        void PicCallBackInvitable(Texture2D texture, int index)
        {
            if (texture == null)
            {
                StartCoroutine(LoadFPicRoutine(listInvites[index].picUrl, PicCallBackInvitable, index));
                return;
            }
            listInvites[index].imgPic.sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );
        }

        //Click Handler of Select All Buttons
        public void TglSelectAllClickHandler()
        {
            switch (tglStateSlctAll)
            {
                case ToggleState.Partial:
                case ToggleState.Unchecked:
                    foreach (var item in listInvites)
                    {
                        item.tglBtn.isOn = true;
                    }
                    tglStateSlctAll = ToggleState.Checked;
                    ChangeToggleState(ToggleState.Checked);
                    break;
                case ToggleState.Checked:
                    foreach (var item in listInvites)
                    {
                        item.tglBtn.isOn = false;
                    }
                    ChangeToggleState(ToggleState.Unchecked);
                    break;
            }
        }
        //Method to change Toggle State On the Fly
        public void ChangeToggleState(ToggleState state)
        {
            switch (state)
            {
                case ToggleState.Unchecked:
                    tglStateSlctAll = state;
                    btnSlctAll.image.sprite = stateSprites[0];
                    break;
                case ToggleState.Partial:
                    bool flagOn = false, flagOff = false;
                    foreach (var item in listInvites)
                    {
                        if (item.tglBtn.isOn)
                        {
                            flagOn = true;
                        }
                        else
                        {
                            flagOff = true;
                        }
                    }
                    if (flagOn && flagOff)
                    {
                        tglStateSlctAll = state;
                        btnSlctAll.image.sprite = stateSprites[1];
                        //Debug.Log("Partial");
                    }
                    else if (flagOn && !flagOff)
                    {
                        ChangeToggleState(ToggleState.Checked);
                        //Debug.Log("Checked");
                    }
                    else if (!flagOn && flagOff)
                    {
                        ChangeToggleState(ToggleState.Unchecked);
                        //Debug.Log("Unchecked");
                    }
                    break;
                case ToggleState.Checked:
                    tglStateSlctAll = state;
                    btnSlctAll.image.sprite = stateSprites[2];
                    break;
            }
        }
        IEnumerator LoadFPicRoutine(string url, LoadPictureCallback Callback, int index)
        {
            WWW www = new WWW(url);
            yield return www;
            Callback(www.texture, index);
        }
        void SendInvites()
        {
            List<string> lstToSend = new List<string>();
            foreach (var item in listInvites)
            {
                if (item.tglBtn.isOn)
                {
                    lstToSend.Add(item.fId);
                }
            }
            int dialogCount = (int)Mathf.Ceil(lstToSend.Count / 50f);
            CallInvites(lstToSend, dialogCount);
        }
        //Helping method that will be recursive if you'll have to sent invites to more than 50 Friends.
        private void CallInvites(List<string> lstToSend, int dialogCount)
        {
            if (dialogCount > 0)
            {
                string[] invToSend = (lstToSend.Count >= 50) ? new string[50] : new string[lstToSend.Count];

                for (int i = 0; i < invToSend.Length; i++)
                {
                    try
                    {
                        if (lstToSend[i] != null)
                        {
                            invToSend[i] = lstToSend[i];
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e.Message);
                    }
                }
                lstToSend.RemoveRange(0, invToSend.Length);
                FB.AppRequest(
                    Constants.inviteDialogMsg,
                    invToSend,
                    null,
                    null,
                    null,
                    "",
                    Constants.inviteDialogTitle,
                    FBResult =>
                    {
                        if (--dialogCount > 0)
                        {
                            CallInvites(lstToSend, dialogCount);
                        }
                    }
                );
            }
        }
        #endregion
    }
    public enum ToggleState
    {
        Unchecked,
        Partial,
        Checked
    };
}

