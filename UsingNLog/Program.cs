using NLog;
using System.Runtime.CompilerServices;

public class Program
{
    static void Main(string[] args)

    { 
        Logger _logger = LogManager.GetCurrentClassLogger();
        try
        {
            _logger.Info(args[43653463453453]);
        }
        catch(Exception ex)
        {
            _logger.Error(ex.Message);
        }
        

    }
}


