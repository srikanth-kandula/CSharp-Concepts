using System;
using System.IO;

namespace CSharpConcepts
{
    class ExceptionHandling
    {
        public ExceptionHandling()
        {
            DemoExceptionHandling(); //'finally' block is needed to dispose
            DemoExceptionHandlingUsing(); //'using' will take care of disposing without the need of 'finally' block
        }

        private static void DemoExceptionHandling()
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"C:\input.txt");
                throw new DivideByZeroException();
            }
            catch (DivideByZeroException ex) //catch specific exceptions before generic exceptions
            {
                Console.WriteLine($"DivideByZeroException: ${ex.Message}");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"ArithmeticException: ${ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: ${ex.Message}");
            }
            finally //this method always runs at the end
            {
                //dispose all un-managed resource here
                if (streamReader != null)
                    streamReader.Dispose();
            }
        }

        private static void DemoExceptionHandlingUsing()
        {
            try
            {
                //'using' will automatically always invoke streamReader.dispose() at the end without the need of
                //explict final block
                using (var streamReader = new StreamReader(@"C:\input.txt")) {
                    var content = streamReader.ReadToEnd();
                }
            }
            catch (DivideByZeroException ex) //catch specific exceptions before generic exceptions
            {
                Console.WriteLine($"DivideByZeroException: ${ex.Message}");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"ArithmeticException: ${ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: ${ex.Message}");
            }
        }
    }
}
