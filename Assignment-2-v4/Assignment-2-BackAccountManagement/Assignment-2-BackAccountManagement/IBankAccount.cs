namespace Assignment_2_BackAccountManagement
{
    // creating interfaces that will be  implemented in the implement classes
    // this is a concept of Abstraction in OOP.
    // to hide implementation details

    public interface IBankAccount
    {
        void Deposit(float amount);
        void Withdraw(float amount);

    }

}
