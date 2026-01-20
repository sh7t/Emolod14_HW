using EM_HW14.Source.CustomStackXrsice;
using EM_HW14.Source.Utils;
using System;

namespace EM_HW14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // test
                // test
                // test
                // test
                // test
                // test
                // test
                // test
                // test
            }
            catch (LimitedStackException ex) { ConsoleHelper.ShowLimitedStackError(ex.Message); }
            catch (NullReferenceException) { ConsoleHelper.ShowError("Null can't be a valid value here!"); }
            catch (Exception ex) { ConsoleHelper.ShowError(ex.Message); }
        }
    }
}
