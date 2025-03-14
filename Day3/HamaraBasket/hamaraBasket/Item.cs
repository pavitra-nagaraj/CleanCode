namespace hamaraBasket
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }

        private int _quality;

        public int Quality
        {
            get => _quality;
            set
            {
                if (value < 0 || value > 50)
                    throw new ArgumentOutOfRangeException(nameof(Quality), "Quality must be between 0 and 50.");

                _quality = value;
            }
        }

        public override string ToString()
        {
            return this.Name + ", " + this.SellIn + ", " + this.Quality;
        }  
    }
}
