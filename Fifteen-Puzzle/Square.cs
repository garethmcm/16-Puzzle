public class Square
{
    private int value;

    public Square(int value)
    {
        this.value = value;
    }

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int value)
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