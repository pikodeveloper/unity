using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleHTTP;

public class BookPlayListManager : MonoBehaviour
{
    [SerializeField] private Transform playlistListHolder;
    [SerializeField] private Transform playlistSelectorListHolder;
    [SerializeField] private GameObject playlistGOPrefab;
    [SerializeField] private GameObject playlistSelectorGOPrefab;
    [SerializeField] private Transform bottomBumper;

    [SerializeField] private ScrollRect verticalScrollRect;

    // Start is called before the first frame update
    void Start()
    {
        CallSelectorAPI();
        CallIndexAPI();
        // CallShowAPI(new List<string>(){"1"});
    }

    public void CallSelectorAPI(){
        
        APIController.Instance.Get("book/playlist/selector",CallSelectorAPIResponse);
    }

    public void CallIndexAPI(){        
        APIController.Instance.Get("book/playlist/index",CallIndexAPIResponse);
    }

    public void CallShowAPI(List<string> parameters){        
        APIController.Instance.Get("book/playlist/show",CallShowAPIResponse, parameters);
    }

    void CallIndexAPIResponse(Client http)
    {
        
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){

                Debug.Log(resp.ToString());

                string wrappedJSON = resp.WrapJSONArray("bookplaylists");
                
                BookplaylistCollection bookplaylistCollection = JsonUtility.FromJson<BookplaylistCollection>(wrappedJSON);
                
                foreach (Bookplaylist bookplaylist in bookplaylistCollection.bookplaylists)
                {
                    InstantiatePlaylistGO(bookplaylist);
                }
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
		}
    }

    void CallSelectorAPIResponse(Client http)
    {
        
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){

                Debug.Log(resp.ToString());

                string wrappedJSON = resp.WrapJSONArray("bookplaylists");
                
                BookplaylistCollection bookplaylistCollection = JsonUtility.FromJson<BookplaylistCollection>(wrappedJSON);
                
                foreach (Bookplaylist bookplaylist in bookplaylistCollection.bookplaylists)
                {
                    InstantiatePlaylistSelectorGO(bookplaylist);
                }
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
		}
    }

    void CallShowAPIResponse(Client http)
    {
        
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){                

                string wrappedJSON = resp.WrapJSONArray("bookplaylists");
                
                BookplaylistCollection bookplaylistCollection = JsonUtility.FromJson<BookplaylistCollection>(wrappedJSON);
                
                foreach (Bookplaylist bookplaylist in bookplaylistCollection.bookplaylists)
                {
                    InstantiatePlaylistGO(bookplaylist);                    
                }
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
		}
    }

    public void InstantiatePlaylistGO(Bookplaylist bookplaylist){

        GameObject playlistGO = Instantiate(playlistGOPrefab, playlistListHolder);
        PlaylistGO playlistGOComponent = playlistGO.GetComponent<PlaylistGO>();
        
        playlistGOComponent.Setup(verticalScrollRect, bookplaylist);
        
        bottomBumper.SetAsLastSibling();
    }

    public void InstantiatePlaylistSelectorGO(Bookplaylist bookplaylist){

        GameObject playlistSelectorGO = Instantiate(playlistSelectorGOPrefab, playlistSelectorListHolder);
        PlaylistSelectorGO playlistSelectorGOComponent = playlistSelectorGO.GetComponent<PlaylistSelectorGO>();
        
        playlistSelectorGOComponent.Setup(bookplaylist);
                
    }
}
