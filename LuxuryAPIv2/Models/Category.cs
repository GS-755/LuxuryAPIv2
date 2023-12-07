namespace LuxuryAPIv2.Models
{
    public class Category
    {
        public int IdCate { get; set; }
        public string Name { get; set; }

        public Category() { }
        public Category(string Name)
        {
            this.Name = Name;
        }
        public Category(int IdCate, string Name)
        {
            this.IdCate = IdCate;
            this.Name = Name;
        }
    }
}