namespace ElectronicAgenda_modified.BusinessLayer.Services
{
    public class MoneyConversor
    {
        static double DP(double cant) => cant * 55.05;
        static double DE(double cant) => cant * 0.9188;
        static double PD(double cant) => cant * 0.018;
        static double PE(double cant) => cant * 0.017;
        static double ED(double cant) => cant * 1.09;
        static double EP(double cant) => cant * 59.94;
    }
}