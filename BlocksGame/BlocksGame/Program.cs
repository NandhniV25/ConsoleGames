namespace BlocksGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Board board = new Board(10,10);
            var taskKeys = new Task(() => board.Read());
            taskKeys.Start();
            board.Play();
        }
    }
}