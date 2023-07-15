namespace Zoo_Management_System
{
    // --> demonstrating Abstraction
    // creating interface to achieve security, hide implementation details from the user
    // interfaces can only contain signatures
    // interfaces contains methods specific to some classes but not for all.
    // Default Access: public
    // can only have public or internal access specifiers
    interface ISoundBehaviour 
    {
        void MakeSound(); // abstract and public method by default
    }

}
