using System;

class Program
{
    static void Main(string[] args)
    {
       var hourly = new HourlyEmplyoyee("Elon Musk", 100, 14);
       var salary = new SalaryEmployee("Robert Oppenheimer", 90000, 14);

       var employees = new List<employyee> { hourly, salary};

       foreach (var employee in employees) {
            Console.WriteLine($"{employee._name} : {employee.PayPeriodWages()}");
       }

    }

   
}


class employyee
{
    //Attributes
    public string _name;
    protected int _payPeriodLength;

    //Methods
    public employyee(string name, int payPeriodLength)
    {
        _name = name;
        _payPeriodLength = payPeriodLength;
    }

    virtual public double PayPeriodWages()
    {
        return 0;
    }


}

class HourlyEmplyoyee : employyee
{
    //Attributes
    double _rate;

    //Methods

    public HourlyEmplyoyee(string name, int payPeriodLength, double rate) : base(name, payPeriodLength)
    {
        _rate = rate;
    }
    public override double PayPeriodWages()
    {
        return _rate * 8 * _payPeriodLength;
    }

}

class SalaryEmployee : employyee
{
    //Attributes
    double _annualRate;
    

    //Methods
    public SalaryEmployee(string name, int payPeriodLength, double annualRate) : base(name, payPeriodLength)
    {
        _annualRate = annualRate;
    }
    public override double PayPeriodWages()
    {
        return (_payPeriodLength / 365) * _annualRate;
    }

}