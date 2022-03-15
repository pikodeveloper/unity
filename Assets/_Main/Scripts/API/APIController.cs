using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleHTTP;

public class APIController : Singleton<APIController>
{
    private const string baseURL = "http://127.0.0.1:8000/api/";
    private string token = "1|Az0l8ulOYnOkuDwCIK0YFlxx5b4xVx83FnqtMhNN";
    
    public void Get(string url, System.Action<Client> callback , List<string> parameters = null){
        StartCoroutine(GetIE(url,callback, parameters));
    }

    IEnumerator GetIE(string url, System.Action<Client> callback, List<string> parameters = null) {

        string fullURL = baseURL + url;
        
        if(parameters != null){
            foreach (string parameter in parameters)
            {
                fullURL += "/" + parameter;
            }
        }

		Request request = new Request(fullURL)
        .AddHeader("Accept", "application/json")
        .AddHeader("Authorization", "Bearer " + token);

		Client http = new Client ();
		yield return http.Send (request);
        callback(http);
		// ProcessResult (http);
	}

	// IEnumerator Post() {
	// 	Post post = new Post ("Test", "This is a test", 1);

	// 	Request request = new Request (validURL)
	// 		.AddHeader ("Accept", "application/json")
	// 		.Post (RequestBody.From<Post> (post));

	// 	Client http = new Client ();
	// 	yield return http.Send (request);
	// 	ProcessResult (http);
	// }

    public void PostWithFormData(string url){
        StartCoroutine(PostWithFormDataIE(url));
    }
	IEnumerator PostWithFormDataIE(string url) {
		FormData formData = new FormData ()
			.AddField ("email", "januarelsan@gmail.com")
			.AddField ("password", "qwerty123");

        string fullURL = baseURL + url;

        Debug.Log(fullURL);

		Request request = new Request (fullURL)
			.Post (RequestBody.From(formData));

		Client http = new Client ();
		yield return http.Send (request);
		ProcessResult (http);
	}

	// IEnumerator Put() {
	// 	Post post = new Post ("Another Test", "This is another test", 1);

	// 	Request request = new Request (validURL + "1")
	// 		.Put (RequestBody.From<Post> (post));

	// 	Client http = new Client ();
	// 	yield return http.Send (request);
	// 	ProcessResult (http);
	// }

	// IEnumerator Delete() {
	// 	Request request = new Request (validURL + "1")
	// 		.Delete ();

	// 	Client http = new Client ();
	// 	yield return http.Send (request);
	// 	ProcessResult (http);
	// }

	void ProcessResult(Client http) {
		if (http.IsSuccessful ()) {
			Response resp = http.Response ();
			Debug.Log("status: " + resp.Status().ToString() + "\nbody: " + resp.Body());
		} else {
			Debug.Log("error: " + http.Error());
		}
		
	}
}
