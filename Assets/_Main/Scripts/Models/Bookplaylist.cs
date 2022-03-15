using System;

[Serializable]
public class Bookplaylist {
	public string id;
	public string title;	
    public Book[] books;

}

[Serializable]
public class BookplaylistCollection {
	
    public Bookplaylist[] bookplaylists;	
	
}
