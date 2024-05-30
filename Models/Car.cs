namespace Models
{
    public class Car
    {
        public static readonly string INSERT = "INSERT INTO CAR  (Name, Color, Year) values (@Name,@Color,@Year)";
        public static readonly string UPDATE = "UPDATE CAR set Name = @Name, Color = @Color, Year = @Year WHERE Id = @id";
        public static readonly string DELETE = "DELETE FROM CAR WHERE Id = @id";
        public static readonly string GET = "SELECT Id,Name,Color,Year From CAR WHERE Id = @id";
        public static readonly string GETALL = "SELECT Id,Name,Color,Year From CAR";
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Cor: {Color}, Ano: {Year}";
        }
    }
}
