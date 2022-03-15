using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;

public class BookStoryController : MonoBehaviour
{

    void Start(){
        // CallShowAPI();
    }
    public void CallShowAPI(){
        List<string> parameters = new List<string>(){"molestias-quis-eaque-fugiat-dolorem-ut-minima-iusto-itaque-dolores-neque-autem"};
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
                            
                foreach (BookStory bookStory in bookStoryCollection.bookStories)
                {
                    Debug.Log(bookStory.value);
                }
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
		}
    }
}
