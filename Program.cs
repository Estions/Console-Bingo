using ConsoleBingo.Classes;

#region Default Variables
int Height = 3;
int Width = 5;
int BagSize = 60;
int DrawSize = 30;
#endregion

#region Redundancy
if (BagSize < DrawSize)
{
    Console.WriteLine("Cannot draw more balls than there are in the Bag.");
    Console.WriteLine("Bag Size is : " + BagSize);
    Console.WriteLine("You are trying to draw : " + DrawSize);
    return;
}
#endregion

#region My Variables
int DrawDelay = 50;
List<int> Bag = new List<int>();
#endregion

//Fill Bag With Integers from 1 to {BagSize}
//This is reasonable, since after testing, the chances of getting at least 100 score are incredibly low.
for (int i = 1; i < BagSize+1; i++) Bag.Add(i);

//Declare the Bingo Board
Board mainBoard = new Board(Height, Width);
mainBoard.populateBoard(Bag);

#region Display
//Display Initial Board State
Console.WriteLine("Initial Card State : ");
Methods.displayBoard(mainBoard);

//Check for matches
Console.Write("\nDrawn Balls : ");
for (int i = 0; i < DrawSize; i++)
{
    if (i % 10 == 0) Console.Write("\n");
    int Number = Bag[Random.Shared.Next(0, Bag.Count)];
    Bag.Remove(Number);
    int Index = mainBoard.ContainsNumber(Number);
    if (Index != -1)
    {
        mainBoard.Cells[Index].marked = true;
        Console.Write("[" + Number + "] ");
    }
    else Console.Write(Number + " ");
    Thread.Sleep(DrawDelay);
}

//Display Final Board State
Console.WriteLine("\n\nFinal Card State : ");
Methods.displayBoard(mainBoard);
Console.WriteLine("Final Score : " + mainBoard.GetScore());
#endregion