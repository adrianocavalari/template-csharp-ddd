namespace Template.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Total { get; set; }

        public virtual User User { get; set; }

    }
}
