public class Square
{
    public int value { get; set; }
    public bool lockedIn { get; set; }
    public ConsoleColor BackgroundColour { get; set; }

    public Square(int value)
    {
        this.value = value;
        this.lockedIn = false;
        BackgroundColour = ConsoleColor.DarkRed;
    }

    // public int GetValue()
    // {
    //     return value;
    // }
    //
    // public void SetValue(int value)
    // {
    //     this.value = value;
    // }

    // public bool GetLockedIn()
    // {
    //     return lockedIn;
    // }
    //
    // public void SetLockedIn(bool setLock)
    // {
    //     this.lockedIn = setLock;
    // }
    
    public override string ToString()
    {
        if (lockedIn == true)
        {
            BackgroundColour = ConsoleColor.Green;
        }
        else
        {
            BackgroundColour = ConsoleColor.DarkRed;
        }
        if (this.value == 16)
        {
            return " ";
        }

        return value.ToString();
    }
}