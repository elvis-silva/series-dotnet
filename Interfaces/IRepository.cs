namespace Series
{
    public interface IRepository
    {
        List<Serie> SerieList();
        Serie GetForId(int id);        
        void Add(Serie serie);        
        void Remove(int id);        
        void Update(int id, Serie serie);
        int NextId();
    }
}