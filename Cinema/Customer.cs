namespace Exercise2;

public class Customer
{
    public string AgeGroup { get; private set; }
    private int _age;

    public Customer(int age)
    {
        _age = age;
        AgeGroup = SetAgeGroup(age);
    }

    public int Age()
    {
        return _age;
    }

    private string SetAgeGroup(int age)
    {
        if (age < Config.ChildAgeCutOff)
        {
            return "child";
        }
        else if (age < Config.TeenAgeCutOff)
        {
            return "teen";
        }
        else if (age < Config.SeniorAgeCutOff)
        {
            return "adult";
        }
        else if (age < Config.SuperSeniorAgeCutOff)
        {
            return "senior";
        }
        return "supersenior";
    }
}
