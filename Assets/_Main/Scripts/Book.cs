using System.Collections;
using System.Collections.Generic;


public class Book
{
    private string title;
    private string description;
    private string author;
    private string illustrator;
    private string readingTime;
    private string pageCount;
    private string ageRange;
    private string publisher;  
    private bool loved;  

    public Book(string title, string description, string author, string illustrator, string readingTime, string pageCount, string ageRange, string publisher){
        this.title = title;
        this.description = description;
        this.author = author;
        this.illustrator = illustrator;
        this.readingTime = readingTime;
        this.pageCount = pageCount;
        this.ageRange = ageRange;
        this.publisher = publisher;
    }

    public string GetTitle(){
        return this.title;
    }

    public string GetDescription(){
        return this.description;
    }
    public string GetAuthor(){
        return this.author;
    }
    public string GetIllustrator(){
        return this.illustrator;
    }
    public string GetReadingTime(){
        return this.readingTime;
    }
    public string GetPageCount(){
        return this.pageCount;
    }
    public string GetAgeRange(){
        return this.ageRange;
    }
    public string GetPublisher(){
        return this.publisher;
    }

    public bool GetLoved(){
        return this.loved;
    }

    public void SetLoved(bool value){
        this.loved = value;
    }
    
}
