// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

do
{
    Console.WriteLine("Seleccione la operación desea realizar:\n" +
                      "- Suma\n" +
                      "- Resta\n" +
                      "- Multiplicación\n" +
                      "- División\n" +
                      "- Porcentaje\n" +
                      "- Promedio:");
    Console.WriteLine("Ingrese aquí la operación:");
    string operacion = Console.ReadLine().ToLower();


    Console.WriteLine("Ingrese el primer número:");
    string input1 = Console.ReadLine();
    double num1;

    if (!double.TryParse(input1, out num1))
    {
        Console.WriteLine("Por favor, ingrese un número válido.");
        continue;
    }

    Console.WriteLine("Ingrese el segundo número:");
    string input2 = Console.ReadLine();
    double num2;

    if (!double.TryParse(input2, out num2))
    {
        Console.WriteLine("Por favor, ingrese un número válido.");
        continue;
    }

    double resultado = 0;

    switch (operacion)
    {
        case "suma":
            resultado = num1 + num2;
            Console.WriteLine("El resultado de la suma es: " + resultado);
            break;
        case "resta":
            resultado = num1 - num2;
            Console.WriteLine("El resultado de la resta es: " + resultado);
            break;
        case "multiplicacion":
            resultado = num1 * num2;
            Console.WriteLine("El resultado de la multiplicación es: " + resultado);
            break;
        case "division":
            if (num2 != 0)
            {
                resultado = num1 / num2;
                Console.WriteLine("El resultado de la división es: " + resultado);
            }
            else
            {
                Console.WriteLine("Error: No se puede dividir por cero.");
                continue;
            }
            break;
        case "porcentaje":
            resultado = (num1 * num2) / 100;
            Console.WriteLine("El resultado del porcentaje es: " + resultado);
            break;
        case "promedio":
            Console.WriteLine("Ingrese el tercer número:");
            string input3 = Console.ReadLine();
            double num3;
            if (!double.TryParse(input3, out num3))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }
            resultado = (num1 + num2 + num3) / 3;
            Console.WriteLine("El resultado del promedio es: " + resultado);
            break;
        default:
            Console.WriteLine("Operación no válida.");
            continue;
    }


} while (true);
    