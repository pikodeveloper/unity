using System;

[Serializable]
public class BookStory {
	public string id;
	public string value;	

}

[Serializable]
public class BookStoryCollection {
	
    public BookStory[] bookStories;	
	
}
