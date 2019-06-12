namespace Domain
{
    public class Animal : BaseAutdit, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CommonName CommonName { get; set; }
    }
}
