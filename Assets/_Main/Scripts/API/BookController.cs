using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;

public class BookController : MonoBehaviour
{
    void Start(){
        // CallIndexAPI();
    }
    public void CallIndexAPI(){
        List<string> parameters = new List<string>(){"1"};
        APIController.Instance.Get("book/index",CallIndexAPIResponse);
    }

    void CallIndexAPIResponse(Client http)
    {
        Debug.Log("Response: ");
        if (http.IsSuccessful ()) {
			Response resp = http.Response ();

            if(resp.IsOK()){

                Debug.Log(resp.ToString());

                string wrappedJSON = resp.WrapJSONArray("books");
                
                BookCollection bookCollection = JsonUtility.FromJson<BookCollection>(wrappedJSON);
                            
                foreach (Book book in bookCollection.books)
                {
                    Debug.Log(book.title);
                }
                
            } else {
                Debug.Log(resp.ToString());
            }

		} else {
			Debug.Log("error: " + http.Error());
		}
    }
}
