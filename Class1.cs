internal class Program
{
    private const string _quit = "q";

    private static void Main(string[] args)
    {
        var manager = new Manager();
        var input = string.Empty;

        while (input != _quit)
        {
            Console.Write("Enter floor: ");
            input = Console.ReadLine();
            int floor;
            if (int.TryParse(input, out floor))
                manager.ButtonPressed(floor);
            else if (input == _quit)
                Console.WriteLine("GoodBye!");
            else
                Console.WriteLine("You have pressed an incorrect floor, Please try again");
        }
    }
}

internal enum Status
{
    GoingUp,
    GoingDown,
    Stopped
}

internal class Elevator
{
    public int TopFloor;

    public Elevator(int topFloor)
    {
        TopFloor = topFloor;
    }

    public int CurrentFloor { get; set; } = 1;
    public Status Status { get; set; } = Status.Stopped;

    public void MoveUp(int floor)
    {
        Status = Status.GoingUp;
        Console.WriteLine("Going up to: {0}", floor);
        CurrentFloor = floor;
        OpenDoor();
        CloseDoor();
    }

    public void MoveDown(int floor)
    {
        Status = Status.GoingDown;
        Console.WriteLine("Going down to: {0}", floor);
        CurrentFloor = floor;
        OpenDoor();
        CloseDoor();
    }

    private void OpenDoor()
    {
        Console.WriteLine("Door opening");
    }

    private void CloseDoor()
    {
        Console.WriteLine("Door closing, at floor: {0}", this.CurrentFloor);
    }
}

internal class Request
{
    public Request(int floor)
    {
        Floor = floor;
    }

    public int Floor { get; set; }
}

internal class Manager
{
    private readonly Queue<Request> _downRequests = new Queue<Request>();
    private readonly Elevator _elevator = new Elevator(10);
    private readonly Queue<Request> _upRequests = new Queue<Request>();

    public void ButtonPressed(int floor)
    {
        if (floor > _elevator.TopFloor)
        {
            Console.WriteLine("Only have {0} floors", _elevator.TopFloor);
            return;
        }

        if (floor > _elevator.CurrentFloor)
            _upRequests.Enqueue(new Request(floor));
        else
            _downRequests.Enqueue(new Request(floor));

        Move(floor);
    }

    private void Move(int floor)
    {
        switch (_elevator.Status)
        {
            case Status.GoingDown:
                while (_downRequests.Count > 0)
                    _elevator.MoveDown(_downRequests.Dequeue().Floor);

                _elevator.Status = Status.Stopped;
                break;

            case Status.GoingUp:
                while (_upRequests.Count > 0)
                    _elevator.MoveUp(_upRequests.Dequeue().Floor);

                _elevator.Status = Status.Stopped;
                break;

            case Status.Stopped:
                if (floor > _elevator.CurrentFloor)
                    _elevator.Status = Status.GoingUp;
                else if (floor <= _elevator.CurrentFloor)
                {
                    _elevator.Status = Status.GoingDown;
                }
                Move(floor);

                break;
            default:
                break;
        }
    }
}