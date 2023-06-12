namespace DatabaseLayer;

public class Word
{
    public int ID { get; internal set; }
    
    public string ENG { get; set; }
    
    public string UKR { get; set; }
    
    public int Level { get; set; }
}