namespace Business.Module.BusinessEntyties
{
    public class Customer
    {
        public long IdCustomer { get; set; }
        
        public string CustomerName { get; set; }

        public long? Telephone { get; set; }
        
        public string Address { get; set; }
        
        public string EmailAddress { get; set; }

        public virtual Country Country { get; set; }
    }
}
