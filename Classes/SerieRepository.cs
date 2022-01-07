namespace Series
{
    public class SerieRepository : IRepository
    {
        private List<Serie> serieList = new List<Serie>();
		public void Update(int id, Serie serie)
		{
			serieList[id] = serie;
		}

		public void Remove(int id)
		{
			serieList[id].Remove();
		}

		public void Add(Serie serie)
		{
			serieList.Add(serie);
		}

		public List<Serie> SerieList()
		{
			return serieList;
		}

		public int NextId()
		{
			return serieList.Count;
		}

		public Serie GetForId(int id)
		{
			return serieList[id];
		}
        
    }
}