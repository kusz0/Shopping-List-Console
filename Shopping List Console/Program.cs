using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace Shopping_List_Console
{
    internal class Program
    {

        static List<string> productList = new List<string>();

        static void Main(string[] args)
        {
            Start();

        }
        public static void Start()
        {
            bool appRunning = true;
            while (appRunning)
            {
                Console.WriteLine("=========SHOPPING LIST==========");
                Console.WriteLine("Choose Operation");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Delete Product");
                Console.WriteLine("3. Display All List Of Your Products");
                Console.WriteLine("4. Turn Off App");
                int[] operations = { 1, 2, 3,4 };
                Console.Write("Operation: ");
                int userOperation = 0;
                bool isValid = false;
                while(!isValid)
                {
                    Console.Write("Operation: ");
                    string userOperationChooseInput = Console.ReadLine();
                    int goodNumber;
                    if(!int.TryParse(userOperationChooseInput, out goodNumber))
                    {
                        Console.WriteLine("Invalid Number TryAgain!!!");
                        continue;
                    }
                    if(!operations.Contains(goodNumber))
                    {
                        Console.WriteLine("There is no operation like this. Try Again");
                        continue;
                    }
                    isValid = true;
                    userOperation = goodNumber;
                }
                switch(userOperation)
                {
                    case 1:
                        AddNewProduct();
                    Console.Clear();

                        break;
                    case 2:
                        DeleteProduct();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        ShowListOfProducts();
                        Console.WriteLine();
                        break;
                    case 4:
                        appRunning = false;
                        break;
                }
                }


        }
        public static void AddNewProduct()
        {
            Console.Clear();
            Console.WriteLine("=========SHOPPING LIST==========");


            Console.Write("Enter product name: ");
            string newProduct = Console.ReadLine();
            while ( string.IsNullOrWhiteSpace(newProduct))
            {
                Console.WriteLine("U cant enter nothing");
                Console.Write("Enter product name: ");
                newProduct = Console.ReadLine();
            }
            productList.Add(newProduct);
            Console.WriteLine($"SUCCESS {newProduct} was added :)");
        }
        public static void DeleteProduct()
        {
            if (productList.Count == 0)
            {
                Console.WriteLine("Your Procuct List Is Empty!");
                return;
            }
            Console.WriteLine("=======CHOOSE UR OPTION=======");
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {productList[i]}");
            }


            int userOption;
            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.Write("Enter the number of the product to delete: ");
                string? input = Console.ReadLine();
                int GoodNumber;

                if (!int.TryParse(input, out GoodNumber))
                {
                    Console.WriteLine("Invalid number format! Try again!");
                    continue; 
                }

                if (GoodNumber < 1 || GoodNumber > productList.Count)
                {
                    Console.WriteLine($"Invalid range! Choose number between 1 and {productList.Count}!");
                    continue;
                }

                isValidInput = true;
                userOption = GoodNumber;
                productList.RemoveAt(userOption - 1);
            }
            Console.Clear();

            Console.WriteLine("======SUCCESS=====");


        }


    


        public static void ShowListOfProducts()
        {
            if (productList.Count == 0)
            {
                Console.WriteLine("Your Procuct List Is Empty!");
                return;
            }

                Console.WriteLine("======List Of ur Products");
                for(int i = 0;i < productList.Count;i++)
                {
                    Console.WriteLine($"{i + 1}. {productList[i]}");
                }
               
            }


        }
}
