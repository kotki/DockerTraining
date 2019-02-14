namespace WebAPI1
{
    public class DockerTestTable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name};\n";
        }
    }
}
