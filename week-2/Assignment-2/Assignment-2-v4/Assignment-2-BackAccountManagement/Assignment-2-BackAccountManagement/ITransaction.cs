namespace Assignment_2_BackAccountManagement
{
    // creating interfaces that will be  implemented in the implement classes
    // this is a concept of Abstraction in OOP.
    // to hide implementation details

    public interface ITransaction
    {
        // --> Demonstrating Abstraction
        // Creating abstract methods: signatures only, cannot have method body
        // public and abstract by default
        void ExecuteTransaction(TransactionType type, float amount);
        void PrintTransaction(TransactionType type, float amount);
    }
}
