using System;

[Serializable]
public class Book {
	public string title;
    public string description;
    public string slug;
    public string coverBase64Encoded;
    public string author_name;
    public string illustrator_name;
    public string reading_minute;
    public string pageCount;
    public string age_min;
    public string age_max;
    public string publisher_id; 
    public Publisher publisher;

}

[Serializable]
public class BookCollection {
	
    public Book[] books;	
	
}
