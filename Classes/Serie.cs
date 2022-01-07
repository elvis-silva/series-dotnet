namespace Series
{
    public class Serie : BaseEntity
    {
		public Genre Genre{ get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Year { get; set; }
        public bool Removed {get; set;}

		public Serie(int id, Genre genre, string title, string description, int year)
		{
			this.Id = id;
			this.Genre = genre;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Removed = false;
		}

        public override string ToString()
		{
            string output = "";
            output += "Gênero: " + this.Genre + Environment.NewLine;
            output += "Titulo: " + this.Title + Environment.NewLine;
            output += "Descrição: " + this.Description + Environment.NewLine;
            output += "Ano de Início: " + this.Year + Environment.NewLine;
            output += "Excluido: " + this.Removed;
			return output;
		}

        public string GetTitle()
		{
			return this.Title;
		}

		public int GetId()
		{
			return this.Id;
		}
        public bool IsRemoved()
		{
			return this.Removed;
		}
        public void Remove() {
            this.Removed = true;
        }
    }
}