public class CustomerService {
    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    private class Customer {
        public string Name { get; }
        public string AccountId { get; }
        public string Problem { get; }
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }
        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    public void AddNewCustomer(string name, string accountId, string problem) {
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    public void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in the queue");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}