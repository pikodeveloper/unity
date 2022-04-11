using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;

public class BookStoryController : Singleton<BookStoryController>
{

    void Start(){
        // CallShowAPI("piro-si-bajak-laut-dan-permata-duyung");
    }

    public void CallShowAPI(string slug){
        List<string> parameters = new List<string>(){slug};
        APIController.Instance.Get("book/story/show",CallShowAPIResponse, parameters);
    }

    void CallShowAPIResponse(Client http)
    {
        Debug.Log("Response: ");
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){

                Debug.Log(resp.ToString());

                string wrappedJSON = resp.WrapJSONArray("bookStories");
                
                Debug.Log(wrappedJSON);

                BookStoryCollection bookStoryCollection = JsonUtility.FromJson<BookStoryCollection>(wrappedJSON);

                string story = bookStoryCollection.bookStories[0].value;
                
                BookManager.Instance.OpenReaderPage(story);
                
                
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
		}
    }
}
