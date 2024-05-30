using Controllers;
using Models;
using System.Net.WebSockets;


Console.WriteLine("inicio do processamento");

Car car = new Car()
{
    Name = "corolla",
    Color = "vermelho",
    Year = 2010,
};

foreach (var item in new CarController().GetAll().Where(x => x.Id > 90).ToList().Take(10))
{
    Console.WriteLine(item);
}

//for (int i = 0; i < 10000; i++)
//{
//    car.Name = "teste - " + i.ToString();
//    Console.WriteLine(new CarController().Insert(car) ? "Registro Inserido " + car.Name : "Erro ao inserir registro");
//}
//Console.WriteLine(car);

//Console.WriteLine("exemplo insert");


//Console.WriteLine("Validação");
//foreach (var item in new CarController().GetAll())
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("exemplo update");
//Console.WriteLine(new CarController().Update(car) ? "Registro atualizado" : "Erro ao atualizar registro");

//Console.WriteLine("validação: ");
//foreach (var item in new CarController().GetAll())
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("exemplo de delete: ");
//Console.WriteLine(new CarController().Delete(8) ? "Registro deletado" : "Erro ao deletar registro");

//Console.WriteLine("validação: ");
//foreach (var item in new CarController().GetAll())
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("exemplo get ");
//Console.WriteLine(new CarController().Get(6));

