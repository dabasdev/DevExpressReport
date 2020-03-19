namespace T871027.VM
{
    public class AccountForDto 
    {
        public int OperationTypeId { get; set; }
        public string EmployeeName { get; set; }
        public string OperationName { get; set; }
        public decimal? SumOfCredit { get; set; }
        public decimal? SumOfDebit { get; set; }

    }
}