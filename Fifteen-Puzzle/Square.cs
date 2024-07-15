public class Square
{
    public int value { get; set; }

    public Square(int value)
    {
        this.value = value;
    }
    
    public override string ToString()
    {
        if (this.value == 16)
        {
            return " ";
        }
        return value.ToString();
    }
}